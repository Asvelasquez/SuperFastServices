using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaNC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorNCController : ControllerBase
    {
        [HttpPut]
        [Route("api/Administrador/PutLGV_domiciliariiosaprobar")]
        public void LGV_domiciliariiosaprobar([FromBody] JObject Vs_entrada)
        {
            //ladministrador1.LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
            UUsuario usuario3 = new UUsuario();
            usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
            usuario3.Hojavida = Vs_entrada["Hoja_vida"].ToString();
            String Lcorreo = Vs_entrada["Lcorreo"].ToString();
            String comandname = Vs_entrada["comandname"].ToString();
            new Ladministrador().LGV_domiciliariiosaprobar(usuario3, Lcorreo, comandname);
        }

        [HttpPut]
        [Route("api/user/PutLGV_aliadorechazado")]
        public void LGV_aliadorechazado([FromBody] JObject Vs_entrada)
        {
            UUsuario usuario3 = new UUsuario();
            usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
            usuario3.Hojavida = Vs_entrada["Hoja_vida"].ToString();
            String Lcorreo = Vs_entrada["Lcorreo"].ToString();
            String comandname = Vs_entrada["comandname"].ToString();
            new Ladministrador().LGV_aliadorechazado(usuario3, Lcorreo, comandname);
        }

        [HttpPut]
        [Route("api/user/PutLGV_domiciliariorechazado")]
        public void LGV_domiciliariorechazado([FromBody] JObject Vs_entrada)
        {
            UUsuario usuario3 = new UUsuario();
            usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
            usuario3.Hojavida = Vs_entrada["Hoja_vida"].ToString();
            String Lcorreo = Vs_entrada["Lcorreo"].ToString();
            String comandname = Vs_entrada["comandname"].ToString();
            new Ladministrador().LGV_domiciliariorechazado(usuario3, Lcorreo, comandname);
        }

        [HttpPut]
        [Route("api/user/PutLGV_solicitudaliadosaceptados")]
        public void LGV_solicitudaliadosaceptados([FromBody] JObject Vs_entrada)
        {
            UUsuario usuario3 = new UUsuario();
            usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
            usuario3.Hojavida = Vs_entrada["Hoja_vida"].ToString();
            String Lcorreo = Vs_entrada["Lcorreo"].ToString();
            String comandname = Vs_entrada["comandname"].ToString();
            new Ladministrador().LGV_solicitudaliadosaceptados(usuario3, Lcorreo, comandname);
        }

        [HttpPut]
        [Route("api/user/PutLGV_domiciliariosaceptados")]
        public void LGV_domiciliariosaceptados([FromBody] JObject Vs_entrada)
        {
            UUsuario usuario3 = new UUsuario();
            usuario3.Id = int.Parse(Vs_entrada["Id"].ToString());
            usuario3.Hojavida = Vs_entrada["Hoja_vida"].ToString();
            String Lcorreo = Vs_entrada["Lcorreo"].ToString();
            String comandname = Vs_entrada["comandname"].ToString();
            new Ladministrador().LGV_domiciliariosaceptados(usuario3, Lcorreo, comandname);
        }

    }
}