using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaNet.Application.Services;
using PizzaNet.Domain.Entities;

namespace PizzaNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypeAPI : ControllerBase
    {
        private readonly IPizzaTypeServices _pizzaTypeServices;
        public PizzaTypeAPI(IPizzaTypeServices pizzaTypeAPI)
        {
            _pizzaTypeServices = pizzaTypeAPI;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PizzaType = await _pizzaTypeServices.GetAllAsync();
            return Ok(PizzaType);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var pizza = await _pizzaTypeServices.GetByIdAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PizzaType pizzaType)
        {
            var createPizzaType = await _pizzaTypeServices.CreateAsync(pizzaType);
            return CreatedAtAction(nameof(GetById), new { id = createPizzaType.Pizza_Type_Id }, pizzaType);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, PizzaType updatePizzaType)
        {
            int existingBlog = await _pizzaTypeServices.UpdateAsync(id, updatePizzaType);
            if (existingBlog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            int existingPizzaType = await _pizzaTypeServices.DeleteAsync(id);
            if (existingPizzaType == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }


        


    }
}
