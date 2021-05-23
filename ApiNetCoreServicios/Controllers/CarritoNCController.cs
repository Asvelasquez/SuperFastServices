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
    public class CarritoNCController : ControllerBase
    {
        [HttpGet]
        [Route("api/Carrito/GetLPage_Load")]
        public string LPage_Load(UUsuario usuario1)
        {
            return new LCarrito().LPage_Load(usuario1).Url;
        }

        [HttpPut]
        [Route("api/Carrito/PutLGV_pedidocarrito")]
        public string LGV_pedidocarrito([FromBody]JObject Vs_entrada)
        {
            UPedido pedido2 = new UPedido();
            pedido2.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            String comandname = Vs_entrada["comandname"].ToString();
            return new LCarrito().LGV_pedidocarrito(pedido2, comandname).Url;
        }

        [HttpGet]
        [Route("api/Carrito/GetLmostrarpreciototal20")]
        public string Lmostrarpreciototal20(int idusuario)
        {
            return new LCarrito().Lmostrarpreciototal20(idusuario);
        }

        [HttpGet]
        [Route("api/Carrito/GetLmostrarpreciodomicilio")]
        public string Lmostrarpreciodomicilio(int idusuario)
        {
            return new LCarrito().Lmostrarpreciodomicilio(idusuario);
        }

        [HttpPut]
        [Route("api/Carrito/Put/LBTN_comprar")]
        public String LBTN_comprar([FromBody]JObject Vs_entrada)
        {
            int idusuario = int.Parse(Vs_entrada["idusuario"].ToString());
            UDetalle_pedido detapedido4 = new UDetalle_pedido();
            detapedido4.Pedido_id = int.Parse(Vs_entrada["pedido_id"].ToString());
            detapedido4.Telefono_cliente = Vs_entrada["Telefono_cliente"].ToString();
            detapedido4.Direccion_cliente = Vs_entrada["Direccion_cliente"].ToString();
            UPedido pedido4 = new UPedido();
            pedido4.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido4.Estado_pedido = int.Parse(Vs_entrada["Estado_pedido"].ToString());
            pedido4.Valor_total = double.Parse(Vs_entrada["Valor_total"].ToString());
            return new LCarrito().LBTN_comprar(idusuario, detapedido4, pedido4).Url;
        }
    }
}