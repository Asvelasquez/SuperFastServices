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
    [Route ("api/[controller]")]
    public class LComunicacionController : ApiController
    {
       [HttpGet]
       [Route("api/comunicacion/getMostrarProductoInicio")]
       public List<UProducto> getMostrarProductoInicio()
        {
            return new LComunicacion().MostrarProductoInicio();
        }

    }

}
