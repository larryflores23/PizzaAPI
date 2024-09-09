using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaNet.Application.Services;
using PizzaNet.Domain.Dto;
using PizzaNet.Domain.Entities;
using PizzaNet.Infrastructure.Data;

namespace PizzaNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApi : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderApi(IOrderServices orderServices, PizzaDbContext db)
        {
            _orderServices = orderServices;
         
        }



        [HttpPost]
        public async Task<IActionResult> Create(OrderDto order)
        {
          
            var newOrder = new Order
            {
                time = order.time ,
                date = order.date,
            };
            var details = order.OrderDetails.Select(w => new OrderDetail { pizza_id = w.pizza_id, quantity = w.quantity }).ToList();
            newOrder.OrderDetails = details;

            var createOrder = await _orderServices.CreateAsync(newOrder);
            return CreatedAtAction(nameof(GetById), new { id = createOrder.orderid }, order);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Order = await _orderServices.GetByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Ok(Order);
        }

        [HttpGet]
        [Route("GetAllByPage")]
        public async Task<IActionResult> GetAllByPage(int pageSize, int pageNumber)
        {

        
            var Order = await _orderServices.GetAllbyPageAsync(pageSize, pageNumber);
            return Ok(Order);
        }

        
    }
}
