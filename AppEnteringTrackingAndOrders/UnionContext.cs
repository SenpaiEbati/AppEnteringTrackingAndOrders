using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public ICollection<Role> Roles { get; set; }
        public ICollection<Order> Orders { get; set; } // Обратная связь с заказами
    }

    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
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

            // Настройка связи многие-ко-многим для User-Role
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
        }

        public async Task SendOrderAsync(int orderId)
        {
            var order = await Orders
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Modifiers)
                        .ThenInclude(oim => oim.MenuItemModifier)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                var kitchenItems = order.Items.Where(oi => oi.MenuItem.Destination == "Кухня").ToList();
                var barItems = order.Items.Where(oi => oi.MenuItem.Destination == "Бар").ToList();

                Console.WriteLine($"Order for table: {order.TableID}");
                Console.WriteLine("Sending to kitchen:");
                foreach (var item in kitchenItems)
                {
                    Console.WriteLine($"{item.MenuItem.Name} x {item.Quantity}");
                    if (item.Modifiers.Any())
                    {
                        Console.WriteLine("Modifiers:");
                        foreach (var modifier in item.Modifiers)
                        {
                            Console.WriteLine($"- {modifier.MenuItemModifier.Name}");
                        }
                    }
                }

                Console.WriteLine("Sending to bar:");
                foreach (var item in barItems)
                {
                    Console.WriteLine($"{item.MenuItem.Name} x {item.Quantity}");
                    if (item.Modifiers.Any())
                    {
                        Console.WriteLine("Modifiers:");
                        foreach (var modifier in item.Modifiers)
                        {
                            Console.WriteLine($"- {modifier.MenuItemModifier.Name}");
                        }
                    }
                }
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

        // Инициализация руководителя
        public static void InitializeAdminUser()
        {
            using (var context = new RestaurantContext())
            {
                if (!context.Users.Any())
                {
                    Env.Load();
                    string name = Env.GetString("NAME_ADMIN_USER"), password = Env.GetString("PASSWORD_ADMIN_USER");
                    if (name != null && password != null)
                    {
                        var user = new User
                        {
                            Username = name,
                            PasswordHash = PasswordHasher.HashPassword(password),
                            Roles = context.Roles.Where(r => r.RoleId == 1).ToList()
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
            }
        }

        // Логика аутентификации 
        public static User AuthenticateUser(string username, string password)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null && PasswordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    return user;
                }
                return null;
            }
        }

        // Логика назначения ролей
        public static void AddUserWithRoles(string username, string password, string rolename)
        {
            using (var context = new RestaurantContext())
            {
                var user = new User
                {
                    Username = username,
                    PasswordHash = PasswordHasher.HashPassword(password),
                    Roles = context.Roles.Where(r => r.RoleName == rolename).ToList()
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void EditUserWithRoles(string username, string password, string rolename)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    user.PasswordHash = PasswordHasher.HashPassword(password);
                    user.Roles = context.Roles.Where(r => r.RoleName == rolename).ToList();

                    context.Users.Update(user);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteUserWithRoles(string username)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public static bool FindUser(string username)
        {
            using (var context = new RestaurantContext())
            {
                var user = context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }

        public static int? GetRoleIdForUser(User user)
        {
            using (var context = new RestaurantContext())
            {
                var roleId = context.Users
                    .Include(u => u.Roles)
                    .Where(u => u.UserId == user.UserId)
                    .SelectMany(u => u.Roles.Select(r => r.RoleId))
                    .FirstOrDefault();

                return roleId == 0 ? null : roleId;
            }
        }
    }
}