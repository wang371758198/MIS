using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MIS.Www.Controllers
{
    public class HeplerController : Controller
    {


       [HttpPost]
        public ActionResult ImageFileUpload()
        {

            if (Request.Files.Count > 0)
            {
                try
                {
                    var httpFile = Request.Files[0];
                    string extend = Path.GetExtension(httpFile.FileName);
                    string fileName = Guid.NewGuid().ToString() + extend;
                    string filePath = @"/Upload/" + DateTime.Now.ToString("yyyyMMdd");
                    byte[] buffer = new byte[httpFile.ContentLength];
                    httpFile.InputStream.Read(buffer, 0, buffer.Length);
                    MIS.Frame.ImageHelper.SaveImage(fileName, Server.MapPath("~" + filePath), buffer);

                    return Json(new
                    {
                        Uri = filePath + "/" + fileName
                    }, "text/html");
                }
                catch (Exception em)
                {
                    return Json(new
                    {
                        Uri = string.Empty
                    }, "text/html");
                }
            }
            else
            {
                return Json(new
                {
                    Uri = string.Empty
                }, "text/html");
            }

        }
    }
}