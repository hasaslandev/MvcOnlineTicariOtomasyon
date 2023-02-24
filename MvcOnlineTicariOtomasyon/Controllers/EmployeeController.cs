using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> deger1 = (from x in context.departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeGet(int id)
        {
             List<SelectListItem> deger1 = (from x in context.departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var empye = context.employees.Find(id);
            return View("EmployeeGet",empye);
        }
        public ActionResult EmployeeUpdate(Employee employee)
        {
            var empye = context.employees.Find(employee.EmployeeId);
            empye.EmployeeId = employee.EmployeeId;
            empye.EmployeeName = employee.EmployeeName;
            empye.EmployeeLastName = employee.EmployeeLastName;
            empye.EmployeeImage = employee.EmployeeImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}