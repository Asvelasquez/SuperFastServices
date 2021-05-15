using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de CerrarSession
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class CerrarSessionController : ApiController
    {
        /// <summary>
        /// Carga la ventana de inicio
        /// </summary>
        /// <param name="usuario1"></param>
        [HttpPost]
        [Route("api/CerrarSession/PostPage_Load")]
        public string Page_Load(int usuario1){
           return new LCerrarSession().Page_Load(usuario1);

        }
    }
}
