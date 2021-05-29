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
            try
            {
                if (!ModelState.IsValid)
                {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return error;
                }
                UUsuario usuario1 = new UUsuario();
                UUsuario usuario2 = new UUsuario();
                UToken token1 = new UToken();
                token1 = new LRecuperarContrasenia().CambiarContrasenia(Vs_entrada["Token"].ToString());
                //usuario1 = new LRecuperarContrasenia().LB_Cambiar1(usuario2);
                usuario2.Id = token1.User_id;
                usuario2.Contrasenia = Vs_entrada["NuevaContrasenia"].ToString();
                if (token1==null || usuario2==null)
                {
                    return "Alguna de las variables requeridas viene vacia o null, intentelo de nuevo";
                }
                else
                {
                    new LRecuperarContrasenia().LB_Cambiar2(usuario2);
                    return "cambio de contraseña exitoso";
                }

            }
            catch (Exception ex)
            {
                return "hay un problema interno: " + ex.StackTrace;
            }

          
         
        }
    }
}
