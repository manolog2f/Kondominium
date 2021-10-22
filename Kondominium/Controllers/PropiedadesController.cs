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


        #endregion
    }
}
