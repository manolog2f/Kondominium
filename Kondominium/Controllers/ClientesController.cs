using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class ClientesController : BaseController
    {

        /* Listado clientes*/

        [HttpGet]
        public ActionResult ListadoClientes()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ClientesDatos().GetAll();
            return View(model);
        }
        /*Clientes Edit*/
        [HttpGet]
        public ActionResult EditClientes(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.ClientesDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }
            return View(new ClientesEntity());
        }
        [HttpPost]
        public ActionResult EditClientes(ClientesEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ClientesDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditClientes", new { Id = modelr.Item1.ClienteId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        //[HttpPost]
        public ActionResult DeleteClientes(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5

            var modelr = new Kondominium_BL.ClientesDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditClientes", new { Id = Id, codigo = 9898 });

        }

        /*End Edit Clientes*/

        /* Listado Propiedades Clientes */
        [HttpGet]
        public ActionResult ListadoClientesPropiedades()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ClientePropiedadDatos().GetAll();
            return View(model);
        }
        /*Clientes Edit clientes Propiedades*/
        [HttpGet]
        public ActionResult EditClientesPropiedades(string ClienteId, string PropiedadId, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (ClienteId != null && PropiedadId != null)
            {
                var model = new Kondominium_BL.ClientePropiedadDatos().GetById(int.Parse(ClienteId), int.Parse(PropiedadId));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }
            return View(new ClientePropiedadEntity());
        }
        [HttpPost]
        public ActionResult EditClientesPropiedades(ClientePropiedadEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ClientePropiedadDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditClientesPropiedades", new { ClienteId = modelr.Item1.ClienteId, PropiedadId = modelr.Item1.PropiedadId,  codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }

        public List<ClientesEntity> ListClientes()
        {
            try
            {
                var lista = new Kondominium_BL.ClientesDatos().GetAll();
             
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
