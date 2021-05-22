using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaNC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerrarSessionNCController : ControllerBase
    {
        [HttpPost]
        [Route("api/CerrarSession/PostPage_Load")]
        public string Page_Load(int usuario1)
        {
            return new LCerrarSession().Page_Load(usuario1);

        }
    }
}