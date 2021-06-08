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
        /// datos de ingreso:
        /// Id_pedido
        ///comandname= Cancelar
        /// </summary>
        /// <param name="comandname"></param>
        /// /// <param name="Id_pedido"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/PedidosCliente/GetCancelarPedidoCliente")]
        public IHttpActionResult CancelarPedidoCliente(string comandname, string Id_pedido){
            try {
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }  
                if (String.IsNullOrEmpty(Id_pedido) || String.IsNullOrEmpty(comandname) ){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new LPedidosCliente().LGV_pedidocarrito(comandname, Id_pedido);
                    return Ok("pedido cancelado");
                }
            }catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

            
        }
        //
        /// <summary>
        /// Este metodo nos permite Al cliente hacer un comentario sobre el pedido
        /// datos de ingreso:
        /// Id_pedido
        /// Comentario_cliente
        /// comandname=Guardar
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/PedidosCliente/PutLGV_pedidocarrito0")]
        public IHttpActionResult LGV_pedidocarrito0([FromBody] JObject Vs_entrada){

            try {
                if (!ModelState.IsValid){
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState){
                        foreach (var item in state.Value.Errors){
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    return BadRequest(error);
                }
                UPedido pedido = new UPedido();
                pedido.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
                pedido.Comentario_cliente = Vs_entrada["Comentario_cliente"].ToString();
                string comandname = Vs_entrada["comandname"].ToString();
                if (pedido==null || String.IsNullOrEmpty(comandname)){
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }else{
                    new LPedidosCliente().LGV_pedidocarrito0(comandname, pedido);
                    return Ok("Comentario guardado");
                }                    
            } catch (Exception ex){
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

        }
     
        //
    }
}
