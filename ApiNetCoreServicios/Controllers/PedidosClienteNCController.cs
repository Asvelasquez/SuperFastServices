using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosClienteNCController : ControllerBase
    {
        [HttpGet]
        [Route("api/PedidosCliente/GetLGV_pedidocarrito")]
        public void LGV_pedidocarrito(string comandname, string Id_pedido)
        {
            new LPedidosCliente().LGV_pedidocarrito(comandname, Id_pedido);
        }

        [HttpPut]
        [Route("api/PedidosCliente/PutLGV_pedidocarrito0")]
        public void LGV_pedidocarrito0([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Comentario_cliente = Vs_entrada["Comentario_cliente"].ToString();
            string comandname = Vs_entrada["comandname"].ToString();
            new LPedidosCliente().LGV_pedidocarrito0(comandname, pedido);
        }

        [HttpGet]
        [Route("api/PedidosCliente/GetLBTN_Generarfactura")]
        public string LBTN_Generarfactura()
        {

            return "Reportes.aspx";
        }
    }
}