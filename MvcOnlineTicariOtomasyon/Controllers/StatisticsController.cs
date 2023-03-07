using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        // GET: Statistics//Vievbag controller tarafından View tarafına veri taşır
        public ActionResult Index()
        {
            var value1 = context.currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = context.products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = context.employees.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = context.categories.Count().ToString();
            ViewBag.v4 = value4;
            var value5 = context.products.Sum(x=>x.Stock).ToString();
            ViewBag.v5 = value5;
            var value6 = (from x in context.products select x.Brand).Distinct().Count().ToString();//Tekrarsız olarak saydırdım.
            ViewBag.v6 = value6;
            var value7 = context.products.Count(x => x.Stock<=20).ToString();//20 nin altı olan stoklar
            ViewBag.v7 = value7;
            var value8 = (from x in context.products orderby x.SalePrice descending/*Büyüktenküçüğe sırala*/ select x.ProductName).FirstOrDefault()/*Listedeki ilk değer*/;
            ViewBag.v8 = value8;
            var value9 = (from x in context.products orderby x.SalePrice ascending/*Küçükten byüğüe sırala*/ select x.ProductName).FirstOrDefault()/*Listedeki ilk değer*/;
            ViewBag.v9 = value9;
            var value10 = context.products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.v10 = value10;
            var value11 = context.products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v11 = value11;
            var value12 = context.products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v12 = value12;
            var value14 = context.salesMovements.Sum(x => x.TotalAmount ).ToString();
            ViewBag.v14 = value14;
            var value13 = context.products.Where(u => u.ProductId==(context.salesMovements.GroupBy(x=>x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key)
            .FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.v13 = value13;
            DateTime today = DateTime.Today;
            var value15 = context.salesMovements.Count(x => x.Date == today).ToString();
            ViewBag.v15 = value15;
            var value16 = context.salesMovements.Where(x => x.Date == today).Sum(y => (decimal?)y.TotalAmount).ToString();
            ViewBag.v16 = value16;
            return View();
        }
        public ActionResult EasyTables()
        {
            var query = from x in context.currents
                        group x by x.CurrentCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Number = g.Count()
                        };
            return View(query.ToList());
        }
        public PartialViewResult Partial1()
        {
            var query2 = from x in context.employees
                        group x by x.department.DepartmentName into g
                        select new GroupClass2
                        {
                            Department = g.Key,
                            Number = g.Count(),
                        };
            return PartialView(query2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query2 = context.currents.ToList();
            return PartialView(query2);
        }
        public PartialViewResult Partial3()
        {
            var query3 = context.products.ToList();
            return PartialView(query3);
        }
        public PartialViewResult Partial4()
        {
            var query4 = from x in context.products
                         group x by x.Brand into g
                         select new GroupClass3
                         {
                             brand = g.Key,
                             number = g.Count(),
                         };
            return PartialView(query4.ToList());
        }


    }
}