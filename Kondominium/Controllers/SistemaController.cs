using Kondominium.Models;
using Kondominium.Utilities;
using Kondominium_Entities;
using System.Web.Mvc;
using System.Web.Routing;
using ZTAdminEntities;

namespace Kondominium.Controllers
{
    public class SistemaController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        #region "Usuario"

        public ActionResult UserList()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.UserData().GetUsersEntity();

            return View(model);
        }

        // GET: Inventory
        [HttpGet]
        public ActionResult EditUser(string Id, Resultado codigo = null)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.UserData().GetById(Id);

            if (model.UserId != null)
            {
                model.Password = "000000000000000";
            }

            return View(model);
        }

        // GET: Inventory
        [HttpPost]
        public ActionResult EditUser(ZTAdminEntities.Security.UserEntity modl, FormCollection collection)
        {
            if (modl.Password != "000000000000000" && modl.Password != null)
            {
                if (modl.Password != collection["PasswordConfirmation"].ToString())
                {
                    Mensajes(new ZTAdminEntities.Utilities.Resultado { Codigo = ZTAdminEntities.Utilities.CodigosMensaje.Warning, Mensaje = "¡Password no y password confirmacion deben ser iguales!" });
                    return View(modl);
                }

                var validationpass = new ZTAdminBL.Security.SecurityValitations().ValidatePassword(modl.Password);

                if (!validationpass.Item1)
                {
                    Mensajes(validationpass.Item2);
                    return View(modl);
                }
            }
            else
            {
                modl.Password = "000000000000000";
            }
            modl.UserExecute = GetCurrentUser();

            var model = new ZTAdminBL.Security.UserData().InsertUpdateUsers(modl);

            Mensajes(model.Item2);
            return View(model.Item1);
        }

        #endregion "Usuario"

        #region "Rol"

        public ActionResult RolList()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.RolData().GetAll();
            return View(model);
        }

        // GET: Inventory
        [HttpGet]
        public ActionResult EditRol(string Id)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.RolData().GetById(Id);

            if (Id == null)
            {
                model.New = true;
            }

            return View(model);
        }

        // GET: Inventory
        [HttpPost]
        public ActionResult EditRol(ZTAdminEntities.Security.RolEntity modl, FormCollection collection)
        {
            ModelState.Clear();

            modl.UserId = GetCurrentUser();

            var model = new ZTAdminBL.Security.RolData().Save(modl);

            Mensajes(model.Item2);
            return View(model.Item1);
        }

        #endregion "Rol"

        #region "Perfil"

        public ActionResult PerfilList()
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.ProfileData().GetAll();

            return View(model);
        }

        // GET: Inventory
        [HttpGet]
        public ActionResult PerfilEdit(string Id)
        {
            if (!Verifypermission("", this.ControllerContext.RouteData.Values["action"].ToString(), this.ControllerContext.RouteData.Values["controller"].ToString()))
                return View("../Home/ErrorNotAutorized");

            var model = new ZTAdminBL.Security.ProfileData().GetById(Id);

            if (Id == null)
            {
                model.New = true;
            }

            return View(model);
        }

        // GET: Inventory
        [HttpPost]
        public ActionResult PerfilEdit(ZTAdminEntities.Security.ProfileEntity modl, FormCollection collection)
        {
            ModelState.Clear();

            modl.UserId = GetCurrentUser();

            var model = new ZTAdminBL.Security.ProfileData().Save(modl);

            Mensajes(model.Item2);
            return View(model.Item1);
        }

        #endregion "Perfil"

        #region "PerfilesDeUsuario"

        [HttpGet]
        public ActionResult UserProfileEdit(string UserId)
        {
            var modelU = new ZTAdminBL.Security.UserProfileData().GetByUserId(UserId);

            return PartialView(modelU);
        }

        //[HttpPost]
        //public ActionResult UserProfileEdit(ZTAdminEntities.Security.UserProfileEntity mdl)
        //{
        //    var modelU = new ZTAdminBL.Security.UserData().GetById(mdl.UsuarioId);
        //    return PartialView(modelU);
        //}

        [HttpGet]
        public ActionResult _PartialPerfildeUsuarioUserData(string Id)
        {
            var modelU = new ZTAdminBL.Security.UserData().GetById(Id);
            return View(modelU);
        }

        [HttpGet]
        public ActionResult _PartialPerfildeUsuarioSelectedGrid(string Id)
        {
            var modelp = new ZTAdminBL.Security.UserProfileData().GetById(Id);
            /// usuario, ProfileUsuario,

            return View(modelp);
        }

        [HttpPost]
        public ActionResult AgregarProfileUser(string ProfileId, string UserIdProfile)
        {
            var mdl = new jsModel();

            try
            {
                var dta = new ZTAdminBL.Security.UserProfileData().Save(new ZTAdminEntities.Security.UserProfileEntity
                { Active = 1, ProfileId = ProfileId, UserExecute = GetCurrentUser(), UsuarioId = UserIdProfile });

                var msj = new Kondominium_Entities.Resultado { Codigo = CodigosMensaje.Exito, Mensaje = "Perfil agregado con exito" };

                mdl.mensaje = msj;
                mdl.ClienteDocId = 1;
                mdl.ClienteId = 1;
                mdl.DocumentType = UserIdProfile;

                return Json(mdl);
            }
            catch (System.Exception)
            {
                var msj = new Kondominium_Entities.Resultado { Codigo = CodigosMensaje.Error, Mensaje = "Erro al tratar de agregar el perfil" };

                mdl.mensaje = msj;
                mdl.ClienteDocId = 0;
                mdl.ClienteId = 0;
                mdl.DocumentType = "0";

                return Json(mdl);
            }

            //return Json(mdl);
        }

        [HttpPost]
        public ActionResult _RemoverUserPerfil(string Userid, string PerfilId)
        {
            var mdl = new jsModel();
            try
            {
                var dta = new ZTAdminBL.Security.UserProfileData().Delete(Userid, PerfilId);

                mdl.mensaje = new Kondominium_Entities.Resultado { Codigo = CodigosMensaje.Exito, Mensaje = "Registro removido con exito" };
                mdl.ClienteDocId = 2;
                mdl.ClienteId = 2;
                mdl.DocumentType = Userid;

                return Json(mdl);
            }
            catch (System.Exception)
            {
                mdl.mensaje = new Kondominium_Entities.Resultado { Codigo = CodigosMensaje.Exito, Mensaje = "Surgio un error al tratar de remover el perfil del usuario" };
                mdl.ClienteDocId = 0;
                mdl.ClienteId = 0;
                mdl.DocumentType = Userid;

                return Json(mdl);
            }

            //return Json(mdl);
        }

        public ActionResult _MensajesS(int error, string Mensaje)
        {
            var mdel = new Models.jsModel();
            var msg = new Kondominium_Entities.Resultado();

            switch (error)
            {
                case 0:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Exito;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Procesado con Exito" : Mensaje;
                    ViewBag.Successful = msg.Mensaje;
                    break;

                case 9999:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Error;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Error al ejecutar el proceso" : Mensaje;
                    ViewBag.Error = string.IsNullOrEmpty(Mensaje) ? "Error al ejecutar el proceso" : Mensaje;
                    break;

                case 5000:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Warning;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Proceso ejecutado, pero existe una advertencia" : Mensaje;

                    ViewBag.Warning = msg.Mensaje;
                    break;

                case 9000:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Log;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro de Log" : Mensaje;
                    break;

                case 9898:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.Eliminado;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro Eliminado" : Mensaje;
                    break;

                case 97:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.No_Se_Puede_Eliminar;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro no puede ser eliminado" : Mensaje;
                    break;

                case 96:
                    msg.Codigo = Kondominium_Entities.CodigosMensaje.No_Existe;
                    msg.Mensaje = string.IsNullOrEmpty(Mensaje) ? "Registro no Existe" : Mensaje;
                    ViewBag.Warning = msg.Mensaje;
                    break;
            }

            mdel.mensaje = msg;

            return PartialView(mdel);
        }

        //// GET: Inventory
        //[HttpPost]
        //public ActionResult PerfildeUsuarioEdit(ZTAdminEntities.Security.ProfileEntity modl, FormCollection collection)
        //{
        //    ModelState.Clear();

        //    modl.UserId = GetCurrentUser();

        //    var model = new ZTAdminBL.Security.ProfileData().Save(modl);

        //    Mensajes(model.Item2);
        //    return View(model.Item1);
        //}

        #endregion "PerfilesDeUsuario"

        #region "Test Envio de Coreos"

        [HttpGet]
        public ActionResult EnvioEmailTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnvioEmailTest(EmailModel model)
        {
            try
            {
                // Enviar Correo a usuario Indicado
                var sendmail = new ZTAdminBL.Utilities.Email().sendMAil(new ZTAdminEntities.Utilities.MailEntity
                {
                    Body = model.Body,
                    //Attachment = new List<byte[]>(),
                    From = Core.FromEmail,
                    Pass = Core.PassEmail,
                    Server = Core.SMTServer,
                    Port = int.Parse(Core.PortSMTP),
                    UserId = Core.UserEmail,
                    IncludeAttachment = false,
                    To = new string[] { model.TO },
                    Subject = model.Subject
                });

                if (sendmail.Cod == 0)
                {
                    Mensajes(new Resultado { Codigo = Kondominium_Entities.CodigosMensaje.Exito, Mensaje = "Envio de correo exitoso" });
                    return View();
                }
                else
                {
                    Mensajes(new Resultado { Codigo = Kondominium_Entities.CodigosMensaje.Error, Mensaje = "Surgio un error al enviar el correo de pruebas" });
                    return View();
                }
            }
            catch (System.Exception ex)
            {
                Mensajes(new Resultado { Codigo = Kondominium_Entities.CodigosMensaje.Error, Mensaje = ex.Message });
                return View(model);
                throw;
            }
        }

        #endregion "Test Envio de Coreos"
    }
}