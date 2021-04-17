using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Entrada
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El UsserName es requerido.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Sin Password no hay posibilidades de ingresar.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "La aplicacion es Requerida.")]
        public int AplicacionId { get; set; }
    }
}
