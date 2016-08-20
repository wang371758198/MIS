using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS.Models;

namespace MIS.Www.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Table()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }


        [OutputCache(Duration =5)]
        public PartialViewResult APartialPage(UserInfo model)
        {
            ViewBag.ReturnUrl = model.CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "1111111111";
            return PartialView();
        }

    }
}