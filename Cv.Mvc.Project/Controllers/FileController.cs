using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Cv.Mvc.Project.Models;

namespace Cv.Mvc.Project.Controllers
{
    [AllowAnonymous]
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Files/"));
            List<FileModel> files = new List<FileModel>();
            foreach (string filepath in filepaths)
            {
                files.Add(new FileModel { FileName= Path.GetFileName(filepath) });
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Files/")+ fileName;
            byte[] bytes= System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}