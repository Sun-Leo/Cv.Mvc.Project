using Cv.Mvc.Project.Models;
using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class CertificationController : Controller
    {
        // GET: Certification
        SertifikalarRepository sertifikalar=new SertifikalarRepository();
        public ActionResult Index()
        {
            var value= sertifikalar.GetAllList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCertification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertification(TblCertification tblCertification)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            sertifikalar.TAdd(tblCertification);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertification(int id)
        {
            TblCertification tblCertification = sertifikalar.TGetID(id);
            sertifikalar.TDelete(tblCertification);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetCertification(int id)
        {
            TblCertification Certification = sertifikalar.TGetID(id);
            return View(Certification);
        }
        [HttpPost]
        public ActionResult GetCertification(TblCertification tblCertification)
        {
            var value = sertifikalar.TGetID(tblCertification.ID);
            value.Başlık = tblCertification.Başlık;
            value.Açıklama = tblCertification.Açıklama;
            sertifikalar.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}