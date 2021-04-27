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
    [Route("api/[controller]")]
    public class CerrarSessionController : ApiController
    {
        [HttpPost]
        [Route("api/CerrarSession/PostPage_Load")]
        public void Page_Load(UUsuario usuario1){
            new LCerrarSession().Page_Load(usuario1);
        }
    }
}
