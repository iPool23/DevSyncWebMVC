using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Presentacion.Models
{
    public class UsuarioModel
    {
        public int iCodigo { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string sNombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string sCorreo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string sContrasenia { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        public string sNombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        public string sApellidos { get; set; }

        public string sImgUrl { get; set; }

        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImgFile { get; set; }

        public RolModel eCodigoRol { get; set; }
    }
}