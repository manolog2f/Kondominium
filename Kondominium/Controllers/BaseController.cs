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
            var cultureInfo = CultureInfo.GetCultureInfo("es-SV");
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
                if ( string.IsNullOrWhiteSpace(res.Mensaje))
                    res.Mensaje = "Registro Guardado de forma Exitosa!";
                ViewBag.Successful = res.Mensaje;
            }
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.Warning)
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "Mensaje de warning";
                
            }
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.No_Existe)
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "Registro no existe";

            }
            else
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "";
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
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    res.Mensaje = "Registro Guardado de forma Exitosa!";
                ViewBag.Successful = res.Mensaje;
            }
            else if (res.Codigo == ZTAdminEntities.Utilities.CodigosMensaje.Warning)
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "Mensaje de warning";
                ViewBag.Warning = res.Mensaje;
            }
        }
    }
}