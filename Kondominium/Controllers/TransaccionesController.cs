using Kondominium.Models;
using Kondominium_Entities;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.Web;
using System.Configuration;

namespace Kondominium.Controllers
{
    public class TransaccionesController : BaseController
    {
        /* Listado de CXC*/

        [HttpGet]
        public ActionResult ListadoCuentasPorCobrar()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.CuentasPorCobrarDatos().GetAllNoAuto();
            return View(model);
        }

        [HttpGet]
        public ActionResult ListadocxcAuto()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.CuentasPorCobrarDatos().GetAllByAutomatico();
            return View(model);
        }

        [HttpGet]
        public ActionResult Temp(string VaucherNumber = "REC0000000766")
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().GetById(VaucherNumber);

                ModelState.Clear();
                return View(model);
            }
            return View(new CuentasPorCobrarEntity()
            {
                FechaDeEmision = DateTime.Now,
                FechaDeVencimiento = DateTime.Now.AddDays(30)
            });
        }

        [HttpGet]
        public ActionResult EditCuentasPorCobrar(string VaucherNumber, int? codigo = null, string Mensaje = "")
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().GetById(VaucherNumber);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo, Mensaje = Mensaje });
                }
                ModelState.Clear();
                return View(model);
            }
            return View(new CuentasPorCobrarEntity()
            {
                FechaDeEmision = DateTime.Now,
                FechaDeVencimiento = DateTime.Now.AddDays(30)
            });
        }

        [HttpPost]
        public ActionResult EditCuentasPorCobrar(CuentasPorCobrarEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.CuentasPorCobrarDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = modelr.Item1.VaucherNumber, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        [HttpGet]
        public ActionResult _EditCuentasPorCobrarDetalle(string VaucherNumber, int? codigo = null)
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDetalleDatos().GetByVaucher(VaucherNumber);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                if (model != null)
                {
                    return PartialView(model);
                }

                return PartialView(new List<CuentasPorCobrarDetalleEntity>());
            }
            return PartialView(new List<CuentasPorCobrarDetalleEntity>());
        }

        [HttpGet]
        public ActionResult _EditCuentasPorCobrarDet(string VaucherNumber, int? DetalleId)
        {
            if (DetalleId != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDetalleDatos().GetByDetalleId((int)(DetalleId));

                if (model != null)
                {
                    return PartialView(model);
                }
                return PartialView(new CuentasPorCobrarDetalleEntity());
            }
            return PartialView(new CuentasPorCobrarDetalleEntity());
        }

        [HttpGet]
        public ActionResult _EditCuentasPorCobrarPago(string VaucherNumber, int ClienteId, int PropiedadId, Decimal Monto)
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarPagoDatos().GetByVaucherNumberId(VaucherNumber);

                if (model != null)
                {
                    return PartialView(model);
                }
                return PartialView(new CuentasPorCobrarPagoEntity { VaucherNumber = VaucherNumber, ClienteId = ClienteId, PropiedadId = PropiedadId, Monto = Monto });
            }
            return PartialView(new CuentasPorCobrarPagoEntity());
        }

        public ActionResult _EditCuentasPorCobrarPagoUpdate(FormCollection form)
        {
            var mlResp = new jsModelCXC();
            var respM = new Resultado();

            try
            {
                var model = new CuentasPorCobrarPagoEntity
                {
                    PropiedadId = int.Parse(form["PropiedadId"]),
                    VaucherNumber = form["VaucherNumber"],
                    ReferenciaPago = form["ReferenciaPago"],
                    ClienteId = int.Parse(form["ClienteId"]),
                    CuentasPorCobrarPagoId = int.Parse(form["CuentasPorCobrarPagoId"]),
                    MetodoPago = form["MetodoPago"],
                    Observacion = form["Observacion"],
                    Monto = decimal.Parse(form["Monto"]),
                    ModificadoPor = HttpContext.User.Identity.Name.ToString(),
                    CreadoPor = HttpContext.User.Identity.Name.ToString()
                };
                var modelr = new Kondominium_BL.CuentasPorCobrarPagoDatos().Save(model);

                Mensajes(modelr.Item2);
                ModelState.Clear();

                mlResp.VaucherNumber = model.VaucherNumber;
                mlResp.ProductoId = model.CuentasPorCobrarPagoId;
                mlResp.mensaje = modelr.Item2;

                return Json(mlResp);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message;
                mlResp.JsFuntion = "Err";
                mlResp.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "Error al Almacenar el detalle!!" + ex;

                return Json(mlResp);
            }
        }

        public ActionResult _EditCuentasPorCobrarDetalleUpdate(FormCollection form)
        {
            var mlResp = new jsModelCXC();
            var respM = new Resultado();

            try
            {
                var model = new CuentasPorCobrarDetalleEntity
                {
                    VaucherNumber = form["VaucherNumber"],
                    Descripcion = "",
                    Eliminado = false,
                    Monto = decimal.Parse(form["Monto"]),
                    ProductoId = int.Parse(form["ProductoId"]),
                    ModificadoPor = HttpContext.User.Identity.Name.ToString(),
                    CreadoPor = HttpContext.User.Identity.Name.ToString()
                };
                var modelr = new Kondominium_BL.CuentasPorCobrarDetalleDatos().Save(model);

                Mensajes(modelr.Item2);
                ModelState.Clear();

                mlResp.VaucherNumber = model.VaucherNumber;
                mlResp.ProductoId = model.ProductoId;
                mlResp.mensaje = modelr.Item2;

                return Json(mlResp);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message;
                mlResp.JsFuntion = "Err";
                mlResp.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "Error al Almacenar el detalle!!" + ex;

                return Json(mlResp);
            }
        }

        public ActionResult UpdateCxCContabilizado(string VaucherNumber)
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 3);

                var modeln = new Kondominium_BL.CuentasPorCobrarPagoDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 3);

                return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)model.Codigo), Mensaje = model.Mensaje });
            }
            return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)CodigosMensaje.No_Existe) });
        }

        public ActionResult UpdateCxCAnulado(string VaucherNumber)
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 4);

                var modeln = new Kondominium_BL.CuentasPorCobrarPagoDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 4);

                return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)model.Codigo), Mensaje = model.Mensaje });
            }
            return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)CodigosMensaje.No_Existe) });
        }

        public ActionResult DeleteCxcDet(int DetalleId, string VaucherNumber)
        {
            if (DetalleId != 0)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDetalleDatos().SetDelete((int)(DetalleId), HttpContext.User.Identity.Name.ToString());

                return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = model.Codigo });
            }
            return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = CodigosMensaje.No_Existe });
        }

        [HttpGet]
        public ActionResult ListadoContratos()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ContratoDatos().GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditContratos(int? Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.ContratoDatos().GetById(int.Parse(Id.ToString()));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                return View(model);
            }
            return View(new ContratosEntity() { });
        }

        [HttpGet]
        public ActionResult ListPagos()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            var model = new Kondominium_BL.CuentasPorCobrarPagoDatos().GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditPagos(int? Id, string ClienteId, int? codigo = null, string Mensaje = "")
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null && Id != 0)
            {
                var model = new Kondominium_BL.CuentasPorCobrarPagoDatos().GetById((int)Id);

                if (model != null)
                {
                    return View(model);
                }
                return View(new CuentasPorCobrarPagoEntity { CuentasPorCobrarPagoId = (int)Id, ClienteId = int.Parse(ClienteId), Monto = 0 });
            }

            return View(new CuentasPorCobrarPagoEntity { VaucherNumber = "", Monto = 0, Estado = 0 });
        }

        [HttpPost]
        public ActionResult EditPagos(CuentasPorCobrarPago model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.CuentasPorCobrarPagoDatos().Save(model);

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                ViewBag.ClienteId = model.ClienteId;
                return RedirectToAction("EditPagos", new { Id = modelr.Item1.CuentasPorCobrarPagoId, ClienteId = modelr.Item1.ClienteId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        public ActionResult UpdatePagoContabilizado(int Id)
        {
            if (Id != 0)
            {
                var model = new Kondominium_BL.CuentasPorCobrarPagoDatos().SetEstado(Id, HttpContext.User.Identity.Name.ToString(), 3);

                return RedirectToAction("EditCuentasPorCobrar", new { Id = Id, codigo = ((int)model.Item2.Codigo), Mensaje = model.Item2.Mensaje });
            }

            return RedirectToAction("EditCuentasPorCobrar", new { Id = 0, codigo = ((int)CodigosMensaje.No_Existe) });
        }

        #region "Configuracion de cuentas por Generar"

        [HttpGet]
        public ActionResult EditConfigCuenta(int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ConfigCobrosMensualDatos().GetById(1);
            if (codigo != null)
            {
                Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
            }
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditConfigCuenta(ConfigCobrosMensualEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ConfigCobrosMensualDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditConfigCuenta", new { codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        [HttpGet]
        public ActionResult _ListConfigCuentaDet()
        {
            var model = new Kondominium_BL.ConfigCobrosMensualDetDatos().GetByConfigId(1);
            ModelState.Clear();
            return View(model);
        }

        [HttpGet]
        public ActionResult _EditAddConfigCuentaDet()
        {
            var model = new ConfigCobrosMensualDetEntity { IdConfig = 1 };
            ModelState.Clear();
            return PartialView(model);
        }

        public ActionResult _EditAddConfigCuentaDetUpdate(FormCollection form)
        {
            var mlResp = new jsModelCXC();
            var respM = new Resultado();

            try
            {
                var model = new ConfigCobrosMensualDetEntity
                {
                    IdDetalleConf = int.Parse(form["IdDetalleConf"]),
                    IdConfig = int.Parse(form["IdConfig"]),
                    Monto = decimal.Parse(form["Monto"]),
                    ProductoId = int.Parse(form["ProductoId"]),
                    MTamañoV2 = decimal.Parse(form["MTamañoV2"]),
                    ModificadoPor = HttpContext.User.Identity.Name.ToString(),
                    CreadoPor = HttpContext.User.Identity.Name.ToString()
                };
                var modelr = new Kondominium_BL.ConfigCobrosMensualDetDatos().Save(model);

                Mensajes(modelr.Item2);
                ModelState.Clear();

                mlResp.VaucherNumber = model.IdConfig.ToString();
                mlResp.ProductoId = model.ProductoId;
                mlResp.mensaje = modelr.Item2;

                return Json(mlResp);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message;
                mlResp.JsFuntion = "Err";
                mlResp.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "Error al Almacenar el detalle!!" + ex;

                return Json(mlResp);
            }
        }

        public ActionResult DeleteConfigCuentaDet(int IdDetalleConf)
        {
            var model = new Kondominium_BL.ConfigCobrosMensualDetDatos().Delete(IdDetalleConf);
            return RedirectToAction("EditConfigCuenta", new { codigo = ((int)model.Codigo) });
        }

        #endregion "Configuracion de cuentas por Generar"

        #region "Generacion de Recibos Manual"

        [HttpGet]
        public ActionResult GenerarRecibos(string Periodo, int? CodigoR)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var Codigo = new Resultado();

            if (CodigoR != null)
            {
                Codigo.Codigo = (CodigosMensaje)CodigoR;
            }

            var model = new Kondominium_BL.CuentasGeneradasDatos().GetById(Periodo);

            if (model == null)
            {
                model = new CuentasGeneradasEntity();

                var config = new Kondominium_BL.ConfigCobrosMensualDatos().GetById(1);
                var FechaGenerar = new DateTime();
                var FechaVencimiento = new DateTime();
                var periodoActual = (DateTime.Now.ToString("MMMM") + ' ' + DateTime.Now.Year.ToString());

                if (DateTime.Now.Month == 2 && (config.DiaDeGeneracion == 30 || config.DiaDeGeneracion == 29))
                {
                    FechaGenerar = Convert.ToDateTime(string.Concat(DateTime.Now.Year.ToString(), "-", "3", "-", "1"));
                    FechaGenerar = FechaGenerar.AddDays(-1);
                }
                else
                {
                    FechaGenerar = Convert.ToDateTime(string.Concat(DateTime.Now.Year.ToString(), "-", DateTime.Now.Month.ToString(), "-", config.DiaDeGeneracion.ToString()));
                }

                if (DateTime.Now.Month == 2 && (config.DiaVencimiento == 30 || config.DiaVencimiento == 29))
                {
                    FechaVencimiento = Convert.ToDateTime(string.Concat(DateTime.Now.Year.ToString(), "-", "3", "-", "1"));
                    FechaVencimiento = FechaVencimiento.AddDays(-1);
                }
                else
                {
                    FechaVencimiento = Convert.ToDateTime(string.Concat(DateTime.Now.Year.ToString(), "-", DateTime.Now.Month.ToString(), "-", config.DiaVencimiento.ToString()));
                }

                if (FechaGenerar > FechaVencimiento)
                {
                    FechaVencimiento = FechaVencimiento.AddDays(30);
                }

                model = new CuentasGeneradasEntity { PeriodoGenerado = periodoActual, FechaDeGeneracion = FechaGenerar, FechaDeVencimiento = FechaVencimiento };
            }

            if (Codigo.Codigo != CodigosMensaje.Null)
            {
                Mensajes(Codigo);
            }
            ModelState.Clear();
            return View(model);
        }

        [HttpPost]
        public ActionResult GenerarRecibos(CuentasGeneradasEntity model)
        {
            var kmG = new Kondominium_BL.GeneraracionMensuales().GenerarRecibosMensuales(model.FechaDeGeneracion.Value.Month, model.FechaDeGeneracion.Value.Year, (DateTime)model.FechaDeGeneracion, (DateTime)model.FechaDeVencimiento, model.PeriodoGenerado, HttpContext.User.Identity.Name.ToString());

            if (kmG.Item1.Codigo != CodigosMensaje.Null)
            {
                Mensajes(kmG.Item1);
            }
            ModelState.Clear();
            return View(model);
        }

        public ActionResult ProcesoGenerarRecibos(string PeriodoGenerado, CuentasGeneradasEntity model)
        {
            /// Contar antes si el periodo ha sido generado para no volver a generar y arrojar un mensaje

            if (!string.IsNullOrEmpty(PeriodoGenerado))
            {
                // Validar si el periodo ha sido Generado Antes
                if (new Kondominium_BL.CuentasGeneradasDatos().ValidaGeneradas(PeriodoGenerado))
                {
                    ViewBag.MensajeT = "Este periodo ya fue generado, no puede ser generado de nuevo";
                    return RedirectToAction("GenerarRecibos", new { Periodo = PeriodoGenerado, CodigoR = (int)CodigosMensaje.Error, });
                }

                //Console.WriteLine(form);
                //var model = new Kondominium_BL.CuentasPorCobrarDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 3);

                //return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)model.Codigo), Mensaje = model.Mensaje });
            }

            var d = new Resultado { Codigo = CodigosMensaje.Warning, Mensaje = "Prueba" };

            return RedirectToAction("GenerarRecibos", new { CodigoR = (int)d.Codigo, Periodo = PeriodoGenerado });
        }

        #endregion "Generacion de Recibos Manual"

        #region "Generacion de Balance"

        [HttpGet]
        public ActionResult BalanceCliente(int? id)
        {
            var model = new List<Kondominium_Entities.vwBalanceEntity>();

            if (id != null)
            {
                model = new Kondominium_BL.BalanceDatos().ByCliente((int)id);

                var totrecibo = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
                var totPago = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
                var balance = totrecibo - totPago;

                ViewBag.TotalRecibos = totrecibo;
                ViewBag.TotalPagos = totPago;
                ViewBag.Balance = balance;
            }
            else
            {
                ViewBag.TotalRecibos = 0;
                ViewBag.TotalPagos = 0;
                ViewBag.Balance = 0;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult BalancePropiedad(int? id)
        {
            var model = new List<Kondominium_Entities.vwBalanceEntity>();

            if (id != null)
            {
                model = new Kondominium_BL.BalanceDatos().ByPropiedad((int)id);

                var totrecibo = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
                var totPago = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
                var balance = totrecibo - totPago;

                ViewBag.TotalRecibos = totrecibo;
                ViewBag.TotalPagos = totPago;
                ViewBag.Balance = balance;
            }
            else
            {
                ViewBag.TotalRecibos = 0;
                ViewBag.TotalPagos = 0;
                ViewBag.Balance = 0;
            }
            return View(model);
        }

        #endregion "Generacion de Balance"

        public List<CxcTypeEntity> ListTiposTransaccion()
        {
            try
            {
                var lista = new Kondominium_BL.CxcTypeDatos().GetAll();

                return lista;
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        public List<string> ListPeriodos()
        {
            try
            {
                var lista = new Kondominium_BL.PeriodoFacturadoDatos().periodos();

                return lista;
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        public List<string> ListTipoMetodoPago()
        {
            try
            {
                var lista = new List<string>();

                return Enum.GetNames(typeof(MetodoPago)).ToList();
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        [HttpPost]
        public JsonResult AjaxMethodPropiedad(string Cliente, int ClienteID)
        {
            CascadingModel model = new CascadingModel();

            model.Propiedades = PopulateDropDown(ClienteID);

            return Json(model);
        }

        public FileResult ExportExcelBalanceCliente(int? ClientId)
        {
            var model = new List<Kondominium_Entities.vwBalanceEntity>();

            if (ClientId != null)
            {
                model = new Kondominium_BL.BalanceDatos().ByCliente((int)ClientId);

                var totrecibo = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotRecibo);
                var totPago = model.Where(x => x.Estado == "Contabilizado").Sum(x => x.TotPago);
                var balance = totrecibo - totPago;
            }

            DataTable dt = new DataTable("Grid");
            dt = ZoomTechUtils.ZMTDriveDataTable.ToDataTable(model);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Komdomium");
                // wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Komdomium.xlsx");
                }
            }
        }

        private static List<SelectListItem> PopulateDropDown(int ClienteId)
        {
            List<SelectListItem> RList = new List<SelectListItem>();
            var cons = new Kondominium_BL.PropiedadesDatos().GetAllByClienteId(ClienteId);

            foreach (var item in cons)
            {
                RList.Add(new SelectListItem
                {
                    Text = item.VPropiedad,
                    Value = item.PropiedadId.ToString()
                });
            }

            return RList;
        }

        #region CargaRecibosdePago

        [HttpGet]
        public ActionResult UploadFile(int id = 0)
        {
            var demoJs = new jsDocModel();

            if (id != 0)
                demoJs.idTrans = id;
            // demoJs.JsFuntion = "$(window).load(function() {SubmitLoadInvoice();}); ";
            return View(demoJs);
        }

        [HttpPost]
        public ActionResult UploadFile(jsModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult _UploadFileH(HttpPostedFileBase file)
        {
            var mdl = new jsDocModel();
            var respM = new Resultado();

            byte[] filen;

            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;

                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }

                filen = memoryStream.ToArray();
            }

            var paso = "0";
            var extra = "";
            var dondeescribe = ".. ";

            mdl.idTrans = 0;
            try
            {
                if (filen.Length > 0)
                {
                    // string _FileName = Path.GetFileName(file.FileName);
                    //if (!Directory.Exists(GetPahtFileUploaded()))
                    //{
                    //    dondeescribe = GetPahtFileUploaded();
                    paso = "1";
                    extra = "Version Sin directorio / Archivo en Memoria";
                    //    Console.WriteLine(extra);
                    //    //HttpContext.Current.Response.Write(extra);
                    //    HttpContext.Response.Write(extra);
                    //    Directory.CreateDirectory(GetPahtFileUploaded());
                    paso = "2";
                    extra = "Version sin Directorio";
                    //    Console.WriteLine(extra);
                    //}

                    //paso = "3";
                    //extra = "Tratara de Guardar el Archuvi";
                    //Console.WriteLine(extra);
                    //string _path = Path.Combine(GetPahtFileUploaded(), _FileName);
                    //file.SaveAs(_path);

                    paso = "3";
                    extra = "Archivo guardado";
                    Console.WriteLine(extra);
                    var user = this.GetCurrentUser();

                    // Guardar Encabezado.

                    var resp = new Kondominium_BL.UploadFileHDatos().Save(new UploadFileHEntity { Estado = 0, FileName = file.FileName, UploadDate = DateTime.Now, UserId = GetCurrentUser() });

                    paso = "5";
                    extra = "Guardo Registro";
                    Console.WriteLine(extra);

                    var larchivo = new Kondominium_Process.Process().ProcesarArchivo(filen, resp.Item1.UploadFileHId);
                    paso = "6";
                    extra = "Cargando detalle";
                    Console.WriteLine(extra);
                    //respM = resp.resp;

                    mdl.idTrans = resp.Item1.UploadFileHId;//  resp.id;
                    mdl.mensaje = larchivo;  //resp.resp;
                }

                return Json(mdl);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message + " Paso" + paso + "  -  Extra - " + extra + " - Path" + dondeescribe;

                mdl.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "File upload failed!!" + ex;

                Console.WriteLine(ex);

                return Json(mdl);
            }
        }

        public string GetPahtFileUploaded()
        {
            var appSettings = ConfigurationManager.AppSettings;

            return appSettings["UploadedFiles"] ?? "Configuration not exist";
        }

        public ActionResult _UploadFile(int id)
        {
            var model = new Kondominium_BL.UploadFileHDatos().GetListById(id);

            return PartialView(model.AsEnumerable());
        }

        public ActionResult _UploadFileDetail(int id)
        {
            var model = new Kondominium_BL.UploadFileDDatos().GetListById(id);
            return PartialView(model.AsEnumerable());
        }

        public ActionResult _MensajesP(int error, string Mensaje)
        {
            var mdel = new Models.jsModel();
            var msg = new Kondominium_Entities.Resultado();

            switch (error)
            {
                case 0:
                    msg.Codigo = CodigosMensaje.Exito;
                    break;

                case 99:
                    msg.Codigo = CodigosMensaje.Error;
                    break;

                case 9999:
                    msg.Codigo = CodigosMensaje.Error;
                    break;

                case 555:
                    msg.Codigo = CodigosMensaje.Warning;
                    break;

                case 5000:
                    msg.Codigo = CodigosMensaje.Warning;
                    break;

                default:
                    break;
            }
            msg.Mensaje = Mensaje;
            mdel.mensaje = msg;

            return PartialView(mdel);
        }

        public JsonResult ProcessFileXT(int UploadFileId = 0)
        {
            /*

             */
            var larchivo = new Kondominium_Process.Process().ProcesarLineasDetalleDB(UploadFileId);

            return Json(UploadFileId, JsonRequestBehavior.AllowGet);
        }

        #endregion CargaRecibosdePago

        #region "Exportar Excel"

        public FileResult ExportarPagos()
        {
            var dTabla = ZoomTechUtils.MRDriveDataTableDisplayName.ToDataTable(new Kondominium_BL.CuentasPorCobrarPagoDatos().GetAll());
           return  base.ExportExcel(dTabla, "ReporteDePagos");
        }

        public FileResult ExportarAvisosDeCobro()
        {
            var dTabla = ZoomTechUtils.MRDriveDataTableDisplayName.ToDataTable(new Kondominium_BL.CuentasPorCobrarDatos().GetAllByAutomatico());
            return base.ExportExcel(dTabla, "AvisosdeCobro");
        }
        public FileResult ExportarRecibos()
        {
            var dTabla = ZoomTechUtils.MRDriveDataTableDisplayName.ToDataTable(new Kondominium_BL.CuentasPorCobrarDatos().GetAllNoAuto());
            return base.ExportExcel(dTabla, "Recibos");
        }


        #endregion

    }
}