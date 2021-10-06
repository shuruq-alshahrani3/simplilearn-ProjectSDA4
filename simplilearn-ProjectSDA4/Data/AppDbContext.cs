using Microsoft.EntityFrameworkCore;
using simplilearn_ProjectSDA4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(am => new
            {
                am.PizzaId,
                am.CustomerId
            });

            // mapping table for C# Side
            modelBuilder.Entity<Order>().HasOne(InPizza => InPizza.pizza).WithMany(inOrder => inOrder.Order).HasForeignKey(InItem =>
            InItem.PizzaId);

            modelBuilder.Entity<Order>().HasOne(InCustomer => InCustomer.Customer).WithMany(inOrder => inOrder.Order).HasForeignKey(InCustomer =>
            InCustomer.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
