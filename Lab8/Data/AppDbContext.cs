using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab8.Models;

namespace Lab8.Data
{
    using Microsoft.EntityFrameworkCore;
    using Lab8.Models;

    namespace RestaurantGuideMvvm.Data
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Restaurant> Restaurants { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(@"Data Source=restaurants.db");
            }
        }
    }
}

