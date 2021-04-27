using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Utilitarios;
namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class Registar_aliadoController : ApiController
    {

        [HttpGet]
        [Route("api/Registrar_aliado/GetLBTN_registrar")]
        public UUsuario LBTN_registrar(string correo)
        {
            return new LRegistrar_aliado().LBTN_registrar(correo);
        }
        [HttpPost]
        [Route("api/Registrar_aliado/PostLBTN_registrar1")]
        public void LBTN_registrar1(UUsuario aliado1)
        {
            new LRegistrar_aliado().LBTN_registrar1(aliado1);
        }

    }
}
