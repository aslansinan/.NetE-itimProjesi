using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Linq;
using System.Collections.Generic;
using WebApplication2.ViewModels;
using EmployeeManangement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;

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
            Employee employee = _employeeRepostory.GetEmployee(id ?? 1);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
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
        [HttpGet]
        public ViewResult Edit(int id )
        {
            Employee employee = _employeeRepostory.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepostory.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photos != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                   employee.PhotoPath = ProcessUploadedFile(model);
                }
                _employeeRepostory.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsfolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsfolder, uniqueFileName);
                    photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName,

                };
                _employeeRepostory.Add(newEmployee);
                return RedirectToAction("details",new{id=newEmployee.Id});
            }
            return View();
        }
    }
}
