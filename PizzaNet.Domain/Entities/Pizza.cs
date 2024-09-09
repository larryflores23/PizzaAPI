using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Entities
{
    public class Pizza
    {
        [Key]
        public string Pizza_Id { get; set; }
        public string Pizza_Type_Id { get; set; }
        public string Size{ get; set; }
        public decimal Price { get; set; }

    }
}
