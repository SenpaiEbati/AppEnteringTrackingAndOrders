using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppEnteringTrackingAndOrders
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Role> Roles { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=testAETAO;Username=postgres;Password=7796");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("UserRoles"));
        }
    }

    public static class ConstantsInitialValuesMethodsDb
    {
        public static List<string> _roles = new List<string> { "Руководитель", "Администратор", "Официант"};

        // Инициализация ролей 
        public static void InitializeRoles()
        {
            using (var context = new ApplicationDbContext())
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
            using (var context = new ApplicationDbContext())
            {
                if (!context.Users.Any())
                {
                    var user = new User
                    {
                        Username = "1",
                        PasswordHash = PasswordHasher.HashPassword("123456789"),
                        Roles = context.Roles.Where(r => r.RoleId == 1).ToList()
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }

        // Логика аутентификации 
        public static User AuthenticateUser(string username, string password)
        {
            using (var context = new ApplicationDbContext())
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
            using (var context = new ApplicationDbContext())
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
            using (var context = new ApplicationDbContext())
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
            using (var context = new ApplicationDbContext())
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
    }

    /*// Логика назначения ролей (класс)
    public void AddUserWithRoles(string username, string password, List<string> roleNames)
    {
        using (var context = new ApplicationDbContext())
        {
            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Roles = context.Roles.Where(r => roleNames.Contains(r.RoleName)).ToList()
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }

    // Логика аутентификации (класс)
    public User AuthenticateUser(string username, string password)
    {
        using (var context = new ApplicationDbContext())
        {
            var user = context.Users
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Username == username);

            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }
    }

    public async Task SendDataToServerAsync(string apiUrl, object data)
    {
        using (var client = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Ошибка при отправке данных на сервер");
            }
        }
    }*/
}
