using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Utilitarios;

/// <summary>
/// Descripción breve de DAOProductos
/// </summary>
/// 
namespace Data
{
    public class DAOProductos
    {
        public void insertProducto(UProducto producto2)
        {
            using (var db = new Mapeo())
            {
                db.producto.Add(producto2);
                db.SaveChanges();
            }
        }//
        public List<UEstado_pedido> estado_Pedidos()
        {
            List<UEstado_pedido> lista = new Mapeo().estpedido.ToList();
            UEstado_pedido estado_pedido = new UEstado_pedido();
            estado_pedido.Id = 0;
            estado_pedido.Nombre = "--Seleccione--";
            lista.Add(estado_pedido);
            return lista.OrderBy(x => x.Id).ToList();
        }
        public List<Uestado_domicilio> estado_Domicilios()
        {
            List<Uestado_domicilio> lista = new Mapeo().estdomicilio.ToList();
            Uestado_domicilio estado_dom = new Uestado_domicilio();
            estado_dom.Id = 0;
            estado_dom.Nombre = "--Seleccione--";

            lista.Add(estado_dom);
            return lista.OrderBy(x => x.Id).ToList();
        }


        public List<UProducto> mostrarproducto(UUsuario consulta)
        {


            return new Mapeo().producto.Where(x => x.Id_aliado == consulta.Id && x.Estado_producto == 1).ToList<UProducto>();

        }//
        public List<UProducto> mostrarproductodesactivado(UUsuario consulta)
        {
            return new Mapeo().producto.Where(x => x.Id_aliado == consulta.Id && x.Estado_producto == 2).ToList<UProducto>();

        }//

        public List<UProducto> mostrarproductoinicio()
        {

            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join u in db.usuari on p.Id_aliado equals u.Id
                        where p.Estado_producto == 1
                        select new
                        {
                            p,
                            u.Nombre,

                        }).ToList().Select(m => new UProducto
                        {
                            Id = m.p.Id,
                            Nombre_producto = m.p.Nombre_producto,
                            Descripcion_producto = m.p.Descripcion_producto,
                            Precio_producto = m.p.Precio_producto,
                            Imagen_producto1 = m.p.Imagen_producto1,
                            Estado_producto = m.p.Estado_producto,
                            Id_aliado = m.p.Id_aliado,
                            Nombre_aliado = m.Nombre,


                        }).ToList();
            }

            //return new Mapeo().producto.OrderBy(x => x.Id).ToList<Producto>();
        }
        ///////////
        public List<UProducto> mostrarproductoiniciobusqueda(String busqueda)
        {

            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join u in db.usuari on p.Id_aliado equals u.Id
                        where p.Estado_producto == 1 && p.Nombre_producto.Contains(busqueda)
                        select new
                        {
                            p,
                            u.Nombre,

                        }).ToList().Select(m => new UProducto
                        {
                            Id = m.p.Id,
                            Nombre_producto = m.p.Nombre_producto,
                            Descripcion_producto = m.p.Descripcion_producto,
                            Precio_producto = m.p.Precio_producto,
                            Imagen_producto1 = m.p.Imagen_producto1,
                            Estado_producto = m.p.Estado_producto,
                            Id_aliado = m.p.Id_aliado,
                            Nombre_aliado = m.Nombre,


                        }).ToList();
            }

            // return new Mapeo().producto.Where(x => x.Nombre_producto.Contains(busqueda)).ToList();
        }
        ///////////


        /// <returns></returns>
        public List<UProducto> mostrarproductoinicioactividad(String busqueda)
        {

            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join u in db.usuari on p.Id_aliado equals u.Id
                        where p.Estado_producto == 1 && u.Actividadcomercial == busqueda
                        select new
                        {
                            p,
                            u.Nombre,

                        }).ToList().Select(m => new UProducto
                        {
                            Id = m.p.Id,
                            Nombre_producto = m.p.Nombre_producto,
                            Descripcion_producto = m.p.Descripcion_producto,
                            Precio_producto = m.p.Precio_producto,
                            Imagen_producto1 = m.p.Imagen_producto1,
                            Estado_producto = m.p.Estado_producto,
                            Id_aliado = m.p.Id_aliado,
                            Nombre_aliado = m.Nombre,


                        }).ToList();
            }

            //  return new Mapeo().usuari.Where(x => x.Actividadcomercial == busqueda).ToList();
        }
        //Filtro rango de precios
        public List<UProducto> rangoPrecios(double ValorMinimo, double ValorMaximo)
        {
            using (var db = new Mapeo())
            {
                return (from p in db.producto
                        join u in db.usuari on p.Id_aliado equals u.Id
                        where (p.Precio_producto >= ValorMinimo && p.Precio_producto <= ValorMaximo)
                        select new
                        {
                            p,
                            u.Nombre,

                        }).ToList().Select(m => new UProducto
                        {
                            Id = m.p.Id,
                            Nombre_producto = m.p.Nombre_producto,
                            Descripcion_producto = m.p.Descripcion_producto,
                            Precio_producto = m.p.Precio_producto,
                            Imagen_producto1 = m.p.Imagen_producto1,
                            Estado_producto = m.p.Estado_producto,
                            Id_aliado = m.p.Id_aliado,
                            Nombre_aliado = m.Nombre,
                        }).ToList();
            }
        }
        //////Filtro rango de precios
        public List<UProducto> mostrarimagenproducto(UUsuario consulta)
        {
            return new Mapeo().producto.Where(x => x.Id == consulta.Id).ToList<UProducto>();

        }

        public List<UProducto> mostrar()
        {
            return new Mapeo().producto.OrderBy(x => x.Id).ToList<UProducto>();
        }
        public void updateproducto(UProducto producto3)
        {
            using (var db = new Mapeo())
            {
                UProducto productoanterior = db.producto.Where(x => x.Id == producto3.Id).First();
                productoanterior.Nombre_producto = producto3.Nombre_producto;
                productoanterior.Descripcion_producto = producto3.Descripcion_producto;
                productoanterior.Precio_producto = producto3.Precio_producto;
                productoanterior.Imagen_producto1 = producto3.Imagen_producto1;
                productoanterior.Estado_producto = producto3.Estado_producto;
                db.producto.Attach(productoanterior);

                var entry = db.Entry(productoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//
        public void Desactivarproducto(UProducto producto3)
        {
            using (var db = new Mapeo())
            {
                UProducto productoanterior = db.producto.Where(x => x.Id == producto3.Id).First();

                productoanterior.Estado_producto = 2;
                db.producto.Attach(productoanterior);

                var entry = db.Entry(productoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//
        public void Activarproducto(UProducto producto3)
        {
            using (var db = new Mapeo())
            {
                UProducto productoanterior = db.producto.Where(x => x.Id == producto3.Id).First();

                productoanterior.Estado_producto = 1;
                db.producto.Attach(productoanterior);

                var entry = db.Entry(productoanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//
        public UProducto mostrar(int userId)
        {
            return new Mapeo().producto.Where(x => x.Id == userId).First();
        }
    }
}
