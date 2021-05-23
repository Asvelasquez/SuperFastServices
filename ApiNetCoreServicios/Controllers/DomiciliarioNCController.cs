using LogicaNC;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomiciliarioNCController : ControllerBase
    {
        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado")]
        public void DDL_Estado([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Domiciliario_id = int.Parse(Vs_entrada["Domiciliario_id"].ToString());
            string idseleccion = Vs_entrada["Estado_domicilio_id"].ToString();
            new LDomiciliario().DDL_Estado(pedido, idseleccion);
        }

        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado0")]
        public void DDL_Estado0([FromBody] JObject Vs_entrada)
        {
            UPedido pedido = new UPedido();
            pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
            pedido.Domiciliario_id = int.Parse(Vs_entrada["Domiciliario_id"].ToString());
            string idseleccion = Vs_entrada["Estado_domicilio_id"].ToString();
            new LDomiciliario().DDL_Estado0(pedido, idseleccion);

        }
    }
}