using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
/// 
[Serializable]
[Table("acceso", Schema = "seguridad")]
public class Acceso
{
    private int id;
    private int user_id;
    private string ip;
    private string mac;
    private DateTime fecha_inicio;
    private string session;
    private Nullable<DateTime> fecha_fin;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("user_id")]
    public int UserId { get => user_id; set => user_id = value; }
    [Column("ip")]
    public string Ip { get => ip; set => ip = value; }
    [Column("mac")]
    public string Mac { get => mac; set => mac = value; }
    [Column("fecha_inicio")]
    public DateTime FechaInicio { get => fecha_inicio; set => fecha_inicio = value; }
    [Column("session")]
    public string Session { get => session; set => session = value; }
    [Column("fecha_fin")]
    public Nullable<DateTime> FechaFin { get => fecha_fin; set => fecha_fin = value; }
}
 