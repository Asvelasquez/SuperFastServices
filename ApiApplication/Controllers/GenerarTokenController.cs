using System.Web.Http;
using Logica;
using System.Web.Http.Cors;
using System;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de generar token
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class GenerarTokenController : ApiController{

        /// <summary>
        /// Este metodo nos permite Generar un token para recuperar la coontraseña
        /// </summary>
        /// <param name="correo"></param>
        [HttpGet]
        [Route("api/GenerarToken/GetGenerarToken")]
        public IHttpActionResult GenerarToken(string correo)
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
                    return BadRequest(error);
                }
              
               
                if (correo==null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                   
                    return Ok(new LGenerarToken().LB_Recuperar3(correo));
                }
            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
           
        }






    }
}
