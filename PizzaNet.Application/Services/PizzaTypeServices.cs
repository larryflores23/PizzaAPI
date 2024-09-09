
using PizzaNet.Domain.Entities;
using PizzaNet.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Application.Services
{
    public class PizzaTypeServices : IPizzaTypeServices
    {
        public IPizzaTypeRepository _pizzaTypeRepository { get; }

        public PizzaTypeServices(IPizzaTypeRepository pizzaTypeRepository)
        {
            _pizzaTypeRepository = pizzaTypeRepository;
        }

        public async Task<PizzaType> CreateAsync(PizzaType pizzaType)
        {
            return await _pizzaTypeRepository.CreateAsync(pizzaType);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _pizzaTypeRepository.DeleteAsync(id);
        }

        public async Task<List<PizzaType>> GetAllAsync()
        {
            return await _pizzaTypeRepository.GetAllAsync();
        }

        public async Task<PizzaType> GetByIdAsync(string id)
        {
            return await _pizzaTypeRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(string id, PizzaType pizzaType)
        {
            return await _pizzaTypeRepository.UpdateAsync(id, pizzaType);

        }
    }
}
