using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using simplilearn_ProjectSDA4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScop.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Pizza
                if (!context.Pizza.Any())
                {
                    context.Pizza.AddRange(new List<Pizza>()
                    {
                        new Pizza()
                        {
                        ProfilePictureURL="pizz11",
                        NamePizza="Veggie Pizza",
                        Quantity=10,
                        Price=50
                        },

                        new Pizza()
                        {
                        ProfilePictureURL="pizza2",
                        NamePizza="Pepperoni Pizza",
                        Quantity=17,
                        Price=40
                        },
                        new Pizza()
                        {
                        ProfilePictureURL="pizza4",
                        NamePizza="Meat Pizza",
                        Quantity=11,
                        Price=90
                        },

                        new Pizza()
                        {
                        ProfilePictureURL="pizza6",
                        NamePizza="Margherita Pizza",
                        Quantity=11,
                        Price=70
                        },

                       



                    });
                    context.SaveChanges();

                }  
            }
        }
    }
}
