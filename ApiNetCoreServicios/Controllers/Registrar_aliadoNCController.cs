using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registrar_aliadoNCController : ControllerBase
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