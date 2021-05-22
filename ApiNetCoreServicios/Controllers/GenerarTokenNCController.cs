using LogicaNC;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarTokenNCController : ControllerBase
    {
        [HttpGet]
        [Route("api/GenerarToken/PostLB_Recuperar")]
        public string LB_Recuperar(string TB_Correo)
        {
            return new LGenerarToken().LB_Recuperar(TB_Correo);
        }
    }
}