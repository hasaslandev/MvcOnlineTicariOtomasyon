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
        public ActionResult Dynamic()
        {
            Class4 cs = new Class4();
            cs.value1 = Context.bills.ToList();
            cs.value2 = Context.billPencils.ToList();
            return View(cs);
        }
        public ActionResult BillSave(string BillSerialNumber, string BillRankNumber,DateTime Date,string TaxAdministration,string Hour,
            string DeliveryPerson,string ReceiverPerson,string Total,BillPencil[] pencils)
        {
            Bill f = new Bill();
            f.BillSerialNumber = BillSerialNumber;
            f.BillRankNumber = BillRankNumber;
            f.Date = Date;
            f.TaxAdministration = TaxAdministration;
            f.Hour = Hour;
            f.DeliveryPerson = DeliveryPerson;
            f.ReceiverPerson = ReceiverPerson;
            f.Total = decimal.Parse(Total);
            Context.bills.Add(f);
            foreach (var x in pencils)
            {
                BillPencil fk = new BillPencil();
                fk.Statement = x.Statement;
                fk.UnitPrice = x.UnitPrice;
                fk.BillId = x.BillPencilId;
                fk.Amount = x.Amount;
                fk.Quantity = x.Quantity;
                Context.billPencils.Add(fk);
            }
            Context.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}