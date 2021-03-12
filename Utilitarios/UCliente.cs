using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("cliente", Schema = "informacion")]
    public class UCliente
    {
        private int id_cliente;
        private string nombre;
        private string apellido;
        private string correo;
        private string contrasenia;
        private string direccion;
        private string telefono;
        private int rol_id;
        private string nombre_rol;


        [Key]
        [Column("id_cliente")]
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("apellido")]
        public string Apellido { get => apellido; set => apellido = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("contrasenia")]
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("telefono")]
        public string Telefono { get => telefono; set => telefono = value; }
        [NotMapped]
        public string Nombre_rol { get => nombre_rol; set => nombre_rol = value; }
        [Column("rol_id")]
        public int Rol_id { get => rol_id; set => rol_id = value; }
    }
}
