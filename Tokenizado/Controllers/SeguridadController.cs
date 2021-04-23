using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;

using Tokenizado.Seguridad;

namespace Tokenizado.Controllers
{
    [RoutePrefix("api/admin")]
    public class SeguridadController : ApiController
    {
        //public object TokenGenerator { get; private set; }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult login(LoginRequest login)
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
            UUsuario user = new LUser().LG_Principal2(login);
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
