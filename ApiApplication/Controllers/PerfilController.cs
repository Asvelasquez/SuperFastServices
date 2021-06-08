using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using System;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceceder a los servicios del perfil
    /// </summary>
    /// 

    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class PerfilController : ApiController{
        /// <summary>
        /// Este metodo permite a cualquier usuario ver su informacion personal
        /// datos de ingreso:
        /// id
        /// </summary>
        /// <param name="id"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/Perfil/Getmostrarperfil")]
        public UUsuario mostrarperfil(int id){
            UUsuario usuario = new UUsuario();
            try{
                if (id!=0){
                    usuario = new LPerfil().mostrar(id);
                }                
            }catch{}
            return usuario;
        }
        //
        /// <summary>
        /// Este metodo Permite a cualquier usuario cambiar su informacion privada
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/Perfil/PostBTN_guardar")]
        public IHttpActionResult BTN_guardar(UUsuario usuario){
            try {
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }

                if (usuario == null){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new LPerfil().BTN_guardar(usuario);
                    return Ok("Comentario guardado");
                }
            } catch (Exception ex) {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            
        }
        //
    }
}
