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
            IEnumerable<Item> obj = _db.Items;
            return View(obj);
        }
        public IActionResult Search()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Id")
            {
                return View(_db.Items.Where(x => x.Id.Equals(search) || search == null).ToList());
            }
            else if (searchBy == "Description")
            {
                return View(_db.Items.Where(x => x.Description.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "ItemName")
            {
                return View(_db.Items.Where(x => x.ItemName.StartsWith(search) || search == null).ToList());
            }
            return View(_db.Items.Where(x => x.Location.Equals(search) || search == null).ToList());
        }
    }
}
