using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Utilitarios;
namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo Permite acceceder a los servicios de registrar un aliado
    /// </summary>
    [Route("api/[controller]")]
    public class Registar_aliadoController : ApiController{
        /// <summary>
        /// Este metodo Permite comparar que el correo que estan registrando no exista en la base de datos
        /// </summary>
        /// <param name="correo"></param>
        [HttpGet]
        [Route("api/Registrar_aliado/GetLBTN_registrar")]
        public UUsuario LBTN_registrar(string correo)
        {
            return new LRegistrar_aliado().LBTN_registrar(correo);
        }
        /// <summary>
        /// Este metodo Permite Registrar a un usuario tipo aliado
        /// </summary>
        /// <param name="aliado1"></param>
        [HttpPost]
        [Route("api/Registrar_aliado/PostLBTN_registrar1")]
        public void LBTN_registrar1(UUsuario aliado1)
        {
            new LRegistrar_aliado().LBTN_registrar1(aliado1);
        }

    }
}
