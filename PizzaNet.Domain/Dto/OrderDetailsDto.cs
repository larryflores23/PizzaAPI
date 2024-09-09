using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Dto
{
    public record struct OrderDetailsDto
    (
         string pizza_id,
         decimal quantity

    );
}
