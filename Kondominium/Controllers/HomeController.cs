using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kondominium.Controllers
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

        public ActionResult _PartialFooter()
        {
            return PartialView();
        }
        public ActionResult _PartialFooter2()
        {
            return PartialView();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult ErrorNotAutorized()
        {
            return View();
        }

        public ActionResult Error500()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult _PartialCalendar()
        {
            return PartialView();
        }
        public ActionResult _PartialToDoList()
        {
            return PartialView();
        }

        public ActionResult Dashboard()
        {
            return PartialView();
        }
    }
}