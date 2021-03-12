using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Estado_pedido
/// </summary>
/// 
/*
 *  id integer NOT NULL DEFAULT nextval('informacion.estado_pedido_id_seq'::regclass),
    nombre text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_informacion_estado_pedido" PRIMARY KEY (id)
)
 * */
[Serializable]
[Table("estado_pedido", Schema = "informacion")]

public class Estado_pedido
{
    private int id;
    private string nombre;

    [Key]
    [Column("id")]
    public int Id { get => id; set => id = value; }
    [Column("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
}