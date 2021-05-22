using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosaliadoNCController : ControllerBase
    {
        [HttpPut]
        [Route("api/Pedidosaliado/PutLDDL_Categoria")]
        public void LDDL_Categoria([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            string idseleccion = Vs_entrada["idseleccion"].ToString();
            new LPedidosaliado().LDDL_Categoria(pedido, idseleccion);
        }

        [HttpPut]
        [Route("api/Pedidosaliado/PutLGV_pedidos")]
        public void LGV_pedidos([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Comentario_aliado = Vs_entrada["Comentario_aliado"].ToString();
            string CommandName = Vs_entrada["CommandName"].ToString();
            new LPedidosaliado().LGV_pedidos(pedido, CommandName);
        }
    }
}