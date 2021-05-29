using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de recuperar contraseña
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class RecuperarContraseniaController : ApiController{
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/RecuperarContrasenia/RepContra")]
        public string RecuperarContrasenia([FromBody]JObject Vs_entrada)
        {
            UUsuario usuario1 = new UUsuario();
            UUsuario usuario2 = new UUsuario();
            usuario1 = new LRecuperarContrasenia().LB_Cambiar1(usuario2);
            usuario2.Id = int.Parse(Vs_entrada["IdUsuario"].ToString());
            usuario2.Contrasenia = Vs_entrada["NuevaContrasenia"].ToString();
            new LRecuperarContrasenia().LB_Cambiar2(usuario2);

            return "Exitoso!!!";
        }
    }
}
