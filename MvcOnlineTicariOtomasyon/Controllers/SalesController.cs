using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context context = new Context();
        public ActionResult Index()
        {
            var values = context.salesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewSales()
        {
            List<SelectListItem> deger1 = (from x in context.products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in context.currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName+ " "+x.CurrentLastName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in context.employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeLastName,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(SalesMovement salesMovement)
        {
            salesMovement.Date = DateTime.Parse(DateTime.Now.ToShortTimeString()); 
            context.salesMovements.Add(salesMovement);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSales(int id)
        {
            List<SelectListItem> deger1 = (from x in context.products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in context.currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentLastName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in context.employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeLastName,
                                               Value = x.EmployeeId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var value = context.salesMovements.Find(id);
            return View("GetSales",value);
        }
        public ActionResult UpdateSales(SalesMovement salesMovement)
        {
            var value = context.salesMovements.Find(salesMovement.SalesId);
            value.CurrentId = salesMovement.CurrentId;
            value.Total = salesMovement.Total;
            value.Price = salesMovement.Price;
            value.EmployeeId = salesMovement.EmployeeId;
            value.Date = salesMovement.Date;
            value.TotalAmount = salesMovement.TotalAmount;
            value.ProductId = salesMovement.ProductId;
            value.ProductId = salesMovement.ProductId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var values = context.salesMovements.Where(x => x.SalesId == id).ToList();
            return View(values);
        }
    }
    
    
}