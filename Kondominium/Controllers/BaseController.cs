using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnActionExecuting(
           ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var cultureInfo = CultureInfo.GetCultureInfo("sv");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        protected Boolean Verifypermission(string UserId = "", string ObjectName = "", string Controller = "")
        {

            if (string.IsNullOrEmpty(UserId))
            {
                UserId = HttpContext.User.Identity.Name.ToString();
            }

            ViewData["UserId"] = UserId;
            ViewData["ActionName"] = ObjectName;
            ViewData["ControllerName"] = Controller;

            var v = new ZTAdminBL.Security.SecutiryData().Verifypermission(UserId, ObjectName, Controller);

            if (v.Where(x => x.Active == 1).Count() > 0)
            {
                return true;
            }
            ErrorNotAutorized();
            return false;
        }

        protected ActionResult ErrorNotAutorized()
        {
            return View("../Home/ErrorNotAutorized");
        }

        protected string GetCurrentUser()
        {

            return HttpContext.User.Identity.Name.ToString();

        }

        protected void Mensajes( Kondominium_Entities.Resultado res)
        {
            if (res.Codigo == Kondominium_Entities.CodigosMensaje.Error)
            {
                ViewBag.Error = res.Mensaje;
            }
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.Exito)
            {
                //ViewBag.Warning = "Mensaje de warning que se mostraria";
                if (res.Mensaje == string.Empty)
                    res.Mensaje = "Registro Guardado de forma Exitosa!";
                ViewBag.Successful = res.Mensaje;
            }
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.Warning)
            {
                if (res.Mensaje == string.Empty)
                    ViewBag.Warning = "Mensaje de warning";
            }
        }
        protected void Mensajes(ZTAdminEntities.Utilities.Resultado res)
        {
            if (res.Codigo == ZTAdminEntities.Utilities.CodigosMensaje.Error)
            {
                ViewBag.Error = res.Mensaje;
            }
            else if (res.Codigo == ZTAdminEntities.Utilities.CodigosMensaje.Exito)
            {
                //ViewBag.Warning = "Mensaje de warning que se mostraria";
                if (res.Mensaje == string.Empty)
                    res.Mensaje = "Registro Guardado de forma Exitosa!";
                ViewBag.Successful = res.Mensaje;
            }
            else if (res.Codigo == ZTAdminEntities.Utilities.CodigosMensaje.Warning)
            {
                if (res.Mensaje == string.Empty)
                    ViewBag.Warning = "Mensaje de warning";
                ViewBag.Warning = res.Mensaje;
            }
        }
    }
}