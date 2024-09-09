using PizzaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Application.Services
{
    public interface IOrderServices
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<List<Order>> GetAllbyPageAsync(int pageNumber, int pageSize);
    }
}
