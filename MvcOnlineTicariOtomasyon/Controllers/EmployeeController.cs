using System;
using System.Collections.Generic;
using System.IO;
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
            if (Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension /*Uzantı*/ = Path.GetExtension(Request.Files[0].FileName);
                string road = "~/Image" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(road));
                employee.EmployeeImage = "/Image" + fileName + extension;
            }
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
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension /*Uzantı*/ = Path.GetExtension(Request.Files[0].FileName);
                string road = "~/Image" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(road));
                employee.EmployeeImage = "/Image" + fileName + extension;
            }
            var empye = context.employees.Find(employee.EmployeeId);
            empye.EmployeeId = employee.EmployeeId;
            empye.EmployeeName = 
                employee.EmployeeName;
            empye.EmployeeLastName = employee.EmployeeLastName;
            empye.EmployeeImage = employee.EmployeeImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var value = context.employees.ToList();
            return View(value);
        }
    }
}