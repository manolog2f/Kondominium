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
        /*Arancel Edit*/
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
        
        /*End Edit Arancel*/



        [HttpGet]
        public ActionResult ListadoPoligonos()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.PoligonosDatos().GetAll();
            return View(model);
        }
        /*Poligono Edit*/
        [HttpGet]
        public ActionResult EditPoligonos(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.PoligonosDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new PoligonosEntity());
        }
        [HttpPost]
        public ActionResult EditPoligonos(PoligonosEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.PoligonosDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditPoligonos", new { Id = modelr.Item1.PoligonoId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        //DeleteArancel/6
        //[HttpPost]
        public ActionResult DeletePoligonos(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.PoligonosDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditPoligonos", new { Id = Id, codigo = 9898 });

        }

        /*End Poligono Edit*/

        

        [HttpGet]
        public ActionResult ListadoProductos()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.ProductosDatos().GetAll();
            return View(model);
        }

        /*Producto Edit*/
        [HttpGet]
        public ActionResult EditProductos(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.ProductosDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new ProductosEntity());
        }
        [HttpPost]
        public ActionResult EditProductos(ProductosEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ProductosDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditProductos", new { Id = modelr.Item1.Productoid, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        //DeleteArancel/6
        //[HttpPost]
        public ActionResult DeleteProductos(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5

            var modelr = new Kondominium_BL.ProductosDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditProductos", new { Id = Id, codigo = 9898 });

        }

        /*End Productos Edit*/





        [HttpGet]
        public ActionResult ListadoPropiedades()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.PropiedadesDatos().GetAll();
            return View(model);
        }

        // ---------------------- * -----------------------------------------------
        /*Avenidas*/

        [HttpGet]
        public ActionResult ListadoAvenidas()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.AvenidasDatos().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditAvenidas(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.AvenidasDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new AvenidasEntity());
        }
        [HttpPost]
        public ActionResult EditAvenidas(AvenidasEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.AvenidasDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditAvenidas", new { Id = modelr.Item1.AvenidaId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        public ActionResult DeleteAvenidas(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.AvenidasDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditAvenidas", new { Id = Id, codigo = 9898 });

        }

        /*Calles*/
        [HttpGet]
        public ActionResult ListadoCalles()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.CallesDatos().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditCalles(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.CallesDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new CallesEntity());
        }
        [HttpPost]
        public ActionResult EditCalles(CallesEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.CallesDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditCalles", new { Id = modelr.Item1.CalleId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        public ActionResult DeleteCalles(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.CallesDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditCalles", new { Id = Id, codigo = 9898 });

        }

        /*Sendas*/

        [HttpGet]
        public ActionResult ListadoSendas()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.SendasDatos().GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditSendas(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.SendasDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }


            return View(new SendasEntity());
        }
        [HttpPost]
        public ActionResult EditSendas(SendasEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.SendasDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditSendas", new { Id = modelr.Item1.SendaId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }

        }
        public ActionResult DeleteSendas(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.SendasDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditSendas", new { Id = Id, codigo = 9898 });

        }

        #endregion
    }
}
