using Cv.Mvc.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cv.Mvc.Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            DbCVEntities3 dbcs = new DbCVEntities3();
            var user = dbcs.TblAdmin.FirstOrDefault(x => x.KullanıcıAdı == admin.KullanıcıAdı && x.Şifre == admin.Şifre);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.KullanıcıAdı, false);
                Session["KullanıcıAdı"]=user.KullanıcıAdı.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}