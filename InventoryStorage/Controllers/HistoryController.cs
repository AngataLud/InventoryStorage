using InventoryStorage.Data;
using InventoryStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryStorage.Controllers
{
    public class HistoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public HistoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ItemHistory> obj = _db.Histories;
            return View(obj);
        }
        public IActionResult Search(string searchBy, string search)
        {
            if (searchBy == "Id")
            {
                return View(_db.Items.Where(x => x.Id.ToString().Equals(search)).ToList());
            }
            else if (searchBy == "Description")
            {
                return View(_db.Items.Where(x => x.Description.ToLower().StartsWith(search)).ToList());
            }
            else if (searchBy == "ItemName")
            {
                return View(_db.Items.Where(x => x.ItemName.ToLower().StartsWith(search)).ToList());
            }
            return View(_db.Items.Where(x => x.Location.ToString().Equals(search)).ToList());
        }
        public IActionResult Update(int? Id)
        {
            var obj = _db.Items.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Update POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
          
        }
        public IActionResult Delete(int? Id)
        {
            var obj = _db.Items.Find(Id);

            if (Id == null)
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
