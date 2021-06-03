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
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Pedidosaliado/PutLDDL_Categoria")]
        public IHttpActionResult LDDL_Categoria([FromBody] JObject Vs_entrada){
          
          
            try
            {
                if (!ModelState.IsValid)
                {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                UPedido pedido = new UPedido();
                pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
                string idseleccion = Vs_entrada["idseleccion"].ToString();

                if (Vs_entrada == null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                    new LPedidosaliado().LDDL_Categoria(pedido, idseleccion);
                    return Ok();
                  
                }
            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

        }
        //
        /// <summary>
        /// Este metodo nos permite Guerdar el comentario del aliado 
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Pedidosaliado/PutLGV_pedidos")]
        public IHttpActionResult LGV_pedidos([FromBody] JObject Vs_entrada){
          
           
            try
            {
                if (!ModelState.IsValid)
                {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState)
                    {
                        foreach (var item in state.Value.Errors)
                        {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }

                UPedido pedido = new UPedido();
                pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
                pedido.Comentario_aliado = Vs_entrada["Comentario_aliado"].ToString();
                string CommandName = Vs_entrada["CommandName"].ToString();
                if (Vs_entrada == null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                    new LPedidosaliado().LGV_pedidos(pedido, CommandName);
                    return Ok();
                   
                }
            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
        }
        //
    }
}
