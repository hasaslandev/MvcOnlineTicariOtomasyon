using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        Context context = new Context();
        // GET: Current
        public ActionResult Index()
        {
            var values = context.currents.Where(x=>x.Station==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CurrentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current current)
        {
            current.Station = true;
            context.currents.Add(current);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentDelete(int Id)
        {
            var delete = context.currents.Find(Id);
            delete.Station = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentGet(int Id)
        {
            var current = context.currents.Find(Id);
            return View(current);
        }
        public ActionResult CurrentUpdate(Current current_Update)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentGet");
            }
            var current = context.currents.Find(current_Update.CurrentId);
            current.CurrentName = current_Update.CurrentName;
            current.CurrentLastName = current_Update.CurrentLastName;
            current.CurrentCity = current_Update.CurrentCity;
            current.CurrentMail = current_Update.CurrentMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSell(int Id)
        {
            var values = context.salesMovements.Where(x => x.CurrentId == Id).ToList();
            var crnt = context.currents.Where(x => x.CurrentId == Id).Select(y => y.CurrentName + " " + y.CurrentLastName).FirstOrDefault();
            ViewBag.current = crnt;
            return View(values);
        } 

    }
}