using ConsoleAppTest.Models.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.Models
{
    internal class ShopDbContext :DbContext
    {
        public DbSet<Order> Orders { get;set; }
        public DbSet<Product> Products { get;set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<User> Users { get;set; }

        string ConnectionString = "Host=localhost;port=8080;Database=shop;Username=postgres;Password=postgres;";

        public ShopDbContext()
        {
            //ConnectionString = "Host=localhost;port=8080;Database=shop;Username=postgres;Password=postgres;";

            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(ConnectionString);
        


    }
}
