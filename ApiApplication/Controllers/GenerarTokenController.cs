using System.Web.Http;
using Logica;
using System.Web.Http.Cors;

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
        public string GenerarToken(string correo)
        {
            return new LGenerarToken().LB_Recuperar3(correo);
        }






    }
}
