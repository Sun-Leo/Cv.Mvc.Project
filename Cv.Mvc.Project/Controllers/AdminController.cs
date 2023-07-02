using Cv.Mvc.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Mvc.Project.Repositories;


namespace Cv.Mvc.Project.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        ProjeRepository db= new ProjeRepository();
        AdminRepository admin= new AdminRepository();
        public ActionResult Index()
        {
            var proje= db.GetAllList();
            return View(proje);
        }

        public ActionResult AdminDetails()
        {
            var liste= admin.GetAllList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin tblAdmin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            admin.TAdd(tblAdmin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin tblAdmin = admin.TGetID(id);
            admin.TDelete(tblAdmin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAdmin(int id)
        {
            TblAdmin Admin = admin.TGetID(id);
            return View(Admin);
        }
        [HttpPost]
        public ActionResult GetAdmin(TblAdmin tblAdmin)
        {
            var value = admin.TGetID(tblAdmin.ID);
            value.KullanıcıAdı = tblAdmin.KullanıcıAdı;
            value.Şifre = tblAdmin.Şifre;
            admin.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}