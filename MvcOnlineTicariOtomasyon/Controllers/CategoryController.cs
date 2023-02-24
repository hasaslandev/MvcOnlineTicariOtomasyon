using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.categories.ToList();
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

    }
}