using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int page=1)
        {
            var degerler = c.categories.ToList().ToPagedList(page,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            c.categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryRemove(int ID)
        {
            var category = c.categories.Find(ID);
            c.categories.Remove(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CategoryBring(int ID)
        {
            var category = c.categories.Find(ID);
            return View("CategoryBring", category);
        }
        
        public ActionResult CategoryUpdate(Category k)
        {
            var ktgr = c.categories.Find(k.CategoryID);
            ktgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Categories = new SelectList(c.categories, "CategoryID", "CategoryName");
            cs.Products = new SelectList(c.products, "ProductId", "ProductName");
            return View(cs);
        }
        public JsonResult ProductGet(int p)
        {
            var productlist = (from x in c.products
                               join y in c.categories
          on x.category.CategoryID equals y.CategoryID
                               where x.category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString()
                               }).ToList();
            return Json(productlist,JsonRequestBehavior.AllowGet);
        }

    }
}