using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context Context = new Context();
        public ActionResult Index()
        {
            var list = Context.bills.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult BillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BillAdd(Bill bill)
        {
            Context.bills.Add(bill);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillGet(int id)
        {
            var bill = Context.bills.Find(id);
            return View("BillGet", bill);
        }
        public ActionResult BillUpdate(Bill bill)
        {
            var values = Context.bills.Find(bill.BillId);
            values.BillSerialNumber = bill.BillSerialNumber;
            values.BillRankNumber = bill.BillRankNumber;
            values.Hour = bill.Hour;
            values.Date = bill.Date;
            values.DeliveryPerson = bill.DeliveryPerson;
            values.ReceiverPerson = bill.ReceiverPerson;
            values.TaxAdministration = bill.TaxAdministration;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillDetail(int id)
        {
            var detailValue = Context.billPencils.Where(x => x.BillId == id).ToList();
            return View(detailValue);
        }
        [HttpGet]
        public ActionResult NewPencil()
        {
            return View();
        }

        public ActionResult NewPencil(BillPencil billPencil)
        {
            Context.billPencils.Add(billPencil);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}