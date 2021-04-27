using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;

namespace Logica
{
   
     public class LComunicacion
    {
        //Inicio
        public List<UProducto> MostrarProductoInicio()
        {
            return new DAOProductos().mostrarproductoinicio();
           
        }
        public List<UProducto> MostrarProductoInicioBusqueda(string busqueda)
        {
            
            return new DAOProductos().mostrarproductoiniciobusqueda(busqueda);
        }
        public List<UProducto> RangoPrecios(double ValorMinimo, double ValorMaximo)
        {
            return new DAOProductos().rangoPrecios(ValorMinimo, ValorMaximo);
        }
        public List<UProducto> MostrarProductoInicioActividad(string busqueda)
        {
            return new DAOProductos().mostrarproductoinicioactividad(busqueda);
        }

        //administrador
        public List<UUsuario> MostrarSolicitudAliado()
        {
            return new DAOUsuario().mostrarsolicitudaliado();
        }
        
        public List<UUsuario> MostrarSolicitudDomiciliario()
        {
            return new DAOUsuario().mostrarsolicituddomiciliario();
        }
           
        public List<UUsuario> MostrarSolicitudAliadoRechazado()
        {
            return new DAOUsuario().mostrarsolicitudaliadorechazado();
        }
        
        public List<UUsuario> MostrarSolicitudDomiciliarioRechazado()
        {
            return new DAOUsuario().mostrarsolicituddomiciliariorechazado();
        }
        
        public List<UUsuario> MostrarSolicitudAliadoAceptado()
        {
            return new DAOUsuario().mostrarsolicitudaliadoaceptado();
        }
        
        public List<UUsuario> MostrarSolicitudDomiciliarioAceptado()
        {
            return new DAOUsuario().mostrarsolicituddomiciliarioaceptado();
        }

        //aliado 
        public List<UProducto>MostrarProducto(UUsuario consulta)
        {
            return new DAOProductos().mostrarproducto(consulta);
        }

        public List<UProducto>MostrarProductoDesactivado(UUsuario consulta)
        {
            return new DAOProductos().mostrarproductodesactivado(consulta);
        }

        //carrito
        public List<UPedido> ObtenerPedidoUsuario(UUsuario usuariopedido)
        {
            return new DAOPedido().obtenerPedidoUsuario(usuariopedido);
        }

        //domiciliario
        public List<Uestado_domicilio> EstadoDomicilios()
        {
            return new DAOProductos().estado_Domicilios();
        }

       public List<UPedido> ObtenerPedidoDomiciliario()
        {
            return new DAOPedido().obtenerPedidoDomiciliario();
        }

        public List<UPedido> ObtenerMiPedidoDomiciliario(UUsuario usuario4)
        {
            return new DAOPedido().obtenermiPedidoDomiciliario(usuario4);
        }

        public List<UPedido> ObtenerMiPedidosEntregadosDomiciliario(UUsuario usuario4)
        {
            return new DAOPedido().obtenermiPedidosentregadosDomiciliario(usuario4);
        }

        //pedidos aliado
        public List<UEstado_pedido> EstadoPedidos()
        {
            return new DAOProductos().estado_Pedidos();
        }

        public List<UPedido> ObtenerEstadoPedido(UUsuario usuario2)
        {
            return new DAOPedido().obtenerEstadoPedido(usuario2);
        }

       public List<UPedido> ObtenerEstadoPedidoTerminado(UUsuario usuario3)
        {
            return new DAOPedido().obtenerEstadoPedidoterminado(usuario3);
        }

        //pedidos cliente
        public List<UPedido> ObtenerComprasUsuario(UUsuario usuariopedido)
        {
            return new DAOPedido().obtenercomprasUsuario(usuariopedido);
        }
        public List<UPedido> ObtenerComprasUsuarioEntregado(UUsuario usuariopedido)
        {
            return new DAOPedido().obtenercomprasUsuarioentregado(usuariopedido);
        }
    }
}
