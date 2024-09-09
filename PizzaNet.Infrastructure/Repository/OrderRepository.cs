using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaNet.Domain.Entities;
using PizzaNet.Domain.Interface;
using PizzaNet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public OrderRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {

            await _pizzaDbContext.AddAsync(order);
            await _pizzaDbContext.SaveChangesAsync();
            return order;

        }

        public async Task<List<Order>> GetAllAsync()
        {

            return await _pizzaDbContext.Orders
                .Include(c => c.OrderDetails).ToListAsync();
     
        }
        public async Task<List<Order>> GetAllbyPageAsync(int pageNumber, int pageSize)
        {

            return  await _pizzaDbContext.Orders.Include(c => c.OrderDetails)
             .OrderBy(e => e.orderid)
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
             .ToListAsync();
     

        }
        public async  Task<Order>  GetByIdAsync(int id)
        {
            var Order = await _pizzaDbContext.Orders
            .Include(c => c.OrderDetails) 
            .FirstOrDefaultAsync(c => c.orderid == id);
            return Order;

        }


    }

}
