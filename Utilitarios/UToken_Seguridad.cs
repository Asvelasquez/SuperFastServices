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
    [Table("token_usuario_aplicacion", Schema = "seguridad")]
    public  class UToken_Seguridad
    {
        private int id;
        private int aplicacionId;
        private Nullable<int> userId;
        private DateTime fechaGenerado;
        private DateTime fechaVigencia;
        private string token;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("aplicacion_id")]
        public int AplicacionId { get => aplicacionId; set => aplicacionId = value; }
        [Column("user_id")]
        public int? UserId { get => userId; set => userId = value; }
        [Column("fecha_generado")]
        public DateTime FechaGenerado { get => fechaGenerado; set => fechaGenerado = value; }
        [Column("fecha_vigencia")]
        public DateTime FechaVigencia { get => fechaVigencia; set => fechaVigencia = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
    }
}
