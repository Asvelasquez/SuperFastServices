using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;

namespace ApiApplication.Controllers
{ 
    [Route("api/[controller]")]
    public class CarritoController : ApiController
    {
        [HttpGet]
        [Route("api/Carrito/GetLPage_Load")]
        public UMac LPage_Load(UUsuario usuario1)
        {
            return new LCarrito().LPage_Load(usuario1);
        }
    
        [HttpPost]
        [Route("api/Carrito/PostLGV_pedidocarrito")]
        public UMac LGV_pedidocarrito(UPedido pedido2,String comandname){
            return new LCarrito().LGV_pedidocarrito(pedido2, comandname);
        }

        [HttpGet]
        [Route("api/Carrito/getLmostrarpreciototal1")]
        public List<UPedido> Lmostrarpreciototal1(int idusuario)
        {
            //return new  pedido3 = dpedido.preciototal(idusuario);
            return new LCarrito().Lmostrarpreciototal1(idusuario);
        }


        //revisar
        [HttpPost]
        [Route("api/Carrito/PostLmostrarpreciototal")]
        public string Lmostrarpreciototal(List<UPedido> pedido3)
        {
          return  new LCarrito().Lmostrarpreciototal(pedido3);
        }

        [HttpGet]
        [Route("api/Carrito/GetLmostrarpreciodomicilio")]
        public List<UPedido> Lmostrarpreciodomicilio(int idusuario)
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
            pedido4.Id_pedido =int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido4.Estado_pedido = int.Parse(Vs_entrada["Estado_pedido"].ToString());
            pedido4.Valor_total = double.Parse(Vs_entrada["Valor_total"].ToString());             
            return new LCarrito().LBTN_comprar(idusuario,detapedido4,pedido4).Url;
        }

    }

}
