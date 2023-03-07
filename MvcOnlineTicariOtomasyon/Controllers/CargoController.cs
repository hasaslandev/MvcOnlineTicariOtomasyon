using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: CargoDetail
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var cargo = from x in context.cargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(y => y.TrackingCode.Contains(p));
            }
            return View(cargo.ToList());
        }
        [HttpGet]
        public ActionResult NewCargo()
        {
            Random random = new Random();
            string[] characters = {"A", "B", "C", "D", };
            int k1, k2, k3;
            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string code = s1.ToString() + characters[k1] + s2.ToString() + characters[k2] + s3.ToString() + characters[k3];
            ViewBag.trackingcode = code;

            return View();
        }
        [HttpPost]
        public ActionResult NewCargo(CargoDetail cargoDetail)
        {
            context.cargoDetails.Add(cargoDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoTracking(string id)
        {
            var values = context.cargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
    }
}