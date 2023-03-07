using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult partial1(Current current)
        {
            context.currents.Add(current);
            context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrenLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current current)
        {
            var informations = context.currents.FirstOrDefault(x => x.CurrentMail == current.CurrentMail && x.CurrentPassword == current.CurrentPassword);
            if (informations !=null)
            {
                FormsAuthentication.SetAuthCookie(informations.CurrentMail, false);
                Session["CurrentMail"] = informations.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var informations = context.admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}