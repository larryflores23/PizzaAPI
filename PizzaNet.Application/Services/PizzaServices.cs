
using PizzaNet.Domain.Entities;
using PizzaNet.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Application.Services
{
    public class PizzaServices : IPizzaServices
    {
        public IPizzaRepository _pizzaRepository { get; }

        public PizzaServices(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }


        public async Task<Pizza> CreateAsync(Pizza pizza)
        {
            return await _pizzaRepository.CreateAsync(pizza);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _pizzaRepository.DeleteAsync(id);
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaRepository.GetAllAsync();
        }

        public async Task<Pizza> GetByIdAsync(string id)
        {
            return await _pizzaRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(string id, Pizza pizza)
        {
            return await _pizzaRepository.UpdateAsync(id, pizza);

        }
    }
}
