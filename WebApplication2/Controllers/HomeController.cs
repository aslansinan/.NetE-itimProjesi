using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Linq;
using System.Collections.Generic;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepostory _employeeRepostory;

        public HomeController(IEmployeeRepostory employeeRepostory)
        {
            _employeeRepostory = employeeRepostory;
        }

        public ViewResult Index()
        {
            var model = _employeeRepostory.GetAllEmployee();
            return View(model);

        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModels = new HomeDetailsViewModel()
            {
                Employee = _employeeRepostory.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
        };
            return View(homeDetailsViewModels);
        }
        [HttpGet]  
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepostory.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
