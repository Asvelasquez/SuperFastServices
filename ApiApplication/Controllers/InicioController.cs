using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers {
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
        [HttpGet]
        [Route("api/Inicio/Getmostrarcantidadtotal")]
        public string mostrarcantidadtotal(int idusuario){

            return new LInicio().mostrarcantidadtotal(idusuario);

        }
        //
    }
}
