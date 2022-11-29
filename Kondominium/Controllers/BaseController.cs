using ClosedXML.Excel;
using System;
using System.Data;
using System.Globalization;
using System.IO;
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

        protected void Mensajes(Kondominium_Entities.Resultado res)
        {
            if (res.Codigo == Kondominium_Entities.CodigosMensaje.Error)
            {
                ViewBag.Error = res.Mensaje;
            }
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.Exito)
            {
                //ViewBag.Warning = "Mensaje de warning que se mostraria";
                if (string.IsNullOrWhiteSpace(res.Mensaje))
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
            else if (res.Codigo == Kondominium_Entities.CodigosMensaje.Eliminado)
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "Registro Eliminado satisfactoriamente";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(res.Mensaje))
                    ViewBag.Warning = "";
            }
        }

        protected ActionResult _Mensajes(int error, string Mensaje)
        {
            var mdel = new Models.jsModel();
            var msg = new Kondominium_Entities.Resultado();

            switch (error)
            {
                case 0:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Exito;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Procesado con Exito" : Mensaje;
                    ViewBag.Successful = msg.Mensaje;
                    break;

                case 9999:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Error;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Error al ejecutar el proceso" : Mensaje;
                    ViewBag.Error = string.IsNullOrEmpty(Mensaje) ? "Error al ejecutar el proceso" : Mensaje;
                    break;

                case 5000:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Warning;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Proceso ejecutado, pero existe una advertencia" : Mensaje;

                    ViewBag.Warning = msg.Mensaje;
                    break;

                case 9000:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Log;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro de Log" : Mensaje;
                    break;

                case 9898:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Eliminado;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro Eliminado" : Mensaje;
                    break;

                case 97:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.No_Se_Puede_Eliminar;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro no puede ser eliminado" : Mensaje;
                    break;

                case 96:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.No_Existe;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro no Existe" : Mensaje;
                    ViewBag.Warning = msg.Mensaje;
                    break;
            }

            mdel.mensaje = msg;

            return PartialView(mdel);
        }


        public FileResult ExportExcel(DataTable tabla, string FileName)
        {

            using (XLWorkbook wb = new XLWorkbook())
            {

                wb.Worksheets.Add(tabla, "Reporte");

                wb.Table("Reporte").Theme = XLTableTheme.TableStyleMedium4;
                
                
                

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName + ".xlsx");
                }
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

        #region "Descargar Documento"

        //Gives me a download Prompt.
        //return File(document.Data, document.ContentType, document.Name);
        //Opens if it is a known extension type, downloads otherwise (download has bogus name and missing extension)
        //return new FileStreamResult(new MemoryStream(document.Data), document.ContentType);
        //Gives me a download Prompt (lose the ability to open by default if known type)
        //return new FileStreamResult(new MemoryStream(document.Data), document.ContentType) {FileDownloadName = document.Name };

        //public ActionResult DownloadFile(string FileNameparam)
        //{
        //    string filename = "File.pdf";
        //    //string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
        //    string filepath = FileNameparam;
        //    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
        //    string contentType = MimeMapping.GetMimeMapping(filepath);

        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = filename,
        //        Inline = true,
        //    };

        //    Response.AppendHeader("Content-Disposition", cd.ToString());

        //    return File(filedata, contentType);
        //}

        //public ActionResult DownloadFile(string DocumentId)
        //{B
        //    string filename = "File.pdf";
        //    //string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
        //    string filepath = FileNameparam;
        //    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
        //    string contentType = MimeMapping.GetMimeMapping(filepath);

        //    var cd = new System.Net.Mime.ContentDisposition
        //    {
        //        FileName = filename,
        //        Inline = true,
        //    };

        //    Response.AppendHeader("Content-Disposition", cd.ToString());

        //    return File(filedata, contentType);
        //}

        #endregion "Descargar Documento"
    }
}