using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
    id_aliado integer NOT NULL DEFAULT nextval('informacion.aliado_id_aliado_seq'::regclass),
    nombre_a text COLLATE pg_catalog."default" NOT NULL,
    nit_a text COLLATE pg_catalog."default" NOT NULL,
    correo_a text COLLATE pg_catalog."default" NOT NULL,
    contrasenia_a text COLLATE pg_catalog."default" NOT NULL,
    telefono_a text COLLATE pg_catalog."default" NOT NULL,
    direccion_a text COLLATE pg_catalog."default" NOT NULL,
    actividadcomercial_a text COLLATE pg_catalog."default" NOT NULL,
    logo text COLLATE pg_catalog."default" NOT NULL,
    rut text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT aliado_pkey PRIMARY KEY (id_aliado)
    */

[Serializable]
[Table("aliado", Schema = "informacion")]

public class Aliado
{
     private int id_aliado;
     private string nombre_a;
     private string nit_a;
     private string correo_a;
     private string contrasenia_a;
     private string telefono_a;
     private string direccion_a;
     private string actividadcomercial_a;
     private string logo;
     private string rut;
    [Key]
    [Column("id_aliado")]
    public int Id_aliado { get => id_aliado; set => id_aliado = value; }
    [Column("nombre_a")]
    public string Nombre_a { get => nombre_a; set => nombre_a = value; }
    [Column("nit_a")]
    public string Nit_a { get => nit_a; set => nit_a = value; }
    [Column("correo_a")]
    public string Correo_a { get => correo_a; set => correo_a = value; }
    [Column("contrasenia_a")]
    public string Contrasenia_a { get => contrasenia_a; set => contrasenia_a = value; }
    [Column("telefono_a")]
    public string Telefono_a { get => telefono_a; set => telefono_a = value; }
    [Column("direccion_a")]
    public string Direccion_a { get => direccion_a; set => direccion_a = value; }
    [Column("actividadcomercial_a")]
    public string Actividadcomercial_a { get => actividadcomercial_a; set => actividadcomercial_a = value; }
    [Column("logo")]
    public string Logo { get => logo; set => logo = value; }
    [Column("rut")]
    public string Rut { get => rut; set => rut = value; }
}