using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de esttado_domicilio
/// </summary>
/// 
[Serializable]
[Table("estado_domicilio", Schema = "informacion")]

public class estado_domicilio
{
    private int id_domicilio;
    private string nombre;

    [Key]
    [Column("id_domicilio")]
    public int Id { get => id_domicilio; set => id_domicilio = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
}