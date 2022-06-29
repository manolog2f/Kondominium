using Kondominium.Models;
using Kondominium_Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult EditArancel(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.ArancelesDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
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
                return RedirectToAction("EditArancel", new { Id = modelr.Item1.ArancelId, codigo = 0 });
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
            return RedirectToAction("EditArancel", new { Id = Id, codigo = 9898 });
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

        // ---------------------- * -----------------------------------------------
        /*Alamedas*/

        [HttpGet]
        public ActionResult ListadoAlamedas()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.AlamedaDatos().GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditAlamedas(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.AlamedaDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new AlamedaEntity());
        }

        [HttpPost]
        public ActionResult EditAlamedas(AlamedaEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.AlamedaDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditAlamedas", new { Id = modelr.Item1.AlamedaId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        public ActionResult DeleteAlamedas(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.AlamedaDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditAlamedas", new { Id = Id, codigo = 9898 });
        }

        /* -------------- Paseos -------------- */

        [HttpGet]
        public ActionResult ListadoPaseos()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new Kondominium_BL.PaseoDatos().GetAll();
            return View(model);
        }

        /*Paseo Edit*/

        [HttpGet]
        public ActionResult EditPaseo(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.PaseoDatos().GetById(Id);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new PaseoEntity());
        }

        [HttpPost]
        public ActionResult EditPaseo(PaseoEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.PaseoDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditPaseo", new { Id = modelr.Item1.PaseoId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        //DeletePaseo/6
        //[HttpPost]
        public ActionResult DeletePaseo(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.PaseoDatos().SetDelete(Id, userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditPaseo", new { Id = Id, codigo = 9898 });
        }

        /*End Paseo Edit*/

        /*MMTO Propiedades*/

        [HttpGet]
        public ActionResult EditPropiedades(string Id, int? codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");
            if (Id != null)
            {
                var model = new Kondominium_BL.PropiedadesDatos().GetById(int.Parse(Id));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new PropiedadesEntity());
        }

        [HttpPost]
        public ActionResult EditPropiedades(PropiedadesEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;
            //var form = new FormCollection();
            var TamañoV2 = Request["TamañoV2"].ToString().Replace(",", "");
            var ConstruidoM2 = Request["ConstruidoM2"].ToString().Replace(",", "");

            model.TamañoV2 = Convert.ToDecimal(TamañoV2);

            model.ConstruidoM2 = Convert.ToDecimal(ConstruidoM2);

            var modelr = new Kondominium_BL.PropiedadesDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditPropiedades", new { Id = modelr.Item1.PropiedadId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        public ActionResult DeletePropiedades(string Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();

            var modelr = new Kondominium_BL.PropiedadesDatos().SetDelete(int.Parse(Id), userid);

            Mensajes(modelr);
            ModelState.Clear();
            return RedirectToAction("EditPropiedades", new { Id = Id, codigo = 9898 });
        }

        public ActionResult _ListPropiedadDocs(string PropiedadId, int? codigo = null)
        {
            if (PropiedadId != null)
            {
                var model = new Kondominium_BL.PropiedadesDocsDatos().GetListById(int.Parse(PropiedadId));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                if (model.Count > 0)
                {
                    return PartialView("_ListPropiedadDocs", model);
                }
            }
            return PartialView("_ListPropiedadDocs", new List<PropiedadesDocsEntity>());
        }

        #region "Subir Archivo"

        [HttpPost]
        public ActionResult _UploadFileHPropiedad(HttpPostedFileBase file, FormCollection form)
        {
            var mdl = new jsModelPC();
            var respM = new Resultado();

            mdl.DocumentType = form["DocumentType"];
            mdl.ClienteDocId = int.Parse(form["PropiedadesDocId"]);
            mdl.PropiedadId = int.Parse(form["PropiedadId"]);
            // mdl.TipoClienteId = form["TipoCliente"];

            try
            {
                //var v = new GPIntegration_BL.CashReceipt.FileIUploapProcess();
                if (file.ContentLength > 0)
                {
                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }

                    var docSave = new Kondominium_BL.PropiedadesDocsDatos().Save(new PropiedadesDocsEntity { PropiedadesDocId = mdl.ClienteDocId, DocumentType = mdl.DocumentType, UrlDocument = file.FileName, ModificadoPor = HttpContext.User.Identity.Name.ToString(), CreadoPor = HttpContext.User.Identity.Name.ToString(), PropiedadId = mdl.PropiedadId, Document = thePictureAsBytes });

                    mdl.JsFuntion = "T";
                    //mdl.ClienteDocId = docSave.Item1.PropiedadesDocId;

                    mdl.mensaje = docSave.Item2;
                }
                return Json(mdl);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message;
                mdl.JsFuntion = "Err";
                mdl.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "Error al cargar el Archivo!!" + ex;

                return Json(mdl);
            }
        }

        public FileResult _DownloadFIlePropiedad(int Id)
        {
            var doc = new Kondominium_BL.PropiedadesDocsDatos().GetByDocumentId(Id);

            string mimeType = new Kondominium_Entities.Utilites.MimeTypeEntity().MimeTypeList().Where(x => x.Extension.Contains(new Utilities.General().ExtraerExtencion(doc.UrlDocument))).FirstOrDefault().Type;

            return File(doc.Document, mimeType);
        }

        [HttpGet]
        public ActionResult _EditPropiedadesFileUpload(string PropiedadId, string DocumentType, int? codigo = null)
        {
            if (DocumentType != null && PropiedadId != null)
            {
                var model = new Kondominium_BL.PropiedadesDocsDatos().GetById(int.Parse(PropiedadId), DocumentType);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                //ViewBag.ClienteId = ClienteId;

                if (model == null)
                {
                    model = new PropiedadesDocsEntity { PropiedadId = int.Parse(PropiedadId) };
                }

                return View(model);
            }
            return View(new PropiedadesDocsEntity());
        }

        [HttpPost]
        public ActionResult _EditPropiedadesFileUpload(PropiedadesDocsEntity model, FormCollection form)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.PropiedadesDocsDatos().Save(model);
            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("_EditPropiedadesFileUpload", new { PropiedadId = modelr.Item1.PropiedadId, DocumentType = modelr.Item1.DocumentType, codigo = 0 });
            }
            else
            {
                return View("_EditPropiedadesFileUpload", modelr.Item1);
            }
        }

        public ActionResult DeleteLinePropDocs(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5
            var datos = new Kondominium_BL.PropiedadesDocsDatos().GetByDocumentId(Id);
            try
            {
                if (datos != null)
                {
                    var modelr = new Kondominium_BL.PropiedadesDocsDatos().Delete(datos);
                    if (modelr.Codigo == CodigosMensaje.Exito)
                    {
                        if (System.IO.File.Exists(datos.UrlDocument))
                        {
                            System.IO.File.Delete(datos.UrlDocument);
                        }
                        return RedirectToAction("EditPropiedades", new { PropiedadId = datos.PropiedadId, codigo = 0 });
                    }

                    return RedirectToAction("EditPropiedades", new { PropiedadId = datos.PropiedadId, codigo = modelr.Codigo });
                }
                else
                {
                    return RedirectToAction("EditPropiedades", new { PropiedadId = datos.PropiedadId, codigo = CodigosMensaje.No_Existe });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("EditPropiedades", new { PropiedadId = datos.PropiedadId, codigo = CodigosMensaje.Error });
            }
        }

        #endregion "Subir Archivo"

        /*-------------------------------------------------*/

        public ActionResult _ListadoPropietariosPropiedad(string Id)
        {
            var model = new Kondominium_BL.ClientePropiedadDatos().GetById(int.Parse(Id), "0");

            if (model == null)
            {
                return View(new List<ClientePropiedadEntity>());
            }
            return View(model);
        }

        public ActionResult _ListadoInquilinosPropiedad(string Id)
        {
            var model = new Kondominium_BL.ClientePropiedadDatos().GetById(int.Parse(Id), "1");
            if (model == null)
            {
                return View(new List<ClientePropiedadEntity>());
            }
            return View(model);
        }

        public ActionResult _ListadoOtrosPropiedad(string Id)
        {
            var model = new Kondominium_BL.ClientePropiedadDatos().GetById(int.Parse(Id), "2");
            if (model == null)
            {
                return View(new List<ClientePropiedadEntity>());
            }
            return View(model);
        }

        /* Propiedad Cliente */

        [HttpGet]
        public ActionResult EditPropiedadCliente(string PropiedadId, string TipoCliente, string ClienteId, int? codigo = null)
        {
            //if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
            //    return View("../Home/ErrorNotAutorized");
            if (ClienteId != null && PropiedadId != null)
            {
                var model = new Kondominium_BL.ClientePropiedadDatos().GetById(int.Parse(ClienteId), int.Parse(PropiedadId), TipoCliente.ToString());
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new ClientePropiedadEntity
            {
                PropiedadId = int.Parse(PropiedadId),
                TipoCliente = TipoCliente.ToString(),
                TclienteEnum = (TipoClientes)(int.Parse(TipoCliente))
            });
        }

        [HttpPost]
        public ActionResult EditPropiedadCliente(ClientePropiedadEntity model)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ClientePropiedadDatos().Save(model);

            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("EditPropiedadCliente", new { PropiedadId = modelr.Item1.PropiedadId, TipoCliente = modelr.Item1.TipoCliente, ClienteId = modelr.Item1.ClienteId, codigo = 0 });
            }
            else
            {
                return View(modelr.Item1);
            }
        }

        [HttpGet]
        public ActionResult _EditPropiedadClienteDet(string PropiedadId, string TipoCliente, string ClienteId, int? codigo = null)
        {
            if (ClienteId != null && PropiedadId != null)
            {
                var model = new Kondominium_BL.ClientesPropiedadDetalleDatos().GetById(int.Parse(ClienteId), int.Parse(PropiedadId), TipoCliente.ToString());
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }

                if (model == null)
                {
                    ModelState.Clear();
                    return View(new ClientePropiedadDetalleEntity
                    {
                        PropiedadId = int.Parse(PropiedadId),
                        TipoCliente = TipoCliente.ToString(),
                        ClienteId = int.Parse(ClienteId)
                    });
                }
                ModelState.Clear();

                return View(model);
            }

            return View(new ClientePropiedadDetalleEntity
            {
                PropiedadId = int.Parse(PropiedadId),
                TipoCliente = TipoCliente.ToString(),
                ClienteId = int.Parse(ClienteId)
            });
        }

        [HttpPost]
        public ActionResult _EditPropiedadClienteDetUpdate(FormCollection form)
        {
            var mlResp = new jsModelPC();
            var respM = new Resultado();

            try
            {
                var model = new ClientePropiedadDetalleEntity
                {
                    ClienteId = int.Parse(form["ClienteId"].ToString()),
                    PropiedadId = int.Parse(form["PropiedadId"].ToString()),
                    TipoCliente = form["TipoCliente"],
                    FechaFin = DateTime.Parse(form["FechaFin"]),
                    FechaInicio = DateTime.Parse(form["FechaInicio"]),
                    Autorrenovable = Convert.ToBoolean(form["Autorrenovable"].Split(',').First()),
                    InquilinoResponsable = Convert.ToBoolean(form["InquilinoResponsable"].Split(',').First()),
                    Observacion = form["Observacion"],
                    Parentesco = form["Parentesco"],
                    ModificadoPor = HttpContext.User.Identity.Name.ToString(),
                    CreadoPor = HttpContext.User.Identity.Name.ToString()
                };
                var modelr = new Kondominium_BL.ClientesPropiedadDetalleDatos().Save(model);

                Mensajes(modelr.Item2);
                ModelState.Clear();

                mlResp.ClienteId = model.ClienteId;
                mlResp.PropiedadId = model.PropiedadId;
                mlResp.TipoClienteId = model.TipoCliente;
                mlResp.mensaje = modelr.Item2;

                //if (modelr.Item2.Codigo == CodigosMensaje.Exito)
                //{
                //    return Json(mlResp);
                //}
                //else
                //{
                //    return Json(mlResp);
                //}

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

        public ActionResult _ListPropiedadClienteDocs(string PropiedadId, string TipoCliente, string ClienteId, int? codigo = null)
        {
            ViewBag.ClienteId = ClienteId;

            if (ClienteId != null)
            {
                var model = new Kondominium_BL.ClientePropiedadDocsDatos().GetById(int.Parse(ClienteId), int.Parse(PropiedadId), TipoCliente);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();

                if (model.Count > 0)
                {
                    return PartialView("_ListPropiedadClienteDocs", model);
                }
            }
            return PartialView("_ListPropiedadClienteDocs", new List<ClientePropiedadDocsEntity>());
        }

        public ActionResult DeleteLinePropClientesDocs(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5
            var datos = new Kondominium_BL.ClientePropiedadDocsDatos().GetByClienteDocId(Id);
            try
            {
                if (datos != null)
                {
                    var modelr = new Kondominium_BL.ClientePropiedadDocsDatos().Delete(datos);
                    if (modelr.Codigo == CodigosMensaje.Exito)
                    {
                        if (System.IO.File.Exists(datos.UrlDocument))
                        {
                            System.IO.File.Delete(datos.UrlDocument);
                        }
                        return RedirectToAction("EditPropiedadCliente", new { PropiedadId = datos.PropiedadId, TipoCliente = datos.TipoCliente, ClienteId = datos.ClienteId, codigo = 0 });
                    }

                    return RedirectToAction("EditPropiedadCliente", new { PropiedadId = datos.PropiedadId, TipoCliente = datos.TipoCliente, ClienteId = datos.ClienteId, codigo = modelr.Codigo });
                }
                else
                {
                    return RedirectToAction("EditPropiedadCliente", new { PropiedadId = datos.PropiedadId, TipoCliente = datos.TipoCliente, ClienteId = datos.ClienteId, codigo = CodigosMensaje.No_Existe });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("EditPropiedadCliente", new { PropiedadId = datos.PropiedadId, TipoCliente = datos.TipoCliente, ClienteId = datos.ClienteId, codigo = CodigosMensaje.Error });
            }
        }

        [HttpGet]
        public ActionResult _EditPropiedadesClientesFileUpload(string PropiedadId, string ClienteId, string TipoClienteId, string DocumentType, int? codigo = null)
        {
            if (ClienteId != null && DocumentType != null && PropiedadId != null && TipoClienteId != null)
            {
                var model = new Kondominium_BL.ClientePropiedadDocsDatos().GetById(int.Parse(ClienteId), int.Parse(PropiedadId), TipoClienteId, DocumentType);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                ViewBag.ClienteId = ClienteId;

                if (model == null)
                {
                    model = new ClientePropiedadDocsEntity { ClienteId = int.Parse(ClienteId), PropiedadId = int.Parse(PropiedadId), TipoCliente = TipoClienteId };
                }

                return View(model);
            }
            return View(new ClientePropiedadDocsEntity());
        }

        [HttpPost]
        public ActionResult _EditPropiedadesClientesFileUploadPost(ClientePropiedadDocsEntity model, FormCollection form)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ClientePropiedadDocsDatos().Save(model);
            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("_EditPropiedadesClientesFileUpload", new { ClienteId = modelr.Item1.ClienteId, DocumentType = modelr.Item1.DocumentType, codigo = 0 });
            }
            else
            {
                return View("_EditPropiedadesClientesFileUpload", modelr.Item1);
            }
        }

        #endregion "Mantenimiento"

        public List<PropiedadesEntity> ListPropiedades()
        {
            try
            {
                var lista = new Kondominium_BL.PropiedadesDatos().GetAll();

                return lista;
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        public List<string> ListABC()
        {
            try
            {
                var lista = new Kondominium_BL.PropiedadesDatos().Letras();

                return lista;
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        public List<string> ListParentesco()
        {
            try
            {
                var lista = new Kondominium_BL.PropiedadesDatos().Parentesco();

                return lista;
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        #region "Subir Archivo"

        [HttpPost]
        public ActionResult _UploadFileH(HttpPostedFileBase file, FormCollection form)
        {
            var mdl = new jsModelPC();
            var respM = new Resultado();

            mdl.ClienteId = int.Parse(form["ClienteId"].ToString());
            mdl.DocumentType = form["DocumentType"];
            mdl.ClienteDocId = int.Parse(form["ClientePropiedadDocsId"]);
            mdl.PropiedadId = int.Parse(form["PropiedadId"]);
            mdl.TipoClienteId = form["TipoCliente"];

            try
            {
                //var v = new GPIntegration_BL.CashReceipt.FileIUploapProcess();
                if (file.ContentLength > 0)
                {
                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }

                    var docSave = new Kondominium_BL.ClientePropiedadDocsDatos().Save(new ClientePropiedadDocsEntity { ClientePropiedadDocsId = mdl.ClienteDocId, ClienteId = mdl.ClienteId, DocumentType = mdl.DocumentType, UrlDocument = file.FileName, ModificadoPor = HttpContext.User.Identity.Name.ToString(), CreadoPor = HttpContext.User.Identity.Name.ToString(), PropiedadId = mdl.PropiedadId, TipoCliente = mdl.TipoClienteId, Document = thePictureAsBytes });

                    mdl.JsFuntion = "T";
                    mdl.ClienteDocId = docSave.Item1.ClientePropiedadDocsId;

                    mdl.mensaje = docSave.Item2;
                }
                return Json(mdl);
            }
            catch (Exception ex)
            {
                respM.Codigo = CodigosMensaje.Error;
                respM.Mensaje = ex.Message;
                mdl.JsFuntion = "Err";
                mdl.mensaje = respM;

                this.Mensajes(respM);
                ViewBag.Message = "Error al cargar el Archivo!!" + ex;

                return Json(mdl);
            }
        }

        public FileResult _DownloadFIle(int Id)
        {
            var doc = new Kondominium_BL.ClientePropiedadDocsDatos().GetByClienteDocId(Id);

            string mimeType = new Kondominium_Entities.Utilites.MimeTypeEntity().MimeTypeList().Where(x => x.Extension.Contains(new Utilities.General().ExtraerExtencion(doc.UrlDocument))).FirstOrDefault().Type;

            return File(doc.Document, mimeType);
        }

        #endregion "Subir Archivo"

        #region "Clientes 27-06-22"

        public ActionResult DeletePropiedadesClientes(int propiedadId, int clienteId)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5

            var UrlOrigen = HttpContext.Request.UrlReferrer.PathAndQuery;

            var modelr = new Kondominium_BL.ClientePropiedadDatos().Delete(new ClientePropiedadEntity { ClienteId = clienteId, PropiedadId = propiedadId });

            //Mensajes(modelr);
            //ModelState.Clear();

            // 9898 Eliminado
            // 96 No Existe

            return RedirectToAction("EditPropiedades", new { Id = propiedadId, codigo = modelr.Codigo });
        }

        #endregion "Clientes 27-06-22"
    }
}