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

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Carrito
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class CarritoController : ApiController
    {
        /// <summary>
        /// Carga la ventana de inicio
        /// </summary>
        /// <param name="usuario1"></param>
        [HttpGet]
        [Route("api/Carrito/GetLPage_Load")]
        public IHttpActionResult LPage_Load(UUsuario usuario1)
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
             
                if (usuario1==null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                   
                    return Ok(new LCarrito().LPage_Load(usuario1).Url);
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            
        }
        /// <summary>
        /// permite Cancelar un pedido
        /// datos de ingreso:
        /// Id_pedido
        /// comandname=Cancelar
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Carrito/PutLGV_pedidocarrito")]
        public IHttpActionResult LGV_pedidocarrito([FromBody]JObject Vs_entrada)
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
                UPedido pedido2 = new UPedido();
                pedido2.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
                String comandname = Vs_entrada["comandname"].ToString();
                if (Vs_entrada == null)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {

                    return Ok(new LCarrito().LGV_pedidocarrito(pedido2, comandname).Url);
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
           
         
        }


        /// <summary>
        /// permite ver el precio total del pedido
        /// datos de ingreso
        /// idusuario
        /// </summary>
        /// <param name="idusuario"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/Carrito/GetLmostrarpreciototal20")]
        public string Lmostrarpreciototal20(int idusuario)
        {
            //  try
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        string error = "Datos incorrectos.";
            //        foreach (var state in ModelState)
            //        {
            //            foreach (var item in state.Value.Errors)
            //            {
            //                error += $" {item.ErrorMessage}";
            //            }
            //        }
            //        return BadRequest(error);
            //    }

            //    if (idusuario ==0)
            //    {
            //        return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
            //    }
            //    else
            //    {

            //return Ok();
            //    }

            //}
            //catch (Exception ex)
            //{
            //  return BadRequest("hay un problema interno: " + ex.StackTrace);
            //}


            return new LCarrito().Lmostrarpreciototal20(idusuario);
        }
        /// <summary>
        /// permite ver el precio total del domicilios
        /// datos de ingreso
        /// idusuario
        /// </summary>
        /// <param name="idusuario"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/Carrito/GetLmostrarpreciodomicilio")]
        public IHttpActionResult Lmostrarpreciodomicilio(int idusuario)
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
               
                if (idusuario !=0 )//REvosp
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                  
                    return Ok(new LCarrito().Lmostrarpreciodomicilio(idusuario));
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
            
        }
        /// <summary>
        /// permite comprar lo pedidos que estan en el carrito
        /// datos de ingreso
        /// idusuario
        /// Detpedido_id
        /// Telefono_cliente
        /// Direccion_cliente
        /// Id_pedido
        /// Estado_pedido
        /// Valor_total
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPut]
        [Route("api/Carrito/ComprarProductosCarrito")]
        public IHttpActionResult ComprarProductosCarrito([FromBody]JObject Vs_entrada)
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
                int idusuario = int.Parse(Vs_entrada["idusuario"].ToString());
                UDetalle_pedido detapedido4 = new UDetalle_pedido();
                detapedido4.Pedido_id = int.Parse(Vs_entrada["Detpedido_id"].ToString());
                detapedido4.Telefono_cliente = Vs_entrada["Telefono_cliente"].ToString();
                detapedido4.Direccion_cliente = Vs_entrada["Direccion_cliente"].ToString();
                UPedido pedido4 = new UPedido();
                pedido4.Id_pedido = int.Parse(Vs_entrada["Id_pedido"].ToString());
                pedido4.Estado_pedido = int.Parse(Vs_entrada["Estado_pedido"].ToString());
                pedido4.Valor_total = double.Parse(Vs_entrada["Valor_total"].ToString());

                if (detapedido4==null || pedido4==null || idusuario==0)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {
                     new LCarrito().LBTN_comprar(idusuario, detapedido4, pedido4);
                    return Ok("los productos han sido comprados");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }

                   
           
        }

    }

}
