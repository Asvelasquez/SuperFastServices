using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utilitarios;
using Logica;

namespace ApiApplication.Controllers
{
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
        [HttpPost]
        [Route("api/user/LG_Principal2")]
        public void InsertarAcceso(UAcceso acceso){
            new LUser().InsertarAcceso(acceso);
        }

        [HttpPost]
        [Route("api/user/LG_Principal1")]
        public UUsuario LG_Principal1(UUsuario usuario1){
            return new LUser().LG_Principal1(usuario1);
        }
        [HttpPost]
        [Route("api/user/Llogin1")]
        public string Llogin1(UUsuario usuario9)
        {
            return new LUser().Llogin1(usuario9);
        }
        //[HttpPost]
        //[Route("api/user/Llogin1")]
        //public string LLB_RecuperarContrasenia()
        //{
        //    return "GenerarToken.aspx";
        //}
    }
}
