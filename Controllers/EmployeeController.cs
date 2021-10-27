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
        private IEmployeeDepartmentRepository _employeeDepRepository;
        public EmployeeController(IEmployeeDepartmentRepository employeeDepRepository)
        {
            _employeeDepRepository = employeeDepRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_employeeDepRepository.GetAll());
        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return NotFound();
            if (_employeeDepRepository.DeleteById((int)id))
            {
                //return Ok(); //200
                return RedirectToAction("List");
            }
            else return NotFound(); //404
        }
        public IActionResult Create(string name, string depName)
        {
            _employeeDepRepository.Create(name, depName);
            return RedirectToAction("List");
        }
        public IActionResult Details(int? id)
        {
            return id == null
                ? NotFound()
                : View(_employeeDepRepository.GetById((int)id));
        }
        public IActionResult Update(int id, string name, string depName)
        {
            _employeeDepRepository.Update(id, name, depName);
            return RedirectToAction("Details", new { id = id });
        }


    }
}
