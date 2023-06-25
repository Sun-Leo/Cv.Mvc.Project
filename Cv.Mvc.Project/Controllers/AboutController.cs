using Cv.Mvc.Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cv.Mvc.Project.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        HakkımdaRepository hakkımdaRepository = new HakkımdaRepository();
        public ActionResult Index()
        {
            var value= hakkımdaRepository.GetAllList(); 
            return View(value);
        }
    }
}