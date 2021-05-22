using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaNC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilNCController : ControllerBase
    {
        [HttpGet]
        [Route("api/Perfil/Getmostrarperfil")]
        public UUsuario mostrarperfil(int id)
        {
            return new LPerfil().mostrar(id);
        }

        [HttpPost]
        [Route("api/Perfil/PostBTN_guardar")]
        public void BTN_guardar(UUsuario usuario)
        {
            new LPerfil().BTN_guardar(usuario);
        }
    }
}