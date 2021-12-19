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
        [HttpGet]
        public ActionResult ListadoTareas()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.TareasDatos().GetAll();
            return View(model);
        }
        /*Tareas Edit*/
        [HttpGet]
        public ActionResult EditTareas(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.TareasDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new TareasEntity());
        }
        [HttpPost]
        public ActionResult EditTareas(TareasEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.TareasDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditTareas", new { Id = modelr.Item1.TareaId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }


        //[HttpPost]
        public ActionResult DeleteTareas(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();


            var modelr = new Kondominium_BL.TareasDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditTareas", new { Id = Id, codigo = 9898 });

        }

        /*End Edit Tareas*/



        /*Lugares*/


        //[HttpGet]
        //public ActionResult ListadoLugares()
        //{
        //    if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
        //        return View("../Home/ErrorNotAutorized");

        //    var model = new Kondominium_BL.LugaresDatos().GetAll();
        //    return View(model);
        //}
        /*Tareas Edit*/
        //[HttpGet]
        //public ActionResult EditLugares(string Id, int? codigo = null)
        //{
        //    if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
        //        return View("../Home/ErrorNotAutorized");
        //    if (Id != null)
        //    {
        //        var model = new Kondominium_BL.LugaresDatos().GetById(int.Parse(Id));
        //        if (codigo != null)
        //        {
        //            Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
        //        }
        //        ModelState.Clear();

        //        return View(model);
        //    }


        //    return View(new LugaresEntity());
        //}
        //[HttpPost]
        //public ActionResult EditLugares(LugaresEntity model)
        //{
        //    model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
        //    model.CreadoPor = model.ModificadoPor;

        //    var modelr = new Kondominium_BL.LugaresDatos().Save(model);

        //    Mensajes(modelr.Item2);
        //    ModelState.Clear();

        //    if (modelr.Item2.Codigo == CodigosMensaje.Exito)
        //    {
        //        return RedirectToAction("EditLugares", new { Id = modelr.Item1.LugarId, codigo = 0 });
        //    }
        //    else
        //    {
        //        return View(modelr.Item1);
        //    }

        //}

        //[HttpPost]
        //public ActionResult DeleteLugares(int Id)
        //{
        //    string userid = HttpContext.User.Identity.Name.ToString();


        //    var modelr = new Kondominium_BL.LugaresDatos().SetDelete(Id, userid);

        //    Mensajes(modelr);
        //    ModelState.Clear();
        //    return RedirectToAction("EditLugares", new { Id = Id, codigo = 9898 });

        //}

        /*End Edit Lugares*/
    }
}