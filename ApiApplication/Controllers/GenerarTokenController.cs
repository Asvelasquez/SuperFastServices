using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class GenerarTokenController : ApiController
    {

        [HttpGet]
        [Route("api/GenerarToken/PostLB_Recuperar")]
        public string LB_Recuperar(string TB_Correo)
        {
            return new LGenerarToken().LB_Recuperar(TB_Correo);
        }




    }
}
