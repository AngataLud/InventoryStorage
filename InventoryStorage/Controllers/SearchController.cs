using InventoryStorage.Data;
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
        public IActionResult Search(int? Id)
        {
            var obj = _db.Items.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
