using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Models
{
    public class Pizza
    { 
        [Key]
        public int PizzaId { get; set; } 

        public string ProfilePictureURL { get; set; }

        public string NamePizza { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        //Relations
        public List<Order> Order { get; set; }


    }
}
