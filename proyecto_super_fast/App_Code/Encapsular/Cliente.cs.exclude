using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>

[Serializable]
[Table("cliente",Schema="informacion")]
public class Cliente
{
    /* id_cliente integer NOT NULL DEFAULT nextval('informacion.cliente_id_cliente_seq'::regclass),
     nombre text COLLATE pg_catalog."default" NOT NULL,
     apellido text COLLATE pg_catalog."default" NOT NULL,
     correo text COLLATE pg_catalog."default" NOT NULL,
     contrasenia text COLLATE pg_catalog."default" NOT NULL,
     direccion text COLLATE pg_catalog."default" NOT NULL,
     telefono text COLLATE pg_catalog."default" NOT NULL,
     CONSTRAINT pk_informacion_cliente PRIMARY KEY (id_cliente)*/
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