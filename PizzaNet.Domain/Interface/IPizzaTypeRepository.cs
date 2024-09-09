using PizzaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Interface
{
    public interface IPizzaTypeRepository
    {
        Task<List<PizzaType>> GetAllAsync();
        Task<PizzaType> GetByIdAsync(string id);
        Task<PizzaType> CreateAsync(PizzaType pizzaType);
        Task<int> UpdateAsync(string id, PizzaType pizzaType);
        Task<int> DeleteAsync(string  id);
    }
}
