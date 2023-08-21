using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Employees.Models;

namespace Employees.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John De", Email = "john@example.com", Dob = new DateTime(1990, 1, 15), Dept = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Dob = new DateTime(1985, 5, 10), Dept = "HR", Salary = 45000 }
        };

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var index = _employees.FindIndex(e => e.Id == employee.Id);
            _employees[index] = employee;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            _employees.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}
