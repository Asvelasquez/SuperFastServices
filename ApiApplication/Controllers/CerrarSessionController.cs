using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
namespace ApiApplication.Controllers
{
    /// <summary>
    /// Servicios de CerrarSesion
    /// </summary>
    /// <param name=""></param>
    [Route("api/[controller]")]
    public class CerrarSessionController : ApiController
    {
        /// <summary>
        /// Carga la ventana de inicio
        /// </summary>
        /// <param name="usuario1"></param>
        [HttpPost]
        [Route("api/CerrarSession/PostPage_Load")]
        public void Page_Load(UUsuario usuario1){
            new LCerrarSession().Page_Load(usuario1);
        }
    }
}
