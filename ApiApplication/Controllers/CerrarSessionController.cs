using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de CerrarSession
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class CerrarSessionController : ApiController
    {
        /// <summary>
        /// Cierra la sesion
        /// datos de ingreso:
        /// usuario1
        /// </summary>
        /// <param name="usuario1"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/CerrarSession/PostPage_Load")]
        public IHttpActionResult Page_Load(int usuario1){
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
                    return BadRequest(error);
                }


                if (usuario1 ==0)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {

                    return Ok(new LCerrarSession().Page_Load(usuario1));
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }


        }
    }
}
