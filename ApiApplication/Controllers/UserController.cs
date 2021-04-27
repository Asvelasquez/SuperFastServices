using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.ComponentModel.DataAnnotations;

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

        //OK
        //se ingresa todo el objeto completo UAcceso y permite modificar cualquier valor
       
        [HttpPost]
        [Route("api/user/PostInsertarAcceso")]
        public void InsertarAcceso(UAcceso acceso){
            new LUser().InsertarAcceso(acceso);
        }

       

        //[HttpGet]
        //[Route("api/user/PostLG_Principal1")]
        //public async Task<UUsuario> LG_Principal1(UUsuario usuario1)
        //{
        //    return await new LUser().LG_Principal1(usuario1);
        //}

        //OK
        [HttpPost]
        [Route("api/user/PostLG_Principal2")]
        public async Task<UUsuario> LG_Principal2(LoginRequest usuario1)
        {
            return await new LUser().LG_Principal2(usuario1);
        }
        
        [HttpPost]
        [Route("api/user/PostLlogin1")]
        public string Llogin1(UUsuario usuario9)
        {
            return new LUser().Llogin1(usuario9);
        }

        [HttpGet]
        [Route("api/user/GetLLB_RecuperarContrasenia")]
        public string LLB_RecuperarContrasenia()
        {
            return new LUser().LLB_RecuperarContrasenia();
        }

        //revisar
        [HttpPost]
        [Route("api/user/PostguardarToken")]
        public void guardarToken(UToken_Seguridad token_seguridad)
        {
             new LUser().guardarToken(token_seguridad);
        }

        //[HttpPost]
        //[Route("api/user/Llogin1")]
        //public string LLB_RecuperarContrasenia()
        //{
        //    return "GenerarToken.aspx";
        //}
    }
}
