using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class PropiedadesController : BaseController
    {
        #region "Mantenimiento"

        [HttpGet]
        public ActionResult ListadoAranceles()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ArancelesDatos().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditArancel(string Id, int? codigo = null )
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.ArancelesDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes( new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            
            return View(new ArancelesEntity());
        }
        [HttpPost]
        public ActionResult EditArancel(ArancelesEntity model)
        {           
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ArancelesDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditArancel", new { Id = modelr.Item1.ArancelId, codigo =  0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        //DeleteArancel/6
        //[HttpPost]
        public ActionResult DeleteArancel(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5

            var modelr = new Kondominium_BL.ArancelesDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditArancel", new { Id = Id, codigo =  9898});

        }


        #endregion
    }
}
