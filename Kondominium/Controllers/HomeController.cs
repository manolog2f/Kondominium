using Kondominium.Models;
using Kondominium.Utilities;
using Kondominium_Entities;
using System;
using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class HomeController : BaseController
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
            ViewBag.Message = "Contactanos, para consultas o dudas.";

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

        public ActionResult Error500()
        {
            return View();
        }

        public ActionResult Error404()
        {
            return View();
        }

        public ActionResult _PartialCalendar(string FechaInicio = null, string FechaFin = null)
        {
            var vFechaInicio = DateTime.Now.AddDays(-5);
            var vFechaFin = DateTime.Now.AddDays(35);

            if (!string.IsNullOrEmpty(FechaInicio))
            {
                vFechaInicio = DateTime.Parse(FechaInicio);
                vFechaFin = DateTime.Parse(FechaFin);
            }

            var Model = new Kondominium_BL.CalendarioDatos().GetByStarEndDate(vFechaInicio, vFechaFin);

            ViewData["FInicio"] = vFechaInicio;
            ViewData["FFin"] = vFechaFin;

            return PartialView(Model);
        }

        //  [HttpPost]
        public ActionResult _PartialCalendarPost(string FechaInicio, string FechaFin)
        {
            var Model = new Kondominium_BL.CalendarioDatos().GetByStarEndDate(DateTime.Parse(FechaInicio), DateTime.Parse(FechaFin));
            var mlResp = new Kondominium.Models.jsModelCalendar();

            mlResp.Inicio = FechaInicio;
            mlResp.Final = FechaFin;
            mlResp.LCal = Model;

            ViewData["FInicio"] = DateTime.Parse(FechaInicio);
            ViewData["FFin"] = DateTime.Parse(FechaFin);

            return PartialView("_PartialCalendar", Model);
        }

        public ActionResult _PartialToDoList()
        {
            /// lista de tipo Tareas con todas las tareas pendientes filtrado por el usuario actual
            var Model = new Kondominium_BL.TareasDatos().GetAll();

            return PartialView(Model);
        }

        public ActionResult Dashboard()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult ListadoTareas()
        {
            //TODO: Descomentarear para despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.TareasDatos().GetAll();
            return View(model);
        }

        /*Tareas Edit*/

        [HttpGet]
        public ActionResult EditTareas(string Id, int? codigo = null)
        {
            //TODO:Descomentarear  dpara despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");
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

        [HttpGet]
        public ActionResult ListadoLugares()
        {
            //TODO: Descomentarear para despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.LugaresDatos().GetAll();
            return View(model);
        }

        /*Tareas Edit*/

        [HttpGet]
        public ActionResult EditLugares(string Id, int? codigo = null)
        {
            //TODO: Descomentarear para despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.LugaresDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new LugaresEntity());
        }

        [HttpPost]
        public ActionResult EditLugares(LugaresEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.LugaresDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditLugares", new { Id = modelr.Item1.LugarId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        public ActionResult DeleteLugares(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.LugaresDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditLugares", new { Id = Id, codigo = 9898 });
        }

        /*End Edit Lugares*/

        /*Calendario*/

        [HttpGet]
        public ActionResult ListadoCalendario()
        {
            //TODO: Descomentarear para despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.CalendarioDatos().GetAll();
            return View(model);
        }

        /*Tareas Edit*/

        [HttpGet]
        public ActionResult EditCalendario(string Id, int? codigo = null)
        {
            //TODO: Descomentarear para despues aplicar seguridad
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.CalendarioDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new CalendarioEntity());
        }

        [HttpPost]
        public ActionResult EditCalendario(CalendarioEntity model, string TInicio, string TFIn)
        {
            if (TFIn == "")
            {
                TFIn = "00:00";
            }

            if (TInicio == "")
            {
                TInicio = "00:00";
            }

            model.HoraFin = TimeSpan.Parse(TFIn);
            model.HoraInicio = TimeSpan.Parse(TInicio);

            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.CalendarioDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditCalendario", new { Id = modelr.Item1.CalendarioId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        public ActionResult DeleteCalendario(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.CalendarioDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditCalendario", new { Id = Id, codigo = 9898 });
        }

        /*End Edit Calendario*/

        //public ActionResult _PartialToDoList()
        //{
        //}

        #region "Dasboard"

        /// 10 Clientes mas Morosos

        public ActionResult ClientesMorosos(int CantiMax = 10)
        {
            var datos = new Kondominium_BL.BalanceDatos().ClientesMorosos();

            return PartialView(datos);
        }

        //[HttpPost]
        //public ActionResult ExportarClientesMorosos()
        //{
        //    var mdl = new jsModel();
        //    var dtble = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(new Kondominium_BL.BalanceDatos().ClientesMorosos());

        //    ExcelMR.ExportDataTableToExcel(dtble);

        //    return Json(mdl);
        //}

        //public void ProcessRequest(HttpContext context)
        //{
        //    string connectionString = @"Data Source=ESPIGA\SQL2005; Initial Catalog=MSS; User Id=sa; Password=******";
        //    using (SqlConnection cnn = new SqlConnection(connectionString))
        //    {
        //        string selectCommand = "SELECT * FROM Customers";
        //        SqlDataAdapter da = new SqlDataAdapter(selectCommand, cnn);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        Utilities.ExportDataTableToExcel(ds.Tables.Item(0));
        //    }
        //}

        /// Propiedades Saldos Pendientes - Propiedad
        public ActionResult PropiedadesMora(int CantiMax = 1000)
        {
            var datos = new Kondominium_BL.BalanceDatos().PropiedadesMorosos(CantiMax);
            return PartialView(datos);
        }

        /// Cobrado por Dia
        /// por Semana
        /// por Mes
        public ActionResult CobrosRealizadoFecha(DateTime FromDate, DateTime ToDate)
        {
            FromDate = FromDate == null ? DateTime.Now.AddMonths(-1) : FromDate;
            ToDate = ToDate == null ? DateTime.Now : ToDate;

            var datos = new Kondominium_BL.BalanceDatos().PagosPorFecha(FromDate, ToDate);
            return PartialView(datos);
        }

        #endregion "Dasboard"
    }
}