using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Utilitarios;
using Logica;
using System.Web.Http.Cors;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a los servicios de Comunicacion
    /// </summary>
    [EnableCors("*", "*", "*")]
    [Route("api/[controller]")]
    public class ComunicacionController : ApiController{
        /// <summary>
        /// Mostrar producto inicio
        /// </summary>
        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicio")]
        public List<UProducto> GetMostrarProductoInicio()
        {
            List<UProducto> producto = new List<UProducto>();
            try
            {
                producto = new LComunicacion().MostrarProductoInicio();
            }
            catch { }

            return producto;
        }
        /// <summary>
        /// Mostrar productos inicio por busqueda
        /// </summary>
        /// <param name="busqueda"></param>
        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicioBusqueda")]
        public List<UProducto> GetProductoInicioBusqueda(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioBusqueda(busqueda);
        }
        /// <summary>
        /// Mostrar productos Inicio por rangos de precios
        /// </summary>
        /// <param name="ValorMinimo"></param>
        /// <param name="ValorMaximo"></param>

        [HttpGet]
        [Route("api/comunicacion/GetRangoPrecios")]
        public List<UProducto> GetRangoPrecios(double ValorMinimo,double ValorMaximo)
        {
            return new LComunicacion().RangoPrecios(ValorMinimo, ValorMaximo);
        }

        /// <summary>
        /// Mostrar productos Inicio por actividad comercial
        /// </summary>
        /// <param name="busqueda"></param>
        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicioActividad")]
        public List<UProducto> GetMostrarProductoInicioActividad(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioActividad(busqueda);
        }

        //administrador

        /// <summary>
        /// Mostrar Solicitud Aliado
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliado")]
        public List<UUsuario> GetMostrarSolicitudAliado()
        {
            return new LComunicacion().MostrarSolicitudAliado();
        }
        /// <summary>
        /// Mostrar Solicitud Domiciliario
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comununicacion/GetMostrarSolicitudDomiciliario")]
        public List<UUsuario> MostrarSolicitudDomiciliario()
        {
            return new LComunicacion().MostrarSolicitudDomiciliario();
        }
        /// <summary>
        /// Mostrar Solicitud Aliado Rechazado
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliadoRechazado")]
        public List<UUsuario> MostrarSolicitudAliadoRechazado()
        {
            return new LComunicacion().MostrarSolicitudAliadoRechazado();
        }
        /// <summary>
        /// Mostrar Solicitud Domiciliario Rechazado
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudDomiciliarioRechazado")]
        public List<UUsuario> MostrarSolicitudDomiciliarioRechazado()
        {
            return new LComunicacion().MostrarSolicitudDomiciliarioRechazado();
        }
        /// <summary>
        /// Mostrar Solicitud Aliado Aceptado
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliadoAceptado")]
        public List<UUsuario> MostrarSolicitudAliadoAceptado()
        {
            return new LComunicacion().MostrarSolicitudAliadoAceptado();
        }
        /// <summary>
        /// Mostrar Solicitud Domiciliario Aceptado
        /// </summary>
        /// 
        [Authorize]
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudDomiciliarioAceptado")]
        public List<UUsuario> MostrarSolicitudDomiciliarioAceptado()
        {
            return new LComunicacion().MostrarSolicitudDomiciliarioAceptado();
        }

        //aliado

        /// <summary>
        /// Mostrar productos aliados
        /// </summary>
        /// <param name="consulta"></param>
        /// 

        [HttpPost]
        [Route("api/comunicacion/MostrarProducto")]
        public List<UProducto> PostMostrarProducto(UUsuario consulta)
        {
            return new LComunicacion().MostrarProducto(consulta);
        }
        /// <summary>
        /// Mostrar productos desactivado aliados
        /// </summary>
        /// <param name="consulta"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostMostrarProductoDesactivado")]
        public List<UProducto> MostrarProductoDesactivado(UUsuario consulta)
        {
            return new LComunicacion().MostrarProductoDesactivado(consulta);
        }

        //carrito

        /// <summary>
        /// Obtener Pedido Usuario
        /// </summary>
        /// <param name="usuariopedido"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerPedidoUsuario")]
        public List<UPedido> ObtenerPedidoUsuario(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerPedidoUsuario(usuariopedido);
        }


        //domiciliario

        /// <summary>
        /// Estado domicilio
        /// </summary>
        /// 
        [HttpPost]
        [Route("api/comunicacion/EstadoDomicilios")]
        public List<Uestado_domicilio> PostEstadoDomicilios()
        {
            return new LComunicacion().EstadoDomicilios();
        }
        /// <summary>
        /// Obtener Pedido Domiciliario
        /// </summary>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerPedidoDomiciliario")]
        public List<UPedido> PostObtenerPedidoDomiciliario()
        {
            return new LComunicacion().ObtenerPedidoDomiciliario();
        }
        /// <summary>
        ///  Obtener Mi Pedido Domiciliario
        /// </summary>
        /// <param name="usuario"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerMiPedidoDomiciliario")]
        public List<UPedido> PostObtenerMiPedidoDomiciliario(UUsuario usuario)
        {
            return new LComunicacion().ObtenerMiPedidoDomiciliario(usuario);
        }
        /// <summary>
        ///  Obtener Mi Pedidos Entregados Domiciliario
        /// </summary>
        /// <param name="usuario"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerMiPedidosEntregadosDomiciliario")]
        public List<UPedido> PostObtenerMiPedidosEntregadosDomiciliario(UUsuario usuario)
        {
            return new LComunicacion().ObtenerMiPedidosEntregadosDomiciliario(usuario);
        }

        //pedidos aliado

        /// <summary>
        ///  Estado Pedido
        /// </summary>
        [HttpGet]
        [Route("api/comunicacion/EstadoPedidos")]
        public List<UEstado_pedido> GetEstadoPedidos()
        {
            return new LComunicacion().EstadoPedidos();
        }
        /// <summary>
        ///  Obtener Estado Pedido
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedido")]
        public List<UPedido> ObtenerEstadoPedido(UUsuario usuario)
        {
            return new LComunicacion().ObtenerEstadoPedido(usuario);
        }
        /// <summary>
        /// Obtener Estado Pedido Terminado
        /// </summary>
        /// <param name="usuario"></param>
        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedidoTerminado")]
        public List<UPedido> ObtenerEstadoPedidoTerminado(UUsuario usuario)
        {
            return new LComunicacion().ObtenerEstadoPedidoTerminado(usuario);
        }

        //pedidos cliente

        /// <summary>
        /// Obtener Compras Usuario
        /// </summary>
        /// <param name="usuariopedido"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerComprasUsuario")]
        public List<UPedido> ObtenerComprasUsuario(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerComprasUsuario(usuariopedido);
        }
        /// <summary>
        /// Obtener Compras Usuario Entregado
        /// </summary>
        /// <param name="usuariopedido"></param>
        /// 
        [Authorize]
        [HttpPost]
        [Route("api/comunicacion/PostObtenerComprasUsuarioEntregado")]
        public List<UPedido> ObtenerComprasUsuarioEntregado(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerComprasUsuarioEntregado(usuariopedido);
        }


    }
}
