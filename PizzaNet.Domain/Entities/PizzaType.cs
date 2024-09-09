using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Entities
{
    public class PizzaType
    {
        [Key]
        public string Pizza_Type_Id { get; set; }
        public string  Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }

    }
}
