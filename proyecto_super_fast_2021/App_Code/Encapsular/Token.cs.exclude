using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Token
/// </summary>
[Serializable]
[Table("token_recuperacion", Schema = "seguridad")]

public class Token{
    /*id_recuperacion integer NOT NULL DEFAULT nextval('seguridad.token_recuperacion_id_recuperacion_seq'::regclass),
    user_id integer NOT NULL,
    token text COLLATE pg_catalog."default" NOT NULL,
    creado timestamp without time zone NOT NULL,
    vigencia timestamp without time zone NOT NULL,
    */
    private int id;
    private int user_id;
    private string tokeng;
    private DateTime creado;
    private DateTime vigencia;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("user_id")]
    public int User_id { get => user_id; set => user_id = value; }
    [Column("tokeng")]
    public string Tokeng { get => tokeng; set => tokeng = value; }
    [Column("creado")]
    public DateTime Creado { get => creado; set => creado = value; }
    [Column("vigencia")]
    public DateTime Vigencia { get => vigencia; set => vigencia = value; }
}