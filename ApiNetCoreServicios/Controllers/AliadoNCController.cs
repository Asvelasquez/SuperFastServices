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
    public class AliadoNCController : ControllerBase
    {
        [HttpPost]
        [Route("api/Aliado/PostLBTN_guardarproducto")]
        public string LBTN_guardarproducto(UProducto producto2)
        {
            return new LAliado().LBTN_guardarproducto(producto2);
        }

        [HttpPost]
        [Route("api/Aliado/PostLGV_Producto ")]
        public UProducto LGV_Producto([FromBody] JObject Vs_entrada)
        {
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;
            return new LAliado().LGV_Producto(producto1, comandname, idmostrar).UmacUproducto1;
        }//

        [HttpGet]
        [Route("api/Aliado/GetLmostrar")]
        public UProducto Lmostrar(int id3)
        {
            return new LAliado().Lmostrar(id3); ;
        }

        [HttpPost]
        [Route("api/Aliado/PostLBTN_GuardarCambios")]
        public string LBTN_GuardarCambios(UProducto producto)
        {
            return new LAliado().LBTN_GuardarCambios(producto);
        }

        [HttpPost]
        [Route("api/Aliado/PostLGV_Productosdesactivado")]
        public UProducto LGV_Productosdesactivado([FromBody] JObject Vs_entrada)
        {
            UProducto producto1 = new UProducto();
            producto1.Id = int.Parse(Vs_entrada["Id"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            int idmostrar = producto1.Id;
            return new LAliado().LGV_Productosdesactivado(producto1, comandname, idmostrar).UmacUproducto1;
        }

    }
}