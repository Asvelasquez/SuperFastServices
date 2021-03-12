using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pedido
/// </summary>
/*
id_pedido integer NOT NULL DEFAULT nextval('informacion.pedido_id_pedido_seq'::regclass),
    cliente_id integer NOT NULL,
    fecha time without time zone NOT NULL,
    estado_id integer NOT NULL,
    valor_total double precision NOT NULL,
    domiciliario_id integer NOT NULL,
    comentario_cliente text COLLATE pg_catalog."default",
    comentario_aliado text COLLATE pg_catalog."default",
    aliado_id integer NOT NULL,
 */
[Serializable]
[Table("pedido", Schema = "informacion")]
public class Pedido
{
    private int id_pedido;
    private int cliente_id;
    private DateTime fecha;
    private int estado_id;
    private double valor_total;
    private int domiciliario_id;
    private string comentario_cliente;
    private string comentario_aliado;
    private int aliado_id;
    private int estado_pedido;
    private int estado_domicilio_id;

    private string detnombrecliente;
    private List<Detalle_pedido> compras;
    private List<Detalle_pedido> compras1;
    private string nombre_estado_ped;
    private string nombre_estado_domicilio;
    private double det_valor_unitario;
    private int det_cantidad;
    private string nombre_aliado;
    private string direccion_aliado;
    private string nombre_cliente;
    private string direccion_cliente;
    private string telefono_cliente;
    
    [Key]
    [Column("id_pedido")]
    public int Id_pedido { get => id_pedido; set => id_pedido = value; }
    [Column("cliente_id")]
    public int Cliente_id { get => cliente_id; set => cliente_id = value; }
    [Column("fecha")]
    public DateTime Fecha { get => fecha; set => fecha = value; }
    [Column("estado_id")]
    public int Estado_id { get => estado_id; set => estado_id = value; }
    [Column("valor_total")]
    public double Valor_total { get => valor_total; set => valor_total = value; }
    [Column("domiciliario_id")]
    public int Domiciliario_id { get => domiciliario_id; set => domiciliario_id = value; }
    [Column("comentario_cliente")]
    public string Comentario_cliente { get => comentario_cliente; set => comentario_cliente = value; }
    [Column("comentario_aliado")]
    public string Comentario_aliado { get => comentario_aliado; set => comentario_aliado = value; }
    [Column("aliado_id")]
    public int Aliado_id { get => aliado_id; set => aliado_id = value; }
    [Column("estado_pedido")]
    public int Estado_pedido { get => estado_pedido; set => estado_pedido = value; }
    [Column("estado_domicilio_id")]
    public int Estado_domicilio_id { get => estado_domicilio_id; set => estado_domicilio_id = value; }

    [NotMapped]
    public List<Detalle_pedido> Compras { get => compras; set => compras = value; }
    [NotMapped]
    public List<Detalle_pedido> Compras1 { get => compras1; set => compras1 = value; }
    [NotMapped]
    public string Detnombrecliente { get => detnombrecliente; set => detnombrecliente = value; }
    [NotMapped]
    public string Nombre_estado_ped { get => nombre_estado_ped; set => nombre_estado_ped = value; }
    [NotMapped]
    public string Nombre_estado_domicilio { get => nombre_estado_domicilio; set => nombre_estado_domicilio = value; }
    [NotMapped]
    public double Det_valor_unitario { get => det_valor_unitario; set => det_valor_unitario = value; }
    [NotMapped]
    public int Det_cantidad { get => det_cantidad; set => det_cantidad = value; }
    [NotMapped]
    public string Nombre_aliado { get => nombre_aliado; set => nombre_aliado = value; }
    [NotMapped]
    public string Direccion_aliado { get => direccion_aliado; set => direccion_aliado = value; }
    [NotMapped]
    public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
    [NotMapped]
    public string Direccion_cliente { get => direccion_cliente; set => direccion_cliente = value; }
    [NotMapped]
    public string Telefono_cliente { get => telefono_cliente; set => telefono_cliente = value; }
}