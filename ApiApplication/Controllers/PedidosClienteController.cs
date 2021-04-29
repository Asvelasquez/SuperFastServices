using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;

namespace ApiApplication.Controllers{
    [Route("api/[controller]")]
    public class PedidosClienteController : ApiController {
        [HttpGet]
        [Route("api/PedidosCliente/GetLGV_pedidocarrito")]
        public void LGV_pedidocarrito(string comandname, string Id_pedido){
            new LPedidosCliente().LGV_pedidocarrito(comandname, Id_pedido);
        }
        //
        [HttpPut]
        [Route("api/PedidosCliente/PutLGV_pedidocarrito0")]
        public void LGV_pedidocarrito0([FromBody] JObject Vs_entrada){
            UPedido pedido = new UPedido();
            pedido.Id_pedido= int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Comentario_cliente = Vs_entrada["Comentario_cliente"].ToString();
            string comandname = Vs_entrada["comandname"].ToString();
            new LPedidosCliente().LGV_pedidocarrito0(comandname,pedido);
        }
        //
        [HttpGet]
        [Route("api/PedidosCliente/GetLBTN_Generarfactura")]
        public string LBTN_Generarfactura(){

            return "Reportes.aspx";
        }
        //
    }
}
