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
    public class Registrar_DomiciliarioController : ApiController{
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetLBTND_registrar")]
        public void LBTND_registrar(string correo){
            new Lregistar_domiciliario().LBTND_registrar(correo);
        }
        //
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetRegitrar_domiciliario")]
        public void Regitrar_domiciliario(UUsuario usuario){
           new Lregistar_domiciliario().LBTND_registrar1(usuario);
        }
        //

        //
    }
}
