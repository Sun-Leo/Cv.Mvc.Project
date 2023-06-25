using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        ProjeRepository proje=new ProjeRepository();
        public ActionResult Index()
        {
            var value=proje.GetAllList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject tblProject)
        {
            proje.TAdd(tblProject);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            TblProject tblProject = proje.TGetID(id);
            proje.TDelete(tblProject);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetProject(int id)
        {
            TblProject Project = proje.TGetID(id);
            return View(Project);
        }
        [HttpPost]
        public ActionResult GetProject(TblProject tblProject)
        {
            var value = proje.TGetID(tblProject.ID);
            value.ProjeAdı = tblProject.ProjeAdı;
            value.Açıklama = tblProject.Açıklama;
            value.Görsel="image";
            proje.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}