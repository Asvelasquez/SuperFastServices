using System;
using System.Collections.Generic;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Inicio
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class InicioController : ApiController{
        //
        /// <summary>
        /// Este metodo nos permite ver la lista de los productos
        /// </summary>
        /// <param name="idsesion"></param>
        [HttpGet]
        [Route("api/Inicio/GetDL_Productos1")]
        public List<UPedido> DL_Productos1(int idsesion){
            return new LInicio().DL_Productos1(idsesion);
        }
        //
        /// <summary>
        /// Este metodo nos permite ver los productos por filtros, por tipos de comida, por tipos de aliados
        /// </summary>
        /// <param name="det_pedido"></param>
        [HttpGet]
        [Route("api/Inicio/GetDL_Productos2")]
        public void DL_Productos2(UDetalle_pedido det_pedido){
            new LInicio().DL_Productos2(det_pedido);
        }
        //
        /// <summary>
        /// Este metodo nos permite saber cuantos pedidos tenemos en el carrito
        /// </summary>
        /// <param name="idusuario"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/Inicio/Getmostrarcantidadtotal")]
        public string mostrarcantidadtotal(int idusuario){

            return new LInicio().mostrarcantidadtotal(idusuario);

        }
        //
        //
        /// <summary>
        /// Este servicio nos permite Agregar un pedido al carrito
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/Inicio/AgregarPedidoCarrito")]
        public string AgregarPedidoCarrito([FromBody] JObject Vs_entrada)
        {
            UDetalle_pedido UdetallePedido = new UDetalle_pedido();
            UPedido Uped = new UPedido();
            //upedido
            string mensaje;
            Uped.Cliente_id = int.Parse(Vs_entrada["Cliente_id"].ToString());
            Uped.Fecha = DateTime.Now;
            Uped.Estado_id = 1;
            Uped.Aliado_id = int.Parse(Vs_entrada["Aliado_id"].ToString());
            Uped.Domiciliario_id = 1;
            Uped.Estado_pedido = 0;
            Uped.Estado_domicilio_id = 1;
            if (Uped == null)
            {
                mensaje = "pedido o detalle del pedido vacio";
            }
            else
            {
                new LInicio().AgregarPedidoCarrito1(Uped);
                mensaje = "pedido agregado exitosamente";
            }
            //detalle pedido
            UdetallePedido.Pedido_id = Uped.Id_pedido;
            UdetallePedido.Descripcion = Vs_entrada["Descripcion"].ToString();
            UdetallePedido.V_unitario = double.Parse(Vs_entrada["V_unitario"].ToString());
            UdetallePedido.Cantidad = int.Parse(Vs_entrada["Cantidad"].ToString());
            UdetallePedido.Producto_id = int.Parse(Vs_entrada["Producto_id"].ToString());
            UdetallePedido.Direccion_cliente = Vs_entrada["Direccion_cliente"].ToString();
            UdetallePedido.Telefono_cliente = Vs_entrada["Telefono_cliente"].ToString();
            double valorUnitario, resultado;
            int cantidad;
            valorUnitario = double.Parse(Vs_entrada["V_unitario"].ToString());
            cantidad = int.Parse(Vs_entrada["Cantidad"].ToString());
            resultado = valorUnitario * cantidad;
            UdetallePedido.V_total = resultado;
           
            if(UdetallePedido==null)
            {
                mensaje = "pedido o detalle del pedido vacio";
            }
            else
            {
                new LInicio().AgregarPedidoCarrito2(UdetallePedido);
                mensaje = "pedido agregado exitosamente";
            }

            return mensaje;
           

        }
        //
    }
}
