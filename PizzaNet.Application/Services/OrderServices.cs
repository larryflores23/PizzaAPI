
using PizzaNet.Domain.Entities;
using PizzaNet.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Application.Services
{
    public class OrderServices : IOrderServices
    {
        public IOrderRepository _orderRepository { get; }

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            return await _orderRepository.CreateAsync(order);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<List<Order>> GetAllbyPageAsync(int pageNumber, int pageSize)
        {
            return await _orderRepository.GetAllbyPageAsync(pageNumber, pageSize);
        }
    }
}
