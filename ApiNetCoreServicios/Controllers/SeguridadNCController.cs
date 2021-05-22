using System.Threading.Tasks;
using ApiNetCoreServicios.Seguridad;
using DataNC;
using LogicaNC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadNCController : ControllerBase
    {
        private readonly Mapeo _context;
        private readonly IConfiguration _configuration;

        public SeguridadNCController(Mapeo context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> loginAsync(LoginRequest login)
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
            UUsuario user = await new LUser(_context).LG_Principal2(login);
            if (user == null)
                return Unauthorized();
            else
            {
                var secretKey = _configuration["JWT_SECRET_KEY"];
                var audienceToken = _configuration["JWT_AUDIENCE_TOKEN"];
                var issuerToken = _configuration["JWT_ISSUER_TOKEN"];
                var expireTime = _configuration["JWT_EXPIRE_MINUTES"];


                var token = TokenGenerator.GenerateTokenJwt(user, secretKey, audienceToken, issuerToken, expireTime, _context);
                return Ok(token);
            }
        }


        [Route("Get-Users")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetUsers()
        {
            return Ok(new LUser(_context).ObtenerUsuarios());
        }
    }
}