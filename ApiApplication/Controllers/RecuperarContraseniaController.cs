using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers{
    [Route("api/[controller]")]
    public class RecuperarContraseniaController : ApiController{
        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar1")]
        public UUsuario LB_Cambiar1(UUsuario usuario){
            return new LRecuperarContrasenia().LB_Cambiar1(usuario);
         }
        //
        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar2")]
        public void LB_Cambiar2(UUsuario usuario){
            new LRecuperarContrasenia().LB_Cambiar2(usuario);
        }
        //
    }
}
