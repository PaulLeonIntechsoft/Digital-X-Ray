using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Digital_X_Ray.Models.Validations
{
    public class LoginCE
    {
        [Required(ErrorMessage = "El campo usuario es requerido")]
        [Display(Name = "Usuario")]
        public string chrLOGUSR { get; set; }
        [Required(ErrorMessage = "El campo contraseña es requerido")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string chrCODVEN { get; set; }
    }


    [MetadataType(typeof(LoginCE))]
    public partial class sp_login_Result
    {
    }

}