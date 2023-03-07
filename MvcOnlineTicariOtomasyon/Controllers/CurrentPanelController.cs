using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.messages.Where(x => x.Recipient == mail).ToList();
            ViewBag.v1 = mail;
            var mailId = context.currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.mId = mailId;
            var totalSales = context.salesMovements.Where(x => x.CurrentId == mailId).Count();
            ViewBag.totalsales = totalSales;
            var totalamount = context.salesMovements.Where(x => x.CurrentId == mailId).Sum(y => y.TotalAmount);
            ViewBag.totalamount = totalamount;
            var totalproductamount = context.salesMovements.Where(x => x.CurrentId == mailId).Sum(y => y.Total);
            ViewBag.totalproductamount = totalproductamount;
            var nameLastN = context.currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentLastName).FirstOrDefault();
            ViewBag.nameLastN = nameLastN;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = context.currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = context.salesMovements.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = context.messages.Where(x=>x.Recipient==mail).OrderByDescending(x=>x.MessageId).ToList();
            var incomingNumber = context.messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.v1 = incomingNumber;
            var outgoingNumber = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingNumber;
            return View(messages);
        }
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = context.messages.Where(x=>x.Sender==mail).OrderByDescending(y => y.MessageId).ToList();
            var incomingNumber = context.messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.v1 = incomingNumber;
            var outgoingNumber = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingNumber;
            return View(messages);
        }
        public ActionResult MessagesDetail(int id)
        {
            var values = context.messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var incomingNumber = context.messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.v1 = incomingNumber;
            var outgoingNumber = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingNumber;
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessages()
        {
            var mail = (string)Session["CurrentMail"];
            var incomingNumber = context.messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.v1 = incomingNumber;
            var outgoingNumber = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.v2 = outgoingNumber;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Messages messages)
        {
            var mail = (string)Session["CurrentMail"];
            messages.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            messages.Sender = mail;
            context.messages.Add(messages);
            context.SaveChanges();
            return View();
        }
        public ActionResult CargoTracking(string p)
        {
            var cargo = from x in context.cargoDetails select x;
            cargo = cargo.Where(y => y.TrackingCode.Contains(p));
            return View(cargo.ToList());
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentMail"];
            var id = context.currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            var currentsearch = context.currents.Find(id);
            return PartialView("Partial1",currentsearch);
        }
        public PartialViewResult Partial2()
        {
            var values = context.messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult CurrentInfoUpdate(Current cr)
        {
            var current = context.currents.Find(cr.CurrentId);
            current.CurrentName = cr.CurrentName;
            current.CurrentLastName = cr.CurrentLastName;
            current.CurrentPassword = cr.CurrentPassword;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}