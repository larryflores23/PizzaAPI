﻿using PizzaNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Interface
{
    public interface  IPizzaRepository
    {
        Task<List<Pizza>> GetAllAsync();
        Task<Pizza> GetByIdAsync(string id);
        Task<Pizza> CreateAsync(Pizza pizza);
        Task<int> UpdateAsync(string id, Pizza pizza);
        Task<int> DeleteAsync(string id);
    }
}
