using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult EditUser(string Id)
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

        #endregion

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

        #endregion

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

        #endregion

        #region "PerfilesDeUsuario"

        [HttpGet]
        public ActionResult UserProfileEdit(string Id)
        {
            var modelU = new ZTAdminBL.Security.UserData().GetById(Id);
            return View(modelU);
        }

        [HttpPost]
        public ActionResult UserProfileEdit(ZTAdminEntities.Security.UserEntity mdl)
        {
            var modelU = new ZTAdminBL.Security.UserData().GetById(mdl.UserId);
            return View(modelU);
        }

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


        #endregion

    }



}
