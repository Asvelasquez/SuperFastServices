using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Utilitarios;

/// <summary>
/// Descripción breve de DAOPedido
/// </summary>
/// 

namespace Data{
    public class DAOPedido{

        public UPedido insertPedido(UPedido pedido2) {
            using (var db = new Mapeo())  {
                db.pedido1.Add(pedido2);
                db.SaveChanges();
                return pedido2;
            }
        }//


        ////////////////////////
        public List<UPedido> obtenerPedidoUsuario(UUsuario usuariopedido)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join aliado in db.usuari on ped.Aliado_id equals aliado.Id
                          where ped.Cliente_id == usuariopedido.Id && ped.Estado_pedido == 0
                          //   where ped.Estado_id != 5 && ped.Estado_pedido == 1
                          select new
                          {
                              p,
                              ped,
                              ed,
                              aliado
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.aliado.Nombre

                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = obtenerDetallepedido(item.Id_pedido);
            }
            return pedido;
        }

        public List<UDetalle_pedido> obtenerDetallepedido(int pedidoId)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == pedidoId
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto
                        }).ToList();
            }
        }
        //////////////////////////

        //////////////////////////obtenerpedidocomprados
        public List<UPedido> obtenercomprasUsuario(UUsuario usuariopedido)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join aliado in db.usuari on ped.Aliado_id equals aliado.Id
                          where ped.Cliente_id == usuariopedido.Id && ped.Estado_pedido == 1
                          //   where ped.Estado_id != 5 && ped.Estado_pedido == 1
                          select new
                          {
                              p,
                              ped,
                              ed,
                              aliado
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.aliado.Nombre

                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = obtenerDetallepedidocompras(item.Id_pedido);
            }
            return pedido;
        }

        public List<UDetalle_pedido> obtenerDetallepedidocompras(int pedidoId)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == pedidoId
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto
                        }).ToList();
            }
        }
        /////////////////////obtenerpedidocomprados

        ///////////////////////////// 
        public List<UPedido> obtenercomprasUsuarioentregado(UUsuario usuariopedido)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join aliado in db.usuari on ped.Aliado_id equals aliado.Id
                          where ped.Cliente_id == usuariopedido.Id && ped.Estado_pedido == 1 && ped.Estado_domicilio_id == 4
                          select new
                          {
                              p,
                              ped,
                              ed,
                              aliado
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.aliado.Nombre

                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = obtenerDetallepedidocomprasentregado(item.Id_pedido);
            }
            return pedido;
        }

        public List<UDetalle_pedido> obtenerDetallepedidocomprasentregado(int pedidoId)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == pedidoId
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto
                        }).ToList();
            }
        }
        /////////////////////////////////// 



        public void actualizarPedido(UPedido pedido2, int estadopedido2)
        {
            using (var db = new Mapeo())
            {
                UPedido pedidoanterior = db.pedido1.Where(x => x.Id_pedido == pedido2.Id_pedido).First();
                pedidoanterior.Estado_id = estadopedido2;

                db.pedido1.Attach(pedidoanterior);
                var entry = db.Entry(pedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//


        public void actualizarPedidoDomiciliario(UPedido pedido2, int estadopedido2)
        {
            using (var db = new Mapeo())
            {
                UPedido pedidoanterior = db.pedido1.Where(x => x.Id_pedido == pedido2.Id_pedido).First();
                pedidoanterior.Domiciliario_id = pedido2.Domiciliario_id;
                pedidoanterior.Estado_domicilio_id = estadopedido2;

                db.pedido1.Attach(pedidoanterior);
                var entry = db.Entry(pedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//
         //public List<Pedido>  obtenercarrito(/*int usuariop*/)
         //{
         //    Pedido pedido = new Pedido();
         //    using (var db = new Mapeo())
         //    {
         //     return     (from p in db.pedido1
         //                  join u in db.usuari on p.Cliente_id equals u.Id
         //             //     where p.Cliente_id == usuariop

        //                  select new
        //                  {
        //                      p,
        //                      u,


        //                  }).ToList().Select(m => new Pedido
        //                  {
        //                      Cliente_id = m.p.Cliente_id,
        //                      Fecha = m.p.Fecha,


        //                  }).ToList();
        //    }

        //  //  pedido.Compras = obtenerDetalleFactura(pedido.Id_pedido);

        //    //return  pedido;
        //}

        //public List<Detalle_pedido> obtenerDetalleFactura(/*int pedidoId*/)
        //{
        //    using (var db = new Mapeo())
        //    {
        //        return (from dp in db.detpedido
        //                join p in db.producto on dp.Producto_id equals p.Id
        //              //  where dp.Pedido_id == pedidoId

        //                select new
        //                {
        //                    p,
        //                    dp


        //                }).ToList().Select(m => new Detalle_pedido
        //                {

        //                    Nombre_producto = m.p.Nombre_producto,
        //                    Cantidad = m.dp.Cantidad,
        //                    V_unitario = m.dp.V_unitario

        //                }).ToList();
        //    }
        //}

        /// /////////////////////////////////obtener pedido 

        public List<UPedido> obtenerEstadoPedidoU(UUsuario usuario2)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          //  where dp.Pedido_id == pedidoId
                          where ped.Estado_id != 5 && ped.Estado_pedido == 1 && ped.Aliado_id == usuario2.Id
                          select new
                          {
                              p,
                              ped

                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total

                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = mostrarpedidoaliado(item.Id_pedido);
            }
            return pedido;
        }
        public List<UDetalle_pedido> mostrarpedidoaliado(int idpedido)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == idpedido
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto
                        }).ToList();
            }
            //  return new Mapeo().pedido1.Where(x =>  x.Estado_pedido == 0).ToList<Pedido>();
        }//
         /////////////////////////////////cierre obtener pedido 

        ///////////////////
        public List<UPedido> obtenerEstadoPedidoterminado(UUsuario usuario3)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          where ped.Estado_id == 5 && ped.Estado_pedido == 1 && ped.Aliado_id == usuario3.Id
                          select new
                          {
                              p,
                              ped
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total

                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = mostrarpedidoaliadoterminado(item.Id_pedido);
            }
            return pedido;
        }
        public List<UDetalle_pedido> mostrarpedidoaliadoterminado(int idpedido)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == idpedido
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto
                        }).ToList();
            }
            //  return new Mapeo().pedido1.Where(x =>  x.Estado_pedido == 0).ToList<Pedido>();
        }//
         /////////////////PEDIDOS DISPONIBLES
        public List<UPedido> obtenerPedidoDomiciliario()
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join usaliado in db.usuari on ped.Aliado_id equals usaliado.Id
                          join uscliente in db.usuari on ped.Cliente_id equals uscliente.Id
                          where ped.Estado_id == 5 && ped.Estado_pedido == 1 && ped.Estado_domicilio_id == 1
                          select new
                          {
                              p,
                              ped,
                              ed,
                              usaliado,
                              uscliente
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.usaliado.Nombre,
                              Direccion_aliado = m.usaliado.Direccion,
                              Nombre_cliente = m.uscliente.Nombre,
                              Direccion_cliente = m.uscliente.Direccion,
                              Telefono_cliente = m.uscliente.Telefono
                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = mostrarpedidoDomiciliario(item.Id_pedido);
            }
            return pedido;
        }
        public List<UDetalle_pedido> mostrarpedidoDomiciliario(int idpedido)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == idpedido
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto,
                        }).ToList();
            }
        }//
         ////////////////////////
         /////////////////MIS PEDIDOS 
        public List<UPedido> obtenermiPedidoDomiciliario(UUsuario usuario4)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join usaliado in db.usuari on ped.Aliado_id equals usaliado.Id
                          join uscliente in db.usuari on ped.Cliente_id equals uscliente.Id
                          where ped.Estado_id == 5 && ped.Estado_pedido == 1 && ped.Domiciliario_id == usuario4.Id && ped.Estado_domicilio_id > 1 && ped.Estado_domicilio_id < 4
                          select new
                          {
                              p,
                              ped,
                              ed,
                              usaliado,
                              uscliente
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.usaliado.Nombre,
                              Direccion_aliado = m.usaliado.Direccion,
                              Nombre_cliente = m.uscliente.Nombre,
                              Direccion_cliente = m.uscliente.Direccion,
                              Telefono_cliente = m.uscliente.Telefono
                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = mostrarmipedidoDomiciliario(item.Id_pedido);
            }
            return pedido;
        }
        public List<UDetalle_pedido> mostrarmipedidoDomiciliario(int idpedido)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == idpedido
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto,
                        }).ToList();
            }
        }//
         ////////////////////////
         /////////////////MI historial domciliario
        public List<UPedido> obtenermiPedidosentregadosDomiciliario(UUsuario usuario4)
        {
            List<UPedido> pedido = new List<UPedido>();
            using (var db = new Mapeo())
            {
                pedido = (from ped in db.pedido1
                          join p in db.estpedido on ped.Estado_id equals p.Id
                          join ed in db.estdomicilio on ped.Estado_domicilio_id equals ed.Id
                          join usaliado in db.usuari on ped.Aliado_id equals usaliado.Id
                          join uscliente in db.usuari on ped.Cliente_id equals uscliente.Id
                          where ped.Estado_id == 5 && ped.Estado_pedido == 1 && ped.Domiciliario_id == usuario4.Id && ped.Estado_domicilio_id == 4
                          select new
                          {
                              p,
                              ped,
                              ed,
                              usaliado,
                              uscliente
                          }).ToList().Select(m => new UPedido
                          {
                              Id_pedido = m.ped.Id_pedido,
                              Aliado_id = m.ped.Aliado_id,
                              Nombre_estado_ped = m.p.Nombre,
                              Cliente_id = m.ped.Cliente_id,
                              Comentario_aliado = m.ped.Comentario_aliado,
                              Comentario_cliente = m.ped.Comentario_cliente,
                              Domiciliario_id = m.ped.Domiciliario_id,
                              Estado_id = m.ped.Estado_id,
                              Estado_pedido = m.ped.Estado_pedido,
                              Fecha = m.ped.Fecha,
                              Valor_total = m.ped.Valor_total,
                              Nombre_estado_domicilio = m.ed.Nombre,
                              Nombre_aliado = m.usaliado.Nombre,
                              Direccion_aliado = m.usaliado.Direccion,
                              Nombre_cliente = m.uscliente.Nombre,
                              Direccion_cliente = m.uscliente.Direccion,
                              Telefono_cliente = m.uscliente.Telefono
                          }).ToList();
            }
            foreach (var item in pedido)
            {
                item.Compras = mostrarmipedidoentregadoDomiciliario(item.Id_pedido);
            }
            return pedido;
        }
        public List<UDetalle_pedido> mostrarmipedidoentregadoDomiciliario(int idpedido)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join dp in db.detpedido on p.Id equals dp.Producto_id
                        where dp.Pedido_id == idpedido
                        select new
                        {
                            dp,
                            p,
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Pedido_id = m.dp.Pedido_id,
                            Id_dpedido = m.dp.Id_dpedido,
                            Direccion_cliente = m.dp.Direccion_cliente,
                            Telefono_cliente = m.dp.Telefono_cliente,
                            Producto_id = m.dp.Producto_id,
                            Cantidad = m.dp.Cantidad,
                            Descripcion = m.dp.Descripcion,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                            Nombreprodet = m.p.Nombre_producto,
                            Especprodaliado = m.p.Descripcion_producto,
                        }).ToList();
            }
        }//
         ////////////////////////

        public void comprarproducto(UPedido pedido5)
        {
            using (var db = new Mapeo())
            {
                UPedido pedidoanterior = db.pedido1.Where(x => x.Id_pedido == pedido5.Id_pedido).First();

                pedidoanterior.Estado_pedido = 1;
                db.pedido1.Attach(pedidoanterior);
                var entry = db.Entry(pedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();

            }//
        }//
         //
        public void comprarproductodetalle(UDetalle_pedido de_pedido5)
        {
            using (var db = new Mapeo())
            {
                UDetalle_pedido dpedidoanterior = db.detpedido.Where(x => x.Id_dpedido == de_pedido5.Id_dpedido).First();


                dpedidoanterior.Cantidad = de_pedido5.Cantidad;
                dpedidoanterior.Direccion_cliente = de_pedido5.Direccion_cliente;
                dpedidoanterior.Telefono_cliente = de_pedido5.Telefono_cliente;
                db.detpedido.Attach(dpedidoanterior);
                var entry = db.Entry(dpedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();

            }//
        }//
         //

        public void deletepedido(UPedido pedidoborar)
        {
            using (var db = new Mapeo())
            {
                UPedido pedido8 = db.pedido1.Where(x => x.Id_pedido == pedidoborar.Id_pedido).First();
                db.pedido1.Remove(pedido8);
                db.SaveChanges();
            }
        }//

        public List<UPedido> mostrarproducto(UUsuario consulta)
        {
            return new Mapeo().pedido1.Where(x => x.Comentario_aliado == consulta.Correo && x.Estado_pedido == 1).ToList<UPedido>();

        }
        //
        public void guardarcomentario(UPedido pedido2)
        {
            using (var db = new Mapeo())
            {
                UPedido comentarioanterior = db.pedido1.Where(x => x.Id_pedido == pedido2.Id_pedido).First();
                comentarioanterior.Comentario_aliado = pedido2.Comentario_aliado;
                db.pedido1.Attach(comentarioanterior);
                var entry = db.Entry(comentarioanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //
        //////////////////
        public void guardarcomentariocliente(UPedido pedido2)
        {
            using (var db = new Mapeo())
            {
                UPedido comentarioanterior = db.pedido1.Where(x => x.Id_pedido == pedido2.Id_pedido).First();
                comentarioanterior.Comentario_cliente = pedido2.Comentario_cliente;
                db.pedido1.Attach(comentarioanterior);
                var entry = db.Entry(comentarioanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        //
        ////////////////////

        public UPedido obtenerFactura(int noFactura)
        {
            UPedido pedido = new UPedido();
            using (var db = new Mapeo())
            {
                pedido = (from p in db.pedido1
                          join u in db.usuari on p.Cliente_id equals u.Id
                          where p.Id_pedido == noFactura

                          select new
                          {
                              p,
                              u,


                          }).ToList().Select(m => new UPedido
                          {
                              Fecha = m.p.Fecha,
                              Id_pedido = m.p.Id_pedido,
                              Nombre_cliente = m.u.Nombre,
                              Cliente_id = m.p.Cliente_id,
                              Valor_total = m.p.Valor_total,


                          }).FirstOrDefault();
            }
            pedido.Compras = obtenerDetalleFactura(pedido.Id_pedido);
            return pedido;
        }

        public List<UDetalle_pedido> obtenerDetalleFactura(int pedidoId)
        {
            using (var db = new Mapeo())
            {
                return (from dp in db.detpedido
                        join p in db.producto on dp.Producto_id equals p.Id
                        where dp.Pedido_id == pedidoId

                        select new
                        {
                            p,
                            dp
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Nombreprodet = m.p.Nombre_producto,
                            Cantidad = m.dp.Cantidad,
                            V_unitario = m.dp.V_unitario,
                            V_total = m.dp.V_total,
                        }).ToList();
            }
        }

        ////////////////////////////
        public void Cancelarpedido(UPedido pedido3)
        {
            using (var db = new Mapeo())
            {
                UPedido estadopedidoanterior = db.pedido1.Where(x => x.Id_pedido == pedido3.Id_pedido).First();
                estadopedidoanterior.Estado_pedido = 2;
                db.pedido1.Attach(estadopedidoanterior);
                var entry = db.Entry(estadopedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        ////////////////////
        ///////////////
        public List<UPedido> consultarpedido(int usuario)
        {
            using (var db = new Mapeo())
            {
                return new Mapeo().pedido1.Where(x => x.Cliente_id == usuario && x.Estado_pedido == 0).ToList<UPedido>();
            }//
        }//
        public List<UPedido> preciototal(int usuario)
        {
            using (var db = new Mapeo())
            {
                return new Mapeo().pedido1.Where(x => x.Cliente_id == usuario && x.Estado_pedido == 0).ToList<UPedido>();
            }//
        }//preciototal
        public List<UPedido> PedidosTotal(int usuario)
        {
            using (var db = new Mapeo())
            {
                return new Mapeo().pedido1.Where(x => x.Cliente_id == usuario && x.Estado_pedido == 0).ToList<UPedido>();
            }//
        }//
        public List<UDetalle_pedido> precioTotal2(int uspedido)
        {
            using (var db = new Mapeo())
            {
                return new Mapeo().detpedido.Where(x => x.Pedido_id == uspedido).ToList<UDetalle_pedido>();
            }//
        }//
        public List<UPedido> pedidoscomprar(int usuario)
        {
            using (var db = new Mapeo())
            {
                return new Mapeo().pedido1.Where(x => x.Cliente_id == usuario && x.Estado_pedido == 0).ToList<UPedido>();
            }//
        }//
         //////////////
        public void actualizarcomprar(int idpedido8, UPedido pedido2)
        {
            using (var db = new Mapeo())
            {
                UPedido pedidoanterior = db.pedido1.Where(x => x.Id_pedido == idpedido8).First();
                pedidoanterior.Estado_pedido = 1;
                pedidoanterior.Valor_total = pedido2.Valor_total;
                db.pedido1.Attach(pedidoanterior);
                var entry = db.Entry(pedidoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        ///////
        public void actualizardatosentrega(int idpedido8, UDetalle_pedido detpedido)
        {
            using (var db = new Mapeo())
            {
                UDetalle_pedido datoanterior = db.detpedido.Where(x => x.Pedido_id == idpedido8).First();
                datoanterior.Telefono_cliente = detpedido.Telefono_cliente;
                datoanterior.Direccion_cliente = detpedido.Direccion_cliente;

                db.detpedido.Attach(datoanterior);
                var entry = db.Entry(datoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();

            }
        }
        ///////

        ///////
        ///
        //public ActionResult Prueba15(){
        //    int id = 68;
        //    public int id2 {
        //        get {
        //            return id;
        //        }
        //        set
        //        {
        //            id = value;
        //        }
        //    }
        //}//
        public UPedido mostrarfactura(UPedido pedido2)
        {
            UPedido pedido = new UPedido();

            return new Mapeo().pedido1.Where(x => x.Id_pedido == pedido2.Id_pedido).First();
        }


        //reporte producto mas vendido
        public List<UDetalle_pedido> productosVendidosXFecha(int id_aliado)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.pedido1
                        join dp in db.detpedido on p.Id_pedido equals dp.Pedido_id
                        join po in db.producto on dp.Producto_id equals po.Id
                        join us in db.usuari on p.Aliado_id equals us.Id
                        where p.Aliado_id == id_aliado && p.Estado_id == 5

                        select new
                        {
                            po,
                            dp,
                            us
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Nombreprodet = m.po.Nombre_producto,
                            Cantidad = m.dp.Cantidad,
                            Producto_id = m.dp.Producto_id,
                            V_unitario = m.dp.V_unitario,
                            Nombre_aliado = m.us.Nombre,

                        }).ToList();
            }
        }

        //reporte Administrador
        public List<UDetalle_pedido> productosVendidos(int Id_admin)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.pedido1
                        join dp in db.detpedido on p.Id_pedido equals dp.Pedido_id
                        join po in db.producto on dp.Producto_id equals po.Id
                        join us in db.usuari on Id_admin equals us.Id
                        where p.Estado_id == 5 && p.Estado_domicilio_id == 4

                        select new
                        {
                            po,
                            dp,
                            us
                        }).ToList().Select(m => new UDetalle_pedido
                        {
                            Nombreprodet = m.po.Nombre_producto,
                            Cantidad = m.dp.Cantidad,
                            Producto_id = m.dp.Producto_id,
                            V_unitario = m.dp.V_unitario,
                            Nombre_aliado = m.us.Nombre

                        }).ToList();
            }
        }
    }
}
