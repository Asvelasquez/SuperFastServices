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
    public class RegistrarseController : ApiController{
        [HttpGet]
        [Route("api/Registrar/GetValidar_correo")]
        public UUsuario Validar_correo(string correo){
            return new LRegistrarse().LBT_Registrar(correo);
        }
        //
        [HttpPost]
        [Route("api/Registrar/PostInsertar_Usuario")]
        public void Insertar_Usuario(UUsuario usuario){
            new LRegistrarse().LBT_Registrar1(usuario);
        }
        //
    }
}
