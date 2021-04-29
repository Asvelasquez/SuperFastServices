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
    /// Este metodo nos permite acceder a los servicios de Pedidos aliados
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class PedidosaliadoController : ApiController{
        /// <summary>
        /// Este metodo nos permite cambiar el estado de los Pedidos
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [HttpPut]
        [Route("api/Pedidosaliado/PutLDDL_Categoria")]
        public void LDDL_Categoria([FromBody] JObject Vs_entrada){
            UPedido pedido = new UPedido();
            pedido.Id_pedido= int.Parse(Vs_entrada["Id_pedido"].ToString());
            string idseleccion= Vs_entrada["idseleccion"].ToString();
            new LPedidosaliado().LDDL_Categoria(pedido,idseleccion);
        }
        //
        /// <summary>
        /// Este metodo nos permite Guerdar el comentario del aliado 
        /// </summary>
        /// <param name="Vs_entrada"></param>
        [HttpPut]
        [Route("api/Pedidosaliado/PutLGV_pedidos")]
        public void LGV_pedidos([FromBody] JObject Vs_entrada){
            UPedido pedido = new UPedido();
            pedido.Id_pedido= int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Comentario_aliado = Vs_entrada["Comentario_aliado"].ToString();
            string CommandName=Vs_entrada["CommandName"].ToString();
            new LPedidosaliado().LGV_pedidos(pedido, CommandName);
        }
        //
    }
}
