using System;
using System.Collections.Generic;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using System.Web.Http.Description;

namespace ApiApplication.Controllers
{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Inicio
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class InicioController : ApiController{

        /// <summary>
        /// Este metodo nos permite ver la lista de los productos
        /// datos de ingreso
        /// idcliente
        /// idaliado
        /// descripcion
        /// valorunitario
        /// cantidad
        /// productoid
        /// direccioncliente
        /// telefonocliente
        /// </summary>
        /// <param name="Vs_entrada"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/Inicio/AgregarPedidosCarrito")]
        public string AgregarPedidosCarrito([FromBody] JObject Vs_entrada)
        {
            string respuesta;
            double valorunitario, resultado;
            int cantidad5;
            try
            {

                if (!ModelState.IsValid) {
                    string error = "Datos incorrectos.";
                    foreach (var state in ModelState) {
                        foreach (var item in state.Value.Errors)  {
                            error += $" {item.ErrorMessage}";
                        }
                    }
                    respuesta= error;
                }//
                if (String.IsNullOrEmpty(Vs_entrada.ToString()))
                {
                    respuesta= "Alguna de las variables requeridas viene vacia o null, intentelo de nuevo";
                }
                else
                {
                    List<UPedido> ped20 = new List<UPedido>();
                    UPedido pedido3 = new UPedido();
                    UDetalle_pedido det_pedido = new UDetalle_pedido();
                    ped20 = new LInicio().DL_Productos1(int.Parse(Vs_entrada["idcliente"].ToString()));
                    int contador = 0;
                    foreach (var item in ped20)
                    {
                        if (item.Aliado_id == int.Parse(Vs_entrada["idaliado"].ToString()))
                        {
                            try
                            {
                                det_pedido.Pedido_id = item.Id_pedido;
                                det_pedido.Descripcion = Vs_entrada["descripcion"].ToString();
                                det_pedido.V_unitario = double.Parse(Vs_entrada["valorunitario"].ToString());
                                det_pedido.Cantidad = int.Parse(Vs_entrada["cantidad"].ToString());
                                det_pedido.Producto_id = int.Parse(Vs_entrada["productoid"].ToString());
                                det_pedido.Direccion_cliente = Vs_entrada["direccioncliente"].ToString();
                                det_pedido.Telefono_cliente = Vs_entrada["telefonocliente"].ToString();                              
                                valorunitario = double.Parse(Vs_entrada["valorunitario"].ToString());
                                cantidad5 = int.Parse(Vs_entrada["cantidad"].ToString());
                                resultado = valorunitario * cantidad5;
                                det_pedido.V_total = resultado;
                                pedido3.Id_pedido = item.Id_pedido;
                                pedido3.Valor_total = item.Valor_total+resultado;
                                new LInicio().actualizarPrecioPedido(pedido3);
                                new LInicio().DL_Productos2(det_pedido);
                                contador++;

                            }
                            catch (Exception) { throw; }
                        }

                    }
                    //
                    if (contador == 0)
                    {
                        try
                        {
                            pedido3.Cliente_id = int.Parse(Vs_entrada["idcliente"].ToString());
                            pedido3.Fecha = DateTime.Now;
                            pedido3.Estado_id = 1;//1) posible compra 2)comprado 3)cancelado
                            pedido3.Aliado_id = int.Parse(Vs_entrada["idaliado"].ToString());
                            pedido3.Domiciliario_id = 1;
                            pedido3.Estado_pedido = 0;// 0) posible compra 1)comprado 2)cancelado
                            pedido3.Estado_domicilio_id = 1;
                            valorunitario = double.Parse(Vs_entrada["valorunitario"].ToString());
                            cantidad5 = int.Parse(Vs_entrada["cantidad"].ToString());
                            resultado = valorunitario * cantidad5;
                            pedido3.Valor_total = resultado;
                            new LInicio().DL_Productos3(pedido3);
                            det_pedido.Pedido_id = pedido3.Id_pedido;
                            det_pedido.Descripcion = Vs_entrada["descripcion"].ToString();
                            det_pedido.V_unitario = double.Parse(Vs_entrada["valorunitario"].ToString());
                            det_pedido.Cantidad = int.Parse(Vs_entrada["cantidad"].ToString());
                            det_pedido.Producto_id = int.Parse(Vs_entrada["productoid"].ToString());
                            det_pedido.Direccion_cliente = Vs_entrada["direccioncliente"].ToString();
                            det_pedido.Telefono_cliente = Vs_entrada["telefonocliente"].ToString();
                            
                            valorunitario = double.Parse(Vs_entrada["valorunitario"].ToString());
                            cantidad5 = int.Parse(Vs_entrada["cantidad"].ToString());
                            resultado = valorunitario * cantidad5;
                            det_pedido.V_total = resultado;
                            new LInicio().DL_Productos2(det_pedido);

                        }
                        catch (Exception ex)
                        { throw; }//
                    }
                    //
                    respuesta = "Pedido agregado correctamente";
                }
            }
            catch (Exception ex)
            { respuesta= "hay un problema interno: " + ex.StackTrace; }

            return respuesta;


        }

        //
        /// <summary>
        /// Este metodo nos permite saber cuantos pedidos tenemos en el carrito
        /// parametros de ingreso:
        /// idusuario
        /// </summary>
        /// <param name="idusuario"></param>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/Inicio/Getmostrarcantidadtotal")]
        public IHttpActionResult mostrarcantidadtotal(int idusuario){
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


                if (idusuario == 0)
                {
                    return BadRequest("Alguna de las variables requeridas viene vacia o null, intentelo de nuevo");
                }
                else
                {

                    return Ok(  new LInicio().mostrarcantidadtotal(idusuario));
                }
            }
            catch (Exception ex)
            {
                return BadRequest("hay un problema interno: " + ex.StackTrace);
            }
           

        }
     
    }
}
