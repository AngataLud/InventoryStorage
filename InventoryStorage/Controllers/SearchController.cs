using InventoryStorage.Data;
using InventoryStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryStorage.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Search(Item obj)
        {
            if (obj==null)
            {
                return NotFound();
            }
            _db.Items.FindAsync(obj);
            return View(obj);
        }
    }
}
