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
        /// <param name="TB_Correo"></param>
        [HttpGet]
        [Route("api/GenerarToken/PostLB_Recuperar")]
        public string LB_Recuperar(string TB_Correo)
        {
            return new LGenerarToken().LB_Recuperar3(TB_Correo);
        }




    }
}
