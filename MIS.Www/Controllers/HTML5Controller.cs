using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS.Www.Controllers
{
    public class HTML5Controller : Controller
    {
        // GET: HTML5
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// H5缓存解析
        /// </summary>
        /// <returns></returns>
        public ActionResult H5Cache()
        {
            return View();
        }

    }
}