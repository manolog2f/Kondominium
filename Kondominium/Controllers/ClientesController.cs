using Kondominium.Models;
using Kondominium_Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kondominium.Controllers
{
    public class ClientesController : BaseController
    {
        private ZoomTechLog.Log4NetMR.classClsRegistrarLog log = new ZoomTechLog.Log4NetMR.classClsRegistrarLog();
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

                ViewBag.ClienteId = model.ClienteId;
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
                ViewBag.ClienteId = model.ClienteId;
                return RedirectToAction("EditClientes", new { Id = modelr.Item1.ClienteId, codigo = 0 });
            }
            else
            {
                ViewBag.ClienteId = model.ClienteId;
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

        public ActionResult DeleteLineClientesDocs(int Id)
        {
            string userid = HttpContext.User.Identity.Name.ToString();
            //DeleteArancel / 5
            var datos = new Kondominium_BL.ClienteDocsDatos().GetByClienteDocId(Id);
            try
            {
                if (datos != null)
                {
                    var modelr = new Kondominium_BL.ClienteDocsDatos().Delete(datos);
                    if (modelr.Codigo == CodigosMensaje.Exito)
                    {
                        //if (System.IO.File.Exists(datos.UrlDocument))
                        //{
                        //    System.IO.File.Delete(datos.UrlDocument);
                        //}
                        return RedirectToAction("EditClientes", new { Id = datos.ClienteId, codigo = 0 });
                    }

                    return RedirectToAction("EditClientes", new { Id = datos.ClienteId, codigo = modelr.Codigo });
                }
                else
                {
                    return RedirectToAction("EditClientes", new { Id = datos.ClienteId, codigo = CodigosMensaje.No_Existe });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("EditClientes", new { Id = datos.ClienteId, codigo = CodigosMensaje.Error });
            }
        }

        public ActionResult _ListClienteDocs(int? ClienteId, int? codigo = null)
        {
            ViewBag.ClienteId = ClienteId;

            if (ClienteId != null)
            {
                var model = new Kondominium_BL.ClienteDocsDatos().GetById(int.Parse(ClienteId.ToString()));
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                return PartialView("_ListClienteDocs", model);
            }
            return PartialView("_ListClienteDocs", new List<ClienteDocsEntity>());
        }

        [HttpGet]
        public ActionResult _EditClientesFileUpload(string ClienteId, string DocumentType, int? codigo = null)
        {
            if (ClienteId != null && DocumentType != null)
            {
                var model = new Kondominium_BL.ClienteDocsDatos().GetById(int.Parse(ClienteId), DocumentType);
                if (codigo != null)
                {
                    Mensajes(new Resultado { Codigo = (CodigosMensaje)codigo });
                }
                ModelState.Clear();
                ViewBag.ClienteId = ClienteId;

                if (model == null)
                {
                    model = new ClienteDocsEntity { ClienteId = int.Parse(ClienteId) };
                }

                //model.ClienteId =  ;

                return View(model);
            }
            return View(new ClienteDocsEntity());
        }

        [HttpPost]
        public ActionResult _EditClientesFileUploadPost(ClienteDocsEntity model, FormCollection form)
        {
            model.ModificadoPor = HttpContext.User.Identity.Name.ToString();
            model.CreadoPor = model.ModificadoPor;

            var modelr = new Kondominium_BL.ClienteDocsDatos().Save(model);
            Mensajes(modelr.Item2);
            ModelState.Clear();

            if (modelr.Item2.Codigo == CodigosMensaje.Exito)
            {
                return RedirectToAction("_EditClientesFileUpload", new { ClienteId = modelr.Item1.ClienteId, DocumentType = modelr.Item1.DocumentType, codigo = 0 });
            }
            else
            {
                return View("_EditClientesFileUpload", modelr.Item1);
            }
        }

        /*/_UpdateClienteDocs  /// _AddClienteDocs

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
                return RedirectToAction("EditClientesPropiedades", new { ClienteId = modelr.Item1.ClienteId, PropiedadId = modelr.Item1.PropiedadId, codigo = 0 });
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

        public List<ClientesEntity> ListTipoDocs()
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

        public List<string> ListTipoDocumentoEnum()
        {
            try
            {
                var lista = new List<string>();

                return Enum.GetNames(typeof(TipoDocumento)).ToList();
            }
            catch (Exception)
            {
                // TODO: Poner en el manejador de errores la excepcion
                throw;
            }
        }

        #region "Subir Archivo"

        //[HttpPost]
        //public ActionResult _UploadFileH(HttpPostedFileBase file, FormCollection form)
        //{
        //    var mdl = new jsModel();
        //    var respM = new Resultado();

        //    mdl.ClienteId = int.Parse(form["ClienteId"].ToString());
        //    mdl.DocumentType = form["DocumentType"];
        //    mdl.ClienteDocId = int.Parse(form["ClienteDocId"]);
        //    try
        //    {
        //        //var v = new GPIntegration_BL.CashReceipt.FileIUploapProcess();
        //        if (file.ContentLength > 0)
        //        {
        //            string _FileName = Path.GetFileName(file.FileName);
        //            string targetFolder = HttpContext.Server.MapPath("~/Documents/Clientes/" + mdl.ClienteId);
        //            if (!Directory.Exists(targetFolder))
        //            {
        //                Directory.CreateDirectory(targetFolder);
        //            }

        //            string targetPath = Path.Combine(targetFolder, _FileName);
        //            var docSave = new Kondominium_BL.ClienteDocsDatos().Save(new ClienteDocsEntity { ClienteDocId = mdl.ClienteDocId, ClienteId = mdl.ClienteId, DocumentType = mdl.DocumentType, UrlDocument = targetPath, ModificadoPor = HttpContext.User.Identity.Name.ToString(), CreadoPor = HttpContext.User.Identity.Name.ToString() });

        //            mdl.JsFuntion = "T";
        //            mdl.ClienteDocId = docSave.Item1.ClienteDocId;
        //            file.SaveAs(targetPath);
        //            mdl.mensaje = docSave.Item2;
        //        }
        //        return Json(mdl);
        //    }
        //    catch (Exception ex)
        //    {
        //        respM.Codigo = CodigosMensaje.Error;
        //        respM.Mensaje = ex.Message;
        //        mdl.JsFuntion = "Err";
        //        mdl.mensaje = respM;

        //        this.Mensajes(respM);
        //        ViewBag.Message = "Error al cargar el Archivo!!" + ex;

        //        log.LogExeption("Error Almacenar Archivo", ZoomTechLog.LogType.Error, ex);

        //        return Json(mdl);
        //    }
        //}
        [HttpPost]
        public ActionResult _UploadFileH(HttpPostedFileBase file, FormCollection form)
        {
            var mdl = new jsModel();
            var respM = new Resultado();

            mdl.ClienteId = int.Parse(form["ClienteId"].ToString());
            mdl.DocumentType = form["DocumentType"];
            mdl.ClienteDocId = int.Parse(form["ClienteDocId"]);
            try
            {
                if (file.ContentLength > 0)
                {
                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }

                    var docSave = new Kondominium_BL.ClienteDocsDatos().Save(new ClienteDocsEntity { ClienteDocId = mdl.ClienteDocId, ClienteId = mdl.ClienteId, DocumentType = mdl.DocumentType, UrlDocument = file.FileName, ModificadoPor = HttpContext.User.Identity.Name.ToString(), CreadoPor = HttpContext.User.Identity.Name.ToString(), Document = thePictureAsBytes });

                    mdl.JsFuntion = "T";
                    mdl.ClienteDocId = docSave.Item1.ClienteDocId;

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

                log.LogExeption("Error Almacenar Archivo", ZoomTechLog.LogType.Error, ex);

                return Json(mdl);
            }
        }

        public FileResult _DownloadFIle(int Id)
        {
            var doc = new Kondominium_BL.ClienteDocsDatos().GetByClienteDocId(Id);

            string mimeType = new Kondominium_Entities.Utilites.MimeTypeEntity().MimeTypeList().Where(x => x.Extension.Contains(new Utilities.General().ExtraerExtencion(doc.UrlDocument))).FirstOrDefault().Type;

            return File(doc.Document, mimeType);
        }

        #endregion "Subir Archivo"

        public JsonResult GetCustomers(string term = "")
        {
            var objCustomerlist = new Kondominium_BL.ClientesDatos().GetAllByFIlter(true, term).
                                  Select(c => new { Name = c.VFullName, ID = c.ClienteId })
                        .Distinct().ToList();

            ;

            return Json(objCustomerlist, JsonRequestBehavior.AllowGet);
        }
    }
}