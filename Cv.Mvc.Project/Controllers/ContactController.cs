using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        İletişimRepository iletişim=new İletişimRepository();
        public ActionResult Index()
        {
            var value= iletişim.GetAllList();
            return View(value);
        }

        public ActionResult DeleteMessage(int id)
        {
            var contact= iletişim.TGetID(id);
            iletişim.TDelete(contact);
            return RedirectToAction("Index");
        }
    }
}