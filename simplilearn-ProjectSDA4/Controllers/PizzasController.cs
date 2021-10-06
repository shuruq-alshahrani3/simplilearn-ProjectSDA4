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
    public class PizzasController : Controller
    {
        private readonly AppDbContext _context;

        public PizzasController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            // var data = _context.Items.ToList();
            return View(await _context.Pizza.ToListAsync());
        }
        //~

        // login
        public IActionResult Login()
        {

            return View();
        }
        //~

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Items/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,NamePizza,Quantity,Price")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }
        //~

        // GET: Items/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Items/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PizzaId,ProfilePictureURL,NamePizza,Quantity,Price")] Pizza pizza)
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

        // GET: Items/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Item = await _context.Pizza
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (Item == null)
            {
                return NotFound();
            }

            return View(Item);
        }

        // POST: Items/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizza = await _context.Pizza.FindAsync(id);
            _context.Pizza.Remove(pizza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //~



        private bool ItemExists(int id)
        {
            return _context.Pizza.Any(e => e.PizzaId == id);
        }
    }
}

