using PizzaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetAllbyPageAsync(int pageNumber, int pageSize);
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
    }
}
