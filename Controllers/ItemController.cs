using Microsoft.AspNetCore.Mvc;
using MvcApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Controllers
{
    public class ItemController : Controller
    {
        private ItemRepository _itemRepository;
        public ItemController(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_itemRepository.GetAll());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();
            if (_itemRepository.DeleteById((int)id))
            {
                return RedirectToAction("List");
            }
            else return NotFound();
        }
        public IActionResult Create(string name, decimal price, decimal quantity)
        {
            _itemRepository.Create(name, price, quantity);
            return RedirectToAction("List");
        }
        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_itemRepository.GetById((int)id));
        }
        public IActionResult Update(int id, string name, decimal price, decimal quantity)
        {
            _itemRepository.Update(id, name, price, quantity);
            return RedirectToAction("Details", new { id = id });
        }
    }
}
