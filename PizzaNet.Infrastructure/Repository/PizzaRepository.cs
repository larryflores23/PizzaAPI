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
    public class PizzaRepository : IPizzaRepository
    {

        private readonly PizzaDbContext _pizzaDbContext;

        public PizzaRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<Pizza> CreateAsync(Pizza pizza)
        {
            await _pizzaDbContext.AddAsync(pizza);
            await _pizzaDbContext.SaveChangesAsync();
            return pizza;
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _pizzaDbContext.Pizzas
             .Where(model => model.Pizza_Id == id)
             .ExecuteDeleteAsync();
        }

        public async Task<List<Pizza>> GetAllAsync()
        {
            return await _pizzaDbContext.Pizzas.ToListAsync();

        }

        public async Task<Pizza> GetByIdAsync(string id)
        {
            return await _pizzaDbContext.Pizzas.AsNoTracking()
                  .FirstOrDefaultAsync(model => model.Pizza_Id == id);

        }

        public async Task<int> UpdateAsync(string id, Pizza pizza)
        {
            return await _pizzaDbContext.Pizzas
               .Where(model => model.Pizza_Id == id)
               .ExecuteUpdateAsync(setter => setter
               .SetProperty(m => m.Pizza_Type_Id, pizza.Pizza_Type_Id)
               .SetProperty(m => m.Size, pizza.Size)
               .SetProperty(m => m.Price, pizza.Price)
               );
        }
    }
}

