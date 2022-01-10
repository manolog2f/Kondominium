using Kondominium.Models;
using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            var model = new Kondominium_BL.CuentasPorCobrarDatos().GetAll();
            return View(model);
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
        public ActionResult _EditCuentasPorCobrarPago(string VaucherNumber, int ClienteId, Decimal Monto)
        {
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarPagoDatos().GetByVaucherNumberId(VaucherNumber);

                if (model != null)
                {
                    return PartialView(model);
                }
                return PartialView(new CuentasPorCobrarPagoEntity { VaucherNumber = VaucherNumber, ClienteId = ClienteId, Monto = Monto });
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

                return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)model.Codigo), Mensaje = model.Mensaje });
            }
            return RedirectToAction("EditCuentasPorCobrar", new { VaucherNumber = VaucherNumber, codigo = ((int)CodigosMensaje.No_Existe) });
        }
        public ActionResult UpdateCxCAnulado(string VaucherNumber)
        {


            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().SetEstado(VaucherNumber, HttpContext.User.Identity.Name.ToString(), 4);

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
                    IdConfig = int.Parse(form["IdConfig"]),
                    Monto = decimal.Parse(form["Monto"]),
                    ProductoId = int.Parse(form["ProductoId"]),
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


        public ActionResult DeleteConfigCuentaDet(int ProductoId)
        {           
                var model = new Kondominium_BL.ConfigCobrosMensualDetDatos().Delete(1, ProductoId );
                return RedirectToAction("EditConfigCuenta", new { codigo = ((int)model.Codigo) });
        }

        #endregion

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
                else {


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
            
            return View(model);
        }


        public ActionResult ProcesoGenerarRecibos(string PeriodoGenerado, CuentasGeneradasEntity model)
        {

            /// Contar antes si el periodo ha sido generado para no volver a generar y arrojar un mensaje 
            
            if (! string.IsNullOrEmpty( PeriodoGenerado))
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
 
            return RedirectToAction("GenerarRecibos",  new {  CodigoR = (int)d.Codigo, Periodo = PeriodoGenerado  });
        }

        #endregion


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
    }
}
