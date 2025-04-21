using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppEnteringTrackingAndOrders
{
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
        public string Destination { get; set; } // "Kitchen" или "Bar"
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
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
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

    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemModifier> MenuItemModifiers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemModifier> OrderItemModifiers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=testAETAO;Username=postgres;Password=7796;Include Error Detail = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связей
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
        }

        public async Task SendOrderAsync(int orderId)
        {
            using (var context = new RestaurantContext())
            {
                var order = await context.Orders
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
        }
    }
}
