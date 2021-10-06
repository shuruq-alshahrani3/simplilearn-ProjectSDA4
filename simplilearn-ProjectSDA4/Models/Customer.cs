using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        //Relations
        public List<Order> Order { get; set; }

    }
}
