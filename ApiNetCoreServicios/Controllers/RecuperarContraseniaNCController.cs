using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperarContraseniaNCController : ControllerBase
    {
        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar1")]
        public UUsuario LB_Cambiar1(UUsuario usuario)
        {
            return new LRecuperarContrasenia().LB_Cambiar1(usuario);
        }

        [HttpPost]
        [Route("api/RecuperarContrasenia/PostLB_Cambiar2")]
        public void LB_Cambiar2(UUsuario usuario)
        {
            new LRecuperarContrasenia().LB_Cambiar2(usuario);
        }
    }
}