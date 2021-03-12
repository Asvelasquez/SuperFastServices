using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("usuario", Schema = "informacion")]
    public class UUsuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private string contrasennia;
        private string direccion;
        private string telefono;
        private string documento;
        private string rut;
        private string actividadcomercial;
        private string imagenperfil;
        private string hojavida;
        private string tipovehiculo;
        private int id_rol;
        private int aprobacion;
        private string auditoria;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("apellido")]
        public string Apellido { get => apellido; set => apellido = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("contrasenia")]
        public string Contrasenia { get => contrasennia; set => contrasennia = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("telefono")]
        public string Telefono { get => telefono; set => telefono = value; }
        [Column("documento")]
        public string Documento { get => documento; set => documento = value; }
        [Column("rut")]
        public string Rut { get => rut; set => rut = value; }
        [Column("actividadcomercial")]
        public string Actividadcomercial { get => actividadcomercial; set => actividadcomercial = value; }
        [Column("imagenperfil")]
        public string Imagenperfil { get => imagenperfil; set => imagenperfil = value; }
        [Column("hojavida")]
        public string Hojavida { get => hojavida; set => hojavida = value; }
        [Column("tipovehiculo")]
        public string Tipovehiculo { get => tipovehiculo; set => tipovehiculo = value; }
        [Column("id_rol")]
        public int Id_rol { get => id_rol; set => id_rol = value; }
        [Column("aprobacion")]
        public int Aprobacion { get => aprobacion; set => aprobacion = value; }
        [Column("modificada")]
        public string Auditoria { get => auditoria; set => auditoria = value; }
    }
}
