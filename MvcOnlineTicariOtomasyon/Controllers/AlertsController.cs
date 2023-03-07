using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    //https://sweetalert.js.org/guides/ BU site referans alındı...
    public class AlertsController : Controller
    {
        // GET: Alerts
        public ActionResult Index()
        {
            return View();
        }
    }
}