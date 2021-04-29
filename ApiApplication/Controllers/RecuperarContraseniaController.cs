using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de recuperar contraseña
    /// </summary>
    [Route("api/[controller]")]
    public class RecuperarContraseniaController : ApiController{
        /// <summary>
        /// Este metodo Permite comparar las contraseñas
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar1")]
        public UUsuario LB_Cambiar1(UUsuario usuario){
            return new LRecuperarContrasenia().LB_Cambiar1(usuario);
         }
        //
        /// <summary>
        /// Este metodo Permite actualizar la contraseña
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar2")]
        public void LB_Cambiar2(UUsuario usuario){
            new LRecuperarContrasenia().LB_Cambiar2(usuario);
        }
        //
    }
}
