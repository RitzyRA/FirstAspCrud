using Microsoft.AspNetCore.Mvc;
using MvcApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_employeeRepository.GetAll());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();
            if (_employeeRepository.DeleteById((int)id))
            {
                //return Ok(); //200
                return RedirectToAction("List");
            }
            else return NotFound(); //404
        }
        public IActionResult Create(string name)
        {
            _employeeRepository.Create(name);
            return RedirectToAction("List");
        }
        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_employeeRepository.GetById((int)id));
        }
        public IActionResult Update(int id, string name)
        {
            _employeeRepository.Update(id, name);
            return RedirectToAction("Details", new { id = id });
        }


    }
}
