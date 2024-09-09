using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PizzaNet.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int orderdetailsid { get; set; }
        public int orderid { get; set; }
        public string pizza_id { get; set; }
        public decimal quantity { get; set; }
    
    }
}
