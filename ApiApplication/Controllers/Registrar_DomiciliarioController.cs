using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de registrar un domiciliario
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class Registrar_DomiciliarioController : ApiController{
        /// <summary>
        /// Este metodo Permite comparar el correo de registro con lo de la base de datos
        /// </summary>
        /// <param name="correo"></param>
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetLBTND_registrar")]
        public void LBTND_registrar(string correo){
            new Lregistar_domiciliario().LBTND_registrar(correo);
        }
        //
        /// <summary>
        /// Este metodo Permite registrar un usuario tipo domiciliario
        /// </summary>
        /// <param name="usuario"></param>
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetRegitrar_domiciliario")]
        public void Regitrar_domiciliario(UUsuario usuario){
           new Lregistar_domiciliario().LBTND_registrar1(usuario);
        }
        //

        //
    }
}
