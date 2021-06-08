using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicio del login
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        //ejemplo obtener usuarios
        //[HttpGet]
        //[Route("api/user/GetObtenerUsuarios")]
        //public async Task<List<UUsuario>> GetObtenerUsuarios()
        //{
        //    return await new LUser().ObtenerUsuarioAsync();
        //}

        //OK
        //
        /// <summary>
        /// se ingresa todo el objeto completo UAcceso y permite modificar cualquier valor
        /// </summary>
        /// <param name="acceso"></param>
        [HttpPost]
        [Route("api/user/PostInsertarAcceso")]
        public IHttpActionResult InsertarAcceso(UAcceso acceso){
            try
            {
                if (acceso==null){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else{
                    new LUser().InsertarAcceso(acceso);
                    return Ok();
                }
            }
            catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            
        }



        //[HttpGet]
        //[Route("api/user/PostLG_Principal1")]
        //public async Task<UUsuario> LG_Principal1(UUsuario usuario1)
        //{
        //    return await new LUser().LG_Principal1(usuario1);
        //}

        //OK
        //se ingresa todo el objeto completo UAcceso y permite modificar cualquier valor
        /// <summary>
        /// Este metodo Permite a cualquier usuario cambiar su informacion privada
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/user/PostLG_Principal2")]
        public async Task<UUsuario> LG_Principal2(LoginRequest usuario)
        {
            return await new LUser().LG_Principal2(usuario);
        }
        /// <summary>
        /// Este metodo Permite a cualquier usuario cambiar su informacion privada
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/user/PostLlogin1")]
        public string Llogin1(UUsuario usuario)
        {
            return new LUser().Llogin1(usuario);
        }
        /// <summary>
        /// Este metodo Permite enviar el token
        /// </summary>
        [HttpGet]
        [Route("api/user/GetLLB_RecuperarContrasenia")]
        public string LLB_RecuperarContrasenia()
        {
            return new LUser().LLB_RecuperarContrasenia();
        }
        /// <summary>
        /// Este metodo Permite a guardar token
        /// </summary>
        /// <param name="token_seguridad"></param>
        //revisar
        [HttpPost]
        [Route("api/user/PostguardarToken")]
        public IHttpActionResult guardarToken(UToken_Seguridad token_seguridad){
            try{
                if (token_seguridad == null){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new LUser().guardarToken(token_seguridad);
                    return Ok();
                }
            }catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
             
        }

    }
}
