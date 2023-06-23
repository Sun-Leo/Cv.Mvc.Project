using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        DeneyimRepository deneyim = new DeneyimRepository();
        public ActionResult Index()
        {
            var repo= deneyim.GetAllList();
            return View(repo);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience tblExperience)
        {
            deneyim.TAdd(tblExperience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            TblExperience experience=deneyim.Find(x=>x.ID==id);
            deneyim.TDelete(experience);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            var value= deneyim.TGetID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult GetExperience(TblExperience tblExperience)
        {
            var value = deneyim.TGetID(tblExperience.ID);
            value.Başlık = tblExperience.Başlık;
            value.Altbaşlık = tblExperience.Altbaşlık;
            value.Tarih=tblExperience.Tarih;
            value.Açıklama = tblExperience.Açıklama;
            deneyim.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}