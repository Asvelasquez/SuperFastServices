using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El UsserName es requerido.")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Sin Password no hay posibilidades de ingresar.")]
        public string Contrasenia { get; set; }
       [Required( ErrorMessage ="la aplicacion es requerida")]
       public int AplicacionID { get; set; }
       
    }
}
