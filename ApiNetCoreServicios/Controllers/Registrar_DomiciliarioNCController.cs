using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Registrar_DomiciliarioNCController : ControllerBase
    {
        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetLBTND_registrar")]
        public void LBTND_registrar(string correo)
        {
            new Lregistar_domiciliario().LBTND_registrar(correo);
        }

        [HttpGet]
        [Route("api/Registrar_Domiciliario/GetRegitrar_domiciliario")]
        public void Regitrar_domiciliario(UUsuario usuario)
        {
            new Lregistar_domiciliario().LBTND_registrar1(usuario);
        }

    }
}