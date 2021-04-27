using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Utilitarios;
using Logica;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    public class ComunicacionController : ApiController
    {
        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicio")]
        public List<UProducto> GetMostrarProductoInicio()
        {
            return new LComunicacion().MostrarProductoInicio();
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicioBusqueda")]
        public List<UProducto> GetProductoInicioBusqueda(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioBusqueda(busqueda);
        }

        
        [HttpGet]
        [Route("api/comunicacion/GetRangoPrecios")]
        public List<UProducto> GetRangoPrecios(double ValorMinimo,double ValorMaximo)
        {
            return new LComunicacion().RangoPrecios(ValorMinimo, ValorMaximo);
        }
        
        
        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicioActividad")]
        public List<UProducto> GetMostrarProductoInicioActividad(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioActividad(busqueda);
        }

        //administrador
        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliado")]
        public List<UUsuario> GetMostrarSolicitudAliado()
        {
            return new LComunicacion().MostrarSolicitudAliado();
        }

        [HttpGet]
        [Route("api/comununicacion/GetMostrarSolicitudDomiciliario")]
        public List<UUsuario> MostrarSolicitudDomiciliario()
        {
            return new LComunicacion().MostrarSolicitudDomiciliario();
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliadoRechazado")]
        public List<UUsuario> MostrarSolicitudAliadoRechazado()
        {
            return new LComunicacion().MostrarSolicitudAliadoRechazado();
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudDomiciliarioRechazado")]
        public List<UUsuario> MostrarSolicitudDomiciliarioRechazado()
        {
            return new LComunicacion().MostrarSolicitudDomiciliarioRechazado();
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudAliadoAceptado")]
        public List<UUsuario> MostrarSolicitudAliadoAceptado()
        {
            return new LComunicacion().MostrarSolicitudAliadoAceptado();
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarSolicitudDomiciliarioAceptado")]
        public List<UUsuario> MostrarSolicitudDomiciliarioAceptado()
        {
            return new LComunicacion().MostrarSolicitudDomiciliarioAceptado();
        }

        //aliado

        [HttpPost]
        [Route("api/comunicacion/MostrarProducto")]
        public List<UProducto> PostMostrarProducto(UUsuario consulta)
        {
            return new LComunicacion().MostrarProducto(consulta);
        }

        [HttpPost]
        [Route("api/comunicacion/PostMostrarProductoDesactivado")]
        public List<UProducto> MostrarProductoDesactivado(UUsuario consulta)
        {
            return new LComunicacion().MostrarProductoDesactivado(consulta);
        }

        //carrito
        [HttpPost]
        [Route("api/comunicacion/PostObtenerPedidoUsuario")]
        public List<UPedido> ObtenerPedidoUsuario(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerPedidoUsuario(usuariopedido);
        }


        //domiciliario
        [HttpPost]
        [Route("api/comunicacion/EstadoDomicilios")]
        public List<Uestado_domicilio> PostEstadoDomicilios()
        {
            return new LComunicacion().EstadoDomicilios();
        }

        [HttpPost]
        [Route("api/comunicacion/ObtenerPedidoDomiciliario")]
        public List<UPedido> PostObtenerPedidoDomiciliario()
        {
            return new LComunicacion().ObtenerPedidoDomiciliario();
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerMiPedidoDomiciliario")]
        public List<UPedido> ObtenerMiPedidoDomiciliario(UUsuario usuario4)
        {
            return new LComunicacion().ObtenerMiPedidoDomiciliario(usuario4);
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerMiPedidosEntregadosDomiciliario")]
        public List<UPedido> ObtenerMiPedidosEntregadosDomiciliario(UUsuario usuario4)
        {
            return new LComunicacion().ObtenerMiPedidosEntregadosDomiciliario(usuario4);
        }

        //pedidos aliado
        [HttpGet]
        [Route("api/comunicacion/EstadoPedidos")]
        public List<UEstado_pedido> GetEstadoPedidos()
        {
            return new LComunicacion().EstadoPedidos();
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedido")]
        public List<UPedido> ObtenerEstadoPedido(UUsuario usuario2)
        {
            return new LComunicacion().ObtenerEstadoPedido(usuario2);
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedidoTerminado")]
        public List<UPedido> ObtenerEstadoPedidoTerminado(UUsuario usuario3)
        {
            return new LComunicacion().ObtenerEstadoPedidoTerminado(usuario3);
        }

        //pedidos cliente
        [HttpPost]
        [Route("api/comunicacion/PostObtenerComprasUsuario")]
        public List<UPedido> ObtenerComprasUsuario(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerComprasUsuario(usuariopedido);
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerComprasUsuarioEntregado")]
        public List<UPedido> ObtenerComprasUsuarioEntregado(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerComprasUsuarioEntregado(usuariopedido);
        }


    }
}
