using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite Guerdar el comentario del aliado 
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class PedidosClienteController : ApiController {
        /// <summary>
        /// Este metodo nos permite carcelar el pedido
        /// </summary>
        /// <param name="comandname"></param>
        /// /// <param name="Id_pedido"></param>
        [HttpGet]
        [Route("api/PedidosCliente/GetLGV_pedidocarrito")]
        public void LGV_pedidocarrito(string comandname, string Id_pedido){
            new LPedidosCliente().LGV_pedidocarrito(comandname, Id_pedido);
        }
        //
        /// <summary>
        /// Este metodo nos permite Al cliente hacer un comentario sobre el pedido
        /// </summary>
        /// <param name="Vs_entrada"></param>
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
        /// <summary>
        /// Este metodo nos permite Al cliente Generar una factura
        /// </summary>
        [HttpGet]
        [Route("api/PedidosCliente/GetLBTN_Generarfactura")]
        public string LBTN_Generarfactura(){

            return "Reportes.aspx";
        }
        //
    }
}
