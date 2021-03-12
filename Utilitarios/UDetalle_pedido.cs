using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("detalle_pedido", Schema = "informacion")]

    public class UDetalle_pedido
    {
        private int id_dpedido;
        private int pedido_id;
        private int producto_id;
        private int cantidad;
        private string descripcion;
        private double v_unitario;
        private double v_total;
        private string direccion_cliente;
        private string telefono_cliente;
        private string nombreprodet;
        private string especprodaliado;
        private List<UPedido> compras1;
        private int idpedido;
        private string nombre_aliado;
        [Key]
        [Column("id_dpedido")]
        public int Id_dpedido { get => id_dpedido; set => id_dpedido = value; }
        [Column("pedido_id")]
        public int Pedido_id { get => pedido_id; set => pedido_id = value; }
        [Column("producto_id")]
        public int Producto_id { get => producto_id; set => producto_id = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [Column("v_unitario")]
        public double V_unitario { get => v_unitario; set => v_unitario = value; }
        [Column("v_total")]
        public double V_total { get => v_total; set => v_total = value; }
        [Column("direccion_cliente")]
        public string Direccion_cliente { get => direccion_cliente; set => direccion_cliente = value; }
        [Column("telefono_cliente")]
        public string Telefono_cliente { get => telefono_cliente; set => telefono_cliente = value; }

        [NotMapped]
        public string Nombreprodet { get => nombreprodet; set => nombreprodet = value; }

        [NotMapped]
        public string Especprodaliado { get => especprodaliado; set => especprodaliado = value; }

        [NotMapped]
        public List<UPedido> Compras1 { get => compras1; set => compras1 = value; }
        [NotMapped]
        public int Idpedido { get => idpedido; set => idpedido = value; }
        [NotMapped]
        public string Nombre_aliado { get => nombre_aliado; set => nombre_aliado = value; }
    }
}
