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
