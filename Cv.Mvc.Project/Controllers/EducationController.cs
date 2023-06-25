using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EğitimRepository eğitim = new EğitimRepository();
        public ActionResult Index()
        {
            var value= eğitim.GetAllList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation tblEducation)
        {
            eğitim.TAdd(tblEducation);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            TblEducation tblEducation= eğitim.TGetID(id);
            eğitim.TDelete(tblEducation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            TblEducation education=eğitim.TGetID(id);
            return View(education);
        }
        [HttpPost]
        public ActionResult GetEducation(TblEducation tblEducation)
        {
            var value = eğitim.TGetID(tblEducation.ID);
            value.Altbaşlık = tblEducation.Altbaşlık;
            value.Altbaşlık2 = tblEducation.Altbaşlık2;
            value.Tarih=tblEducation.Tarih;
            value.Açıklama = tblEducation.Açıklama;
            eğitim.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}