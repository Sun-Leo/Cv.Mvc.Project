using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Mvc.Project.Models;

namespace Cv.Mvc.Project.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities3 db=new DbCVEntities3();
        public ActionResult Index()
        {
            var about= db.TblAbout.ToList();
            return View(about);
        }

        public PartialViewResult Education()
        {
            var edu= db.TblEducation.ToList();
            return PartialView(edu);
        }

        public PartialViewResult Experience()
        {
            var exp= db.TblExperience.ToList();
            return PartialView(exp);
        }

        public PartialViewResult Skills()
        {
            var skl=db.TblSkılls.ToList();
            return PartialView(skl);
        }

        public PartialViewResult MyProject()
        {
            var proje= db.TblProject.ToList();
            return PartialView(proje);
        }

        public PartialViewResult MyReferans()
        {
            var myref= db.TblReferans.ToList();
            return PartialView(myref);

        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(TblContact tblContact)
        {
            db.TblContact.Add(tblContact);
            tblContact.Tarih = DateTime.Now.Date;
            db.SaveChanges();
            return PartialView();
        }



    }
}