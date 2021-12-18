using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kondominium.Models
{
    public class UserModel : ZTAdminEntities.Security.UserEntity
    {
        [Display(Name = "Recordar Usuario")]
        public bool RememberMe { get; set; }

        [Display(Name = "Password")]
        //[Required(ErrorMessage = "Password es requerido.")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        //[Required(ErrorMessage = "Confirmation password es requerido.")]
        [Compare("Password1", ErrorMessage = "Password y confirmacion no son iguales.")]
        [DataType(DataType.Password)]
        [Display(Name = "Validacion de Password")]
        public string ValidatePassword { get; set; }
    }
}