using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: department
        Context context = new Context();//Veritabanı İşlemlerinin yapıldığı sınıfı çağırma
        public ActionResult Index()
        {
            var degerler = context.departments.Where(x => x.status == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize(Roles ="A")]
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            context.departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentRemove(int Id)
        {
            var dep = context.departments.Find(Id);
            dep.status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentGet(int Id)
        {
            var dep = context.departments.Find(Id);
            return View("DepartmentGet", dep);
        }
        public ActionResult DepartmentUpdate(Department department)//Departman sınıfından departman isminde parametre türettim.
        {
            var departmentUpdate = context.departments.Find(department.DepartmentId);
            departmentUpdate.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int Id)
        {
            var detailValue = context.employees.Where(x => x.DepartmentId == Id).ToList();
            var dpt = context.departments.Where(x => x.DepartmentId == Id).Select(y => y.DepartmentName).FirstOrDefault();
            //Controller tarafından viewe veri taşıma viewbagdir.
            ViewBag.d = dpt;//d isminde sanal bir değer oluşturduk.
            return View(detailValue);
        }
        public ActionResult DepartmentEmployeeSell(int Id)
        {
            var D_E_S_values = context.salesMovements.Where(x => x.EmployeeId == Id).ToList();
            var emplo = context.employees.Where(x => x.EmployeeId == Id).Select(y=>y.EmployeeName+" "+y.EmployeeLastName).FirstOrDefault();
            ViewBag.D_Employee = emplo;
            return View(D_E_S_values);
        }
    }
}