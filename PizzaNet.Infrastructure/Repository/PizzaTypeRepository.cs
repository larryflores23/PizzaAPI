using Microsoft.EntityFrameworkCore;
using PizzaNet.Domain.Entities;
using PizzaNet.Domain.Interface;
using PizzaNet.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Infrastructure.Repository
{
    public class PizzaTypeRepository : IPizzaTypeRepository
    {

        private readonly PizzaDbContext _pizzaDbContext;

        public PizzaTypeRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }



        public async Task<PizzaType> CreateAsync(PizzaType pizzaType)
        {
            await _pizzaDbContext.AddAsync(pizzaType);
            await _pizzaDbContext.SaveChangesAsync();
            return pizzaType;
        }


        public async Task<int> DeleteAsync(string  id)
        {
            return await _pizzaDbContext.PizzaTypes
             .Where(model => model.Pizza_Type_Id == id)
             .ExecuteDeleteAsync();
        }

        public  async Task<List<PizzaType>> GetAllAsync()
        {
            return await _pizzaDbContext.PizzaTypes.ToListAsync();
        }

        public async Task<PizzaType> GetByIdAsync(string  id)
        {
            return await _pizzaDbContext.PizzaTypes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Pizza_Type_Id == id);

        }

        public async Task<int> UpdateAsync(string  id, PizzaType pizzaType)
        {
          return await _pizzaDbContext.PizzaTypes
               .Where(model => model.Pizza_Type_Id == id)
               .ExecuteUpdateAsync(setter => setter
               .SetProperty(m => m.Name, pizzaType.Name)
               .SetProperty(m => m.Category, pizzaType.Category)
               .SetProperty(m => m.Ingredients, pizzaType.Ingredients)
               );

        }
    }
}
