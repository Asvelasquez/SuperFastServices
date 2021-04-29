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
    public class PerfilController : ApiController{
        [HttpGet]
        [Route("api/Perfil/Getmostrarperfil")]
        public UUsuario mostrarperfil(int id){
            return new LPerfil().mostrar(id);
        }
        //
        [HttpPost]
        [Route("api/Perfil/PostBTN_guardar")]
        public void BTN_guardar(UUsuario usuario){
            new LPerfil().BTN_guardar(usuario);
        }
        //
    }
}
