using System.Web.Http;
using Utilitarios;
using Logica;
using System.Threading.Tasks;
using Tokenizado.Seguridad;

namespace Tokenizado.Controllers{
    [RoutePrefix("api/admin")]
    public class SeguridadController : ApiController
    {
        //public object TokenGenerator { get; private set; }
       // [Route("api/user/PostInsertarAcceso")]
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


        [Route("Get-Users")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetUsers()
        {
            return Ok(new LUser().ObtenerUsuarios());
        }
    }
}
