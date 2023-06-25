using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class ReferansController : Controller
    {
        // GET: Referans
        ReferansRepository referans=new ReferansRepository();
        public ActionResult Index()
        {
            var value= referans.GetAllList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddReferans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReferans(TblReferans tblReferans)
        {
            referans.TAdd(tblReferans);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteReferans(int id)
        {
            TblReferans tblReferans = referans.TGetID(id);
            referans.TDelete(tblReferans);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetReferans(int id)
        {
            TblReferans Referans = referans.TGetID(id);
            return View(Referans);
        }
        [HttpPost]
        public ActionResult GetReferans(TblReferans tblReferans)
        {
            var value = referans.TGetID(tblReferans.ID);
            value.Adsoyad = tblReferans.Adsoyad;
            value.Title = tblReferans.Title;
            value.Telefon = tblReferans.Telefon;
            value.Email = tblReferans.Email;
            value.Görsel = "image";
            referans.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}