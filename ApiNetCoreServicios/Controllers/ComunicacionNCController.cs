using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicaNC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios;

namespace ApiNetCoreServicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunicacionNCController : ControllerBase
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
        public List<UProducto> GetRangoPrecios(double ValorMinimo, double ValorMaximo)
        {
            return new LComunicacion().RangoPrecios(ValorMinimo, ValorMaximo);
        }

        [HttpGet]
        [Route("api/comunicacion/GetMostrarProductoInicioActividad")]
        public List<UProducto> GetMostrarProductoInicioActividad(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioActividad(busqueda);
        }

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

        [HttpPost]
        [Route("api/comunicacion/PostObtenerPedidoUsuario")]
        public List<UPedido> ObtenerPedidoUsuario(UUsuario usuariopedido)
        {
            return new LComunicacion().ObtenerPedidoUsuario(usuariopedido);
        }

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
        public List<UPedido> ObtenerMiPedidoDomiciliario(UUsuario usuario)
        {
            return new LComunicacion().ObtenerMiPedidoDomiciliario(usuario);
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerMiPedidosEntregadosDomiciliario")]
        public List<UPedido> ObtenerMiPedidosEntregadosDomiciliario(UUsuario usuario)
        {
            return new LComunicacion().ObtenerMiPedidosEntregadosDomiciliario(usuario);
        }

        [HttpGet]
        [Route("api/comunicacion/EstadoPedidos")]
        public List<UEstado_pedido> GetEstadoPedidos()
        {
            return new LComunicacion().EstadoPedidos();
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedido")]
        public List<UPedido> ObtenerEstadoPedido(UUsuario usuario)
        {
            return new LComunicacion().ObtenerEstadoPedido(usuario);
        }

        [HttpPost]
        [Route("api/comunicacion/PostObtenerEstadoPedidoTerminado")]
        public List<UPedido> ObtenerEstadoPedidoTerminado(UUsuario usuario)
        {
            return new LComunicacion().ObtenerEstadoPedidoTerminado(usuario);
        }

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