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
    [Table("domiciliario", Schema = "informacion")]
    public class UDomiciliario
    {
        private int id_domiciliario;
        private string nombre_d;
        private string apellido_d;
        private string correo_d;
        private string contrasenia_d;
        private string documento_d;
        private string telefono_d;
        private string hojavida_d;
        private string tipovehiculo_d;
        [Key]
        [Column("id_domiciliario")]
        public int Id_Usuario { get => id_domiciliario; set => id_domiciliario = value; }
        [Column("nombre_d")]
        public string Nombre_d { get => nombre_d; set => nombre_d = value; }
        [Column("apellido_d")]
        public string Apellido_d { get => apellido_d; set => apellido_d = value; }
        [Column("correo_d")]
        public string Correo_d { get => correo_d; set => correo_d = value; }
        [Column("contrasenia_d")]
        public string Contrasenia_d { get => contrasenia_d; set => contrasenia_d = value; }
        [Column("documento_d")]
        public string Documento_d { get => documento_d; set => documento_d = value; }
        [Column("telefono_d")]
        public string Telefono_d { get => telefono_d; set => telefono_d = value; }
        [Column("hojavida_d")]
        public string Hojavida_d { get => hojavida_d; set => hojavida_d = value; }
        [Column("tipovehiculo_d")]
        public string Tipovehiculo_d { get => tipovehiculo_d; set => tipovehiculo_d = value; }
    }
}
