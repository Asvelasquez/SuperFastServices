using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("estado_domicilio", Schema = "informacion")]

    public class Uestado_domicilio
    {
        private int id_domicilio;
        private string nombre;

        [Key]
        [Column("id_domicilio")]
        public int Id { get => id_domicilio; set => id_domicilio = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
