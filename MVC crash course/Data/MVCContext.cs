using Microsoft.EntityFrameworkCore;
using MVC_crash_course.Models;

namespace MVC_crash_course.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext(DbContextOptions<MVCContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
            {
                ic.ItemId,
                ic.ClientId
            });

            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);

            modelBuilder.Entity<Item>().HasData(
                new Item { Id=10, Name="laptop", Price=1500, SerialNumberId=10 }
                );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "LAPTOP1500", ItemId=10 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Computers" },
                new Category { Id = 2, Name = "peripherals" },
                new Category { Id = 3, Name = "Monitors" }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemClient> ItemsClients { get; set; }
    }
}
