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
        public ActionResult EditCuentasPorCobrar(string VaucherNumber, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDatos().GetById(VaucherNumber);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                return View(model);
            }
            return View(new CuentasPorCobrarEntity() { 
                FechaDeEmision = DateTime.Now,
                FechaDeVencimiento =  DateTime.Now.AddDays(30)
            });
        }

        //[HttpGet]
        public ActionResult _EditCuentasPorCobrarDetalle(string VaucherNumber, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDetalleDatos().GetById(VaucherNumber);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                return View(model);
            }
            return PartialView(new CuentasPorCobrarDetalleEntity());
        }

        public ActionResult _EditCuentasPorCobrarDetalleUpdate(string VaucherNumber, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (VaucherNumber != null)
            {
                var model = new Kondominium_BL.CuentasPorCobrarDetalleDatos().GetById(VaucherNumber);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                return View(model);
            }
            return PartialView(new CuentasPorCobrarDetalleEntity());
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
            return View(new ContratosEntity()   { });
        }

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

    }
}
