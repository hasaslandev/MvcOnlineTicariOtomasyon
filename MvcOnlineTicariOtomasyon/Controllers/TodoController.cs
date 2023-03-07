using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        Context context = new Context();
        public ActionResult Index()
        {
            var value1 = context.currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = context.products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = context.categories.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = (from x in context.currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.v4 = value4;

            var todos = context.toDos.ToList();
            return View(todos);
        }
    }
}