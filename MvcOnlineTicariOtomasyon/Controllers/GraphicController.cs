using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var graphicwrite = new Chart(600, 600);
            graphicwrite.AddTitle("Kategori - Ürün Stok SAyısı").AddLegend("Stok").AddSeries(
                "Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları","Bİlgisayarlar" }, yValues: new[] {85,66,98 }
                ).Write();
            return File(graphicwrite.ToWebImage().GetBytes(),"image/jpeg");
        }
        Context context = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = context.products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graphic = new Chart(width: 800, height: 800).AddTitle("Stock").AddSeries(chartType: "Pie", name: "Stock", xValue: xvalue, yValues: yvalue);
            return File(graphic.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(Productlist(),JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> Productlist()
        {
            List<Sinif1> cls = new List<Sinif1>();
            cls.Add(new Sinif1()
            {
                productname = "Bİlgisayar",
                stock = 120
            });
            cls.Add(new Sinif1()
            {
                productname = "Ütü",
                stock = 190
            });
            cls.Add(new Sinif1()
            {
                productname = "Mobilya",
                stock = 100
            });
            cls.Add(new Sinif1()
            {
                productname = "Ufo",
                stock = 150
            });
            return cls;

        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(Productlist2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> Productlist2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using(var context = new Context())
            {
                snf = context.products.Select(x => new Sinif2
                {
                    urn = x.ProductName,
                    stk = x.Stock
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}