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
        [Route("api/comunicacion/getMostrarProductoInicio")]
        public List<UProducto> GetMostrarProductoInicio()
        {
            return new LComunicacion().MostrarProductoInicio();
        }

        [HttpGet]
        [Route("api/comunicacion/getMostrarProductoInicioBusqueda")]
        public List<UProducto> GetProductoInicioBusqueda(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioBusqueda(busqueda);
        }

        
        [HttpGet]
        [Route("api/comunicacion/RangoPrecios")]
        public List<UProducto> GetRangoPrecios(double ValorMinimo,double ValorMaximo)
        {
            return new LComunicacion().RangoPrecios(ValorMinimo, ValorMaximo);
        }
        
        //R 
        [HttpGet]
        [Route("api/comunicacion/MostrarProductoInicioActividad")]
        public List<UProducto> GetMostrarProductoInicioActividad(string busqueda)
        {
            return new LComunicacion().MostrarProductoInicioActividad(busqueda);
        }





        //Apis Pedidos Aliado OK
        [HttpGet]
        [Route("api/comunicacion/EstadoPedidos")]
        public List<UEstado_pedido> GetEstadoPedidos()
        {
            return new LComunicacion().EstadoPedidos();
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


        //administrador
        [HttpPost]
        [Route("api/comunicacion/MostrarSolicitudAliado")]
        public List<UUsuario> PostMostrarSolicitudAliado()
        {
            return new LComunicacion().MostrarSolicitudAliado();
        }

         [HttpPost]
         [Route("api/comunicacion/MostrarProducto")]
         public List<UProducto> PostMostrarProducto(UUsuario consulta)
        {
            return new LComunicacion().MostrarProducto(consulta);
        }

    }
}
