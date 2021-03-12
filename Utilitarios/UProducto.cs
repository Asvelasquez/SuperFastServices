using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("productos", Schema = "informacion")]
    public class UProducto
    {
        private int id;
        private string nombre_producto;
        private string descripcion_producto;
        private double precio_producto;
        private string imagen_producto1;
        private int estado_producto;
        private int id_aliado;

        private string nombre_aliado;
        private string actividad_comercial;
        private int cantidad;
        private bool decision;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre_producto")]
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        [Column("descripcion_producto")]
        public string Descripcion_producto { get => descripcion_producto; set => descripcion_producto = value; }
        [Column("precio_producto")]
        public double Precio_producto { get => precio_producto; set => precio_producto = value; }
        [Column("imagen_producto1")]
        public string Imagen_producto1 { get => imagen_producto1; set => imagen_producto1 = value; }
        [Column("estado_producto")]
        public int Estado_producto { get => estado_producto; set => estado_producto = value; }
        [Column("id_aliado")]
        public int Id_aliado { get => id_aliado; set => id_aliado = value; }
        [NotMapped]
        public string Nombre_aliado { get => nombre_aliado; set => nombre_aliado = value; }
        [NotMapped]
        public string Actividad_comercial { get => actividad_comercial; set => actividad_comercial = value; }
        [NotMapped]
        public int Cantidad { get => cantidad; set => cantidad = value; }

        
    }
}
