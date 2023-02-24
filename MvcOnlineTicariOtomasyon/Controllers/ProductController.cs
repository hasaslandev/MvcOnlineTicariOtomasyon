using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.products.Where(x => x.Status == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> deger1 = (from x in c.categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            c.products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductDelete(int id)
        {
            var deger = c.products.Find(id);
            deger.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductGet(int id)
        {
            List<SelectListItem> deger1 = (from x in c.categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var productValue = c.products.Find(id);
            return View("ProductGet",productValue);
        }
        public ActionResult ProductUpdate(Product p)
        {
            var urn = c.products.Find(p.ProductId);
            urn.PurchasePrice = p.PurchasePrice;
            urn.Status = p.Status;
            urn.Brand = p.Brand;
            urn.ProductImage = p.ProductImage;
            urn.ProductName = p.ProductName;
            urn.SalePrice = p.SalePrice;
            urn.CategoryId = p.CategoryId;
            urn.Stock = p.Stock;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ProductList() 
        {
            var values = c.products.ToList();
            return View(values);
    
        } 
    }
}