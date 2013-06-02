using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCFileUploadSample_01.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /FileUpload/
        //[HttpPost]
        public ActionResult Index()
        {
            var fileUploaded = false; 

            foreach (string upload in Request.Files)
            {
                if (!HasFile(Request.Files[upload]))
                    continue;

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                string filename = Path.GetFileName(Request.Files[upload].FileName);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                Request.Files[upload].SaveAs(Path.Combine(path, filename));

                fileUploaded = true;
            }

            this.ViewData.Add("uploaded", fileUploaded);

            return View();
        }

        private static bool HasFile(HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

    }
}
