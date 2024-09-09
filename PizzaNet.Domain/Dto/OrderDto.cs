using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Dto
{
    public record struct OrderDto(
        DateTime date, DateTime time, List<OrderDetailsDto> OrderDetails );
}
