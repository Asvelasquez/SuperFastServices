using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
[Serializable]
[Table("usuario", Schema = "informacion")]
/*
 id integer NOT NULL DEFAULT nextval('informacion.usuario_id_seq'::regclass),
    nombre text COLLATE pg_catalog."default" NOT NULL,
    apellido text COLLATE pg_catalog."default",
    correo text COLLATE pg_catalog."default" NOT NULL,
    contrasennia text COLLATE pg_catalog."default" NOT NULL,
    direccion text COLLATE pg_catalog."default",
    telefono text COLLATE pg_catalog."default" NOT NULL,
    documento text COLLATE pg_catalog."default",
    rut text COLLATE pg_catalog."default",
    actividadcomercial text COLLATE pg_catalog."default",
    imagenperfil text COLLATE pg_catalog."default",
    hojavida text COLLATE pg_catalog."default",
    tipovehiculo text COLLATE pg_catalog."default",
    id_rol integer NOT NULL, 
    aprobacion integer NOT NULL,
 */
public class Usuario
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