using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Models
{
    public class Order
    {
        public int PizzaId { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza pizza { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
