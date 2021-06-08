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
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Domiciliario
    /// </summary>
    [Route("api/[controller]")]
    public class DomiciliarioController : ApiController{
        /// <summary>
        /// Este metodo nos permite cambiar el estado de los domicilios pendientes de aprobar
        /// datos de ingreso:
        /// Id_pedido
        /// Domiciliario_id
        /// Estado_domicilio_id
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado")]
        public IHttpActionResult DDL_Estado([FromBody] JObject Vs_entrada)
        {
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
                pedido.Domiciliario_id = int.Parse(Vs_entrada["Domiciliario_id"].ToString());
                string idseleccion = Vs_entrada["Estado_domicilio_id"].ToString();
               
                if (String.IsNullOrEmpty(idseleccion) || pedido.Domiciliario_id ==0 || pedido.Id_pedido == 0)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                    new LDomiciliario().DDL_Estado(pedido, idseleccion);
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
        /// Este metodo nos permite cambiar el estado de los domicilios tomados "Mis pedidos"
        /// datos de ingreso
        /// Id_pedido
        /// Domiciliario_id
        /// Estado_domicilio_id
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 

        [Authorize]
        [HttpPut]
        [Route("api/Domiciliario/PutDDL_Estado0")]
        public IHttpActionResult DDL_Estado0([FromBody] JObject Vs_entrada){
           
           
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
                pedido.Domiciliario_id = int.Parse(Vs_entrada["Domiciliario_id"].ToString());
                string idseleccion = Vs_entrada["Estado_domicilio_id"].ToString();
                if (String.IsNullOrEmpty(idseleccion) || pedido.Domiciliario_id == 0 || pedido.Id_pedido == 0)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                    new LDomiciliario().DDL_Estado0(pedido, idseleccion);
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

        }
    }
        //
    
}
