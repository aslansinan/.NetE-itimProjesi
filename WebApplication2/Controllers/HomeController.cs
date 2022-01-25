using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Linq;
using System.Collections.Generic;
using WebApplication2.ViewModels;
using EmployeeManangement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepostory _employeeRepostory;

        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IEmployeeRepostory employeeRepostory,
                              IHostingEnvironment hostingEnvironment)
        {
            _employeeRepostory = employeeRepostory;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                   string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                   uniqueFileName =  Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                   string filePath = Path.Combine(uploadsfolder, uniqueFileName);
                   model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName,

                };
                _employeeRepostory.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
