using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AppEnteringTrackingAndOrders
{
    // Модели для меню и заказов
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
    }

    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }

    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Destination { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<MenuItemModifier> Modifiers { get; set; } = new List<MenuItemModifier>();
    }

    public class MenuItemModifier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalCost { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int TableID { get; set; }
        public bool IsPaid { get; set; }
        public bool IsClosed { get; set; }
        // Связь с пользователем
        public int UserId { get; set; }
        public User User { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Guest { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<OrderItemModifier> Modifiers { get; set; } = new List<OrderItemModifier>();
    }

    public class OrderItemModifier
    {
        [Key]
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        public int MenuItemModifierId { get; set; }
        public MenuItemModifier MenuItemModifier { get; set; }
    }

    // Модели для пользователей и ролей
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }  // Внешний ключ
        public Role Role { get; set; }   // Одна роль
        public ICollection<Order> Orders { get; set; }
    }

    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; } // Все пользователи с этой ролью
    }

    // Основной контекст базы данных
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemModifier> MenuItemModifiers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemModifier> OrderItemModifiers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Env.Load();
            optionsBuilder.UseNpgsql(Env.GetString("DATA_BASE"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей для меню и заказов
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Menu)
                .WithMany(m => m.Groups)
                .HasForeignKey(g => g.MenuId);

            modelBuilder.Entity<MenuItem>()
                .HasOne(mi => mi.Group)
                .WithMany(g => g.MenuItems)
                .HasForeignKey(mi => mi.GroupId);

            modelBuilder.Entity<MenuItemModifier>()
                .HasOne(mim => mim.MenuItem)
                .WithMany(mi => mi.Modifiers)
                .HasForeignKey(mim => mim.MenuItemId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemId);

            modelBuilder.Entity<OrderItemModifier>()
                .HasOne(oim => oim.OrderItem)
                .WithMany(oi => oi.Modifiers)
                .HasForeignKey(oim => oim.OrderItemId);

            modelBuilder.Entity<OrderItemModifier>()
                .HasOne(oim => oim.MenuItemModifier)
                .WithMany()
                .HasForeignKey(oim => oim.MenuItemModifierId);

            // Настройка связи User-Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)         // У пользователя одна роль
                .WithMany(r => r.Users)      // У роли много пользователей
                .HasForeignKey(u => u.RoleId); // Внешний ключ
        }

        public async Task SendOrderAsync(int orderId)
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    // Получаем базовую информацию о заказе
                    var order = await context.Orders
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == orderId);

                    if (order == null)
                    {
                        await Logger.LogAsync($"Заказ с ID {orderId} не найден.");
                        return;
                    }
                    await Logger.LogAsync($"Начало обработки заказа {orderId} для стола {order.TableID}");
                    // Получаем все элементы заказа с их модификаторами
                    var orderItems = await context.OrderItems
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == orderId)
                        .Include(oi => oi.Modifiers)
                        .ToListAsync();

                    // Получаем ID всех MenuItem и MenuItemModifier
                    var menuItemIds = orderItems.Select(oi => oi.MenuItemId).Distinct();
                    var modifierIds = orderItems.SelectMany(oi => oi.Modifiers.Select(m => m.MenuItemModifierId)).Distinct();

                    // Загружаем связанные данные отдельными запросами
                    var menuItems = await context.MenuItems
                        .AsNoTracking()
                        .Where(mi => menuItemIds.Contains(mi.Id))
                        .ToDictionaryAsync(mi => mi.Id);

                    var modifiers = await context.MenuItemModifiers
                        .AsNoTracking()
                        .Where(mim => modifierIds.Contains(mim.Id))
                        .ToDictionaryAsync(mim => mim.Id);

                    // Формируем вывод
                    await Logger.LogAsync($"┏ Заказ для стола: {order.TableID} ┓");

                    var kitchenItems = orderItems
                        .Where(oi => menuItems.TryGetValue(oi.MenuItemId, out var mi) && mi.Destination == "Кухня")
                        .ToList();

                    var barItems = orderItems
                        .Where(oi => menuItems.TryGetValue(oi.MenuItemId, out var mi) && mi.Destination == "Бар")
                        .ToList();

                    if (kitchenItems.Count > 0) await Logger.LogAsync("┃ Отправка на кухню: ┃");
                    foreach (var item in kitchenItems)
                    {
                        if (menuItems.TryGetValue(item.MenuItemId, out var menuItem))
                        {
                            await Logger.LogAsync($"┃ x{item.Quantity} {menuItem.Name} ┃");
                            if (item.Modifiers.Any())
                            {
                                await Logger.LogAsync("┃   Модификатор: ┃");
                                foreach (var modifier in item.Modifiers)
                                {
                                    if (modifiers.TryGetValue(modifier.MenuItemModifierId, out var mod))
                                    {
                                        await Logger.LogAsync($"┃   - {mod.Name} ┃");
                                    }
                                }
                            }
                        }
                    }
                    await Logger.LogAsync("──────────────────");
                    if (barItems.Count > 0) await Logger.LogAsync("┃ Отправка на бар: ┃");
                    foreach (var item in barItems)
                    {
                        if (menuItems.TryGetValue(item.MenuItemId, out var menuItem))
                        {
                            await Logger.LogAsync($"┃ x{item.Quantity} {menuItem.Name} ┃");
                            if (item.Modifiers.Any())
                            {
                                await Logger.LogAsync("┃   Модификатор: ┃");
                                foreach (var modifier in item.Modifiers)
                                {
                                    if (modifiers.TryGetValue(modifier.MenuItemModifierId, out var mod))
                                    {
                                        await Logger.LogAsync($"┃   - {mod.Name} ┃");
                                    }
                                }
                            }
                        }
                    }
                    await Logger.LogAsync("┗ Конец чека ┛");
                    await Logger.LogAsync($"Заказ {orderId} успешно отправлен на кухню/бар");
                }
            }
            catch (Exception ex)
            {
                await Logger.LogAsync($"Ошибка при отправке заказа: {ex.Message}");
                throw;
            }
        }

        public async Task SendPaymentReceiptAsync(int orderId)
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    // Получаем информацию о заказе
                    var order = await context.Orders
                        .AsNoTracking()
                        .Include(o => o.User)
                        .FirstOrDefaultAsync(o => o.Id == orderId);

                    if (order == null)
                    {
                        await Logger.LogAsync($"Заказ с ID {orderId} не найден.");
                        return;
                    }

                    // Получаем все элементы заказа с группировкой по гостям
                    var orderItems = await context.OrderItems
                        .AsNoTracking()
                        .Where(oi => oi.OrderId == orderId)
                        .Include(oi => oi.MenuItem)
                        .Include(oi => oi.Modifiers)
                            .ThenInclude(oim => oim.MenuItemModifier)
                        .ToListAsync();

                    // Группируем по гостям (0 - общие позиции)
                    var groupedItems = orderItems
                        .GroupBy(oi => oi.Guest)
                        .OrderBy(g => g.Key); // Сначала общие позиции (Guest = 0), затем по номерам гостей

                    // Формируем чек
                    var receipt = new StringBuilder();
                    receipt.AppendLine($"┃ Чек по заказу #{orderId}");
                    receipt.AppendLine($"┃ Стол: {order.TableID}");
                    receipt.AppendLine($"┃ Дата: {order.OrderDate:dd.MM.yyyy HH:mm}");
                    receipt.AppendLine($"┃ Официант: {order.User?.Username ?? "Не указан"}");
                    receipt.AppendLine("----------------------------------");

                    decimal totalSum = 0;

                    foreach (var group in groupedItems)
                    {
                        if (group.Key > 0)
                        {
                            receipt.AppendLine($"\n┃ Гость {group.Key}:");
                        }
                        else if (groupedItems.Count() > 1) // Если есть гости, выводим "Общие позиции"
                        {
                            receipt.AppendLine("\n┃ Общие позиции:");
                        }

                        decimal groupSum = 0;

                        foreach (var item in group)
                        {
                            // Добавляем основное блюдо
                            receipt.AppendLine($"┃ {item.MenuItem.Name} x{item.Quantity} - {item.MenuItem.Price * item.Quantity} руб.");
                            groupSum += item.MenuItem.Price * item.Quantity;

                            // Добавляем модификаторы
                            foreach (var modifier in item.Modifiers)
                            {
                                receipt.AppendLine($"┃  + {modifier.MenuItemModifier.Name} - {modifier.MenuItemModifier.AdditionalCost} руб.");
                                groupSum += modifier.MenuItemModifier.AdditionalCost;
                            }
                        }

                        receipt.AppendLine($"┃ Итого: {groupSum} руб.");
                        totalSum += groupSum;
                    }

                    receipt.AppendLine("\n----------------------------------");
                    receipt.AppendLine($"┃ ОБЩАЯ СУММА: {totalSum} руб.");
                    receipt.AppendLine("----------------------------------");
                    receipt.AppendLine("┃ Спасибо за посещение!");


                    await Logger.LogAsync(receipt.ToString());
                    await Logger.LogAsync($"Сформирован чек для заказа {orderId}");
                }
            }
            catch (Exception ex)
            {
                await Logger.LogAsync($"Ошибка при формировании чека: {ex}");
                return;
            }
        }

        public void InitializeDatabase()
        {
            try
            {
                if (Database.EnsureCreated())
                {
                    ConstantsInitialValuesMethodsDb.InitializeRoles();
                    ConstantsInitialValuesMethodsDb.InitializeAdminUser();
                }
                else
                {
                    Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка инициализации БД: {ex.Message}");
                throw;
            }
        }
    }

    public static class ConstantsInitialValuesMethodsDb
    {
        public static List<string> _roles = new List<string> { "Руководитель", "Администратор", "Официант" };

        // Инициализация ролей 
        public static void InitializeRoles()
        {
            using (var context = new RestaurantContext())
            {
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new Role { RoleName = "Руководитель" },
                        new Role { RoleName = "Администратор" },
                        new Role { RoleName = "Официант" }
                    );
                    context.SaveChanges();
                }
            }
        }

        // Инициализация руководителя (теперь с одной ролью)
        public static void InitializeAdminUser()
        {
            using (var context = new RestaurantContext())
            {
                if (!context.Users.Any())
                {
                    Env.Load();
                    string name = Env.GetString("NAME_ADMIN_USER"),
                           password = Env.GetString("PASSWORD_ADMIN_USER");
                    if (name != null && password != null)
                    {
                        var user = new User
                        {
                            Username = name,
                            PasswordHash = PasswordHasher.HashPassword(password),
                            RoleId = 1  // ID роли "Руководитель"
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
            }
        }

        // Добавление пользователя с одной ролью
        public static void AddUserWithRoles(string username, string password, string rolename)
        {
            using (var context = new RestaurantContext())
            {
                var role = context.Roles.FirstOrDefault(r => r.RoleName == rolename);
                if (role == null) return;

                var user = new User
                {
                    Username = username,
                    PasswordHash = PasswordHasher.HashPassword(password),
                    RoleId = role.RoleId  // Устанавливаем ID роли
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        // Обновление пользователя (включая смену роли)
        public static void EditUserWithRoles(string username, string password, string rolename)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                var role = context.Roles.FirstOrDefault(r => r.RoleName == rolename);

                if (user != null && role != null)
                {
                    user.PasswordHash = PasswordHasher.HashPassword(password);
                    user.RoleId = role.RoleId;  // Меняем роль
                    context.SaveChanges();
                }
            }
        }

        // Удаление пользователя (теперь не нужно Include для Roles)
        public static void DeleteUserWithRoles(string username)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        // Аутентификация пользователя (теперь с одной ролью)
        public static User AuthenticateUser(string username, string password)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users
                    .Include(u => u.Role)  // Включаем роль (теперь это одна роль)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    return user;
                }
                return null;
            }
        }

        // Проверка существования пользователя
        public static bool FindUser(string username)
        {
            using (var context = new RestaurantContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        // Получение ID роли пользователя (теперь просто через RoleId)
        public static int? GetRoleIdForUser(User user)
        {
            using (var context = new RestaurantContext())
            {
                var dbUser = context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.UserId == user.UserId);

                return dbUser?.RoleId;  // Возвращает RoleId или null
            }
        }
    }
}