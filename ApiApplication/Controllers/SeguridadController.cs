using System.Web.Http;
using Utilitarios;
using Logica;
using System.Threading.Tasks;
using ApiApplication.Seguridad;

namespace ApiApplication.Controllers{
     /// <summary>
     /// 
     /// </summary>
    [RoutePrefix("api/admin")]
    public class SeguridadController : ApiController
    {
        /// <summary>
        /// permite loguearse
        /// </summary>
        /// <param name="login"></param>
        [Route("login")]
        [HttpPost]
        public async Task<IHttpActionResult> loginAsync(LoginRequest login)
        {
            string mensaje;
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
            UUsuario user =await new LUser().LG_Principal2(login);
            if (user == null)
                return Unauthorized();
            else
            {
                var token = TokenGenerator.GenerateTokenJwt(user);
                return Ok(token);
            }
        }

        /// <summary>
        /// permite obtener usuarios
        /// </summary>
        /// <param></param>
        [Route("Get-Users")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetUsers()
        {
            return Ok(new LUser().ObtenerUsuarios());
        }
    }
}
