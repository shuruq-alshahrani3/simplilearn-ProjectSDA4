using Microsoft.AspNetCore.Mvc;
using simplilearn_ProjectSDA4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplilearn_ProjectSDA4.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        public CustomersController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
