using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaNet.Application.Services;
using PizzaNet.Domain.Entities;

namespace PizzaNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaAPI : ControllerBase
    {
        private readonly IPizzaServices _pizzaServices;
        public PizzaAPI(IPizzaServices pizza)
        {
            _pizzaServices = pizza;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PizzaType = await _pizzaServices.GetAllAsync();
            return Ok(PizzaType);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var pizza = await _pizzaServices.GetByIdAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Pizza pizza)
        {
            var createPizza = await _pizzaServices.CreateAsync(pizza);
            return CreatedAtAction(nameof(GetById), new { id = createPizza.Pizza_Id }, pizza);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Pizza updatePizza)
        {
            int existingBlog = await _pizzaServices.UpdateAsync(id, updatePizza);
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
            int existingPizza = await _pizzaServices.DeleteAsync(id);
            if (existingPizza == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }


    }
}
