using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simplilearn_ProjectSDA4.Data;
using simplilearn_ProjectSDA4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            // var data = _context.Orders.ToList();
            return View(await _context.Pizza.ToListAsync());
        }
        //~

        // GET: Orders/Order  (SameEdit)
        public async Task<IActionResult> Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Item = await _context.Pizza.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }
            return View(Item);
        }
        // POST: Orders/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(int id, [Bind("PizzaId,ProfilePictureURL,NamePizza,Quantity,Price")] Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(pizza.PizzaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }
        //~

        public IActionResult OrderSuccess()
        {


            return View();
        }



        //[
        private bool ItemExists(int id)
        {
            return _context.Pizza.Any(e => e.PizzaId == id);
        }
    }//]
}