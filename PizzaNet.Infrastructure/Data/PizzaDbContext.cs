using Microsoft.EntityFrameworkCore;
using PizzaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace PizzaNet.Infrastructure.Data
{
    public class PizzaDbContext : DbContext
    {

        public PizzaDbContext(DbContextOptions<PizzaDbContext> dbContextOption) : base(dbContextOption)
        { }
   
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> order_details { get; set; }

      
    }
}
