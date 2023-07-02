using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        YeteneklerRepository yetenekler = new YeteneklerRepository();
        public ActionResult Index()
        {
            var value= yetenekler.GetAllList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkılls tblSkılls)
        {
            tblSkılls.Görsel = "progress-bar bg-dark";
            yetenekler.TAdd(tblSkılls);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            TblSkılls tblSkılls= yetenekler.Find(x=>x.ID==id);
            yetenekler.TDelete(tblSkılls);
            return RedirectToAction("Index");
        }
    }
}