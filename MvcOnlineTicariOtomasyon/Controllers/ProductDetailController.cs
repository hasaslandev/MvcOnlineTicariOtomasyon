using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var values = context.products.Where(x => x.ProductId == 1).ToList();
            cs.Deger1= context.products.Where(x => x.ProductId == 1).ToList();
            cs.Deger2= context.details.Where(y => y.DetailId == 1).ToList();
            return View(cs);
        }
    }
}