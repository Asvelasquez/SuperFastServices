using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Mapeo
/// </summary>
public class Mapeo: DbContext 
{
    static Mapeo()
    {
        Database.SetInitializer<Mapeo>(null);
    }

    public Mapeo(): base("name=bd_inicial")
    {

    }
    //
    public DbSet<Cliente> client { get; set; } 
    public DbSet<Domiciliario> domiciliari { get; set; }
    public DbSet<Aliado> aliad { get; set; }
    //
    public DbSet<Pedido> pedido1 { get; set; }
    public DbSet<Detalle_pedido> detpedido { get; set; }
    public DbSet<Estado_pedido> estpedido { get; set; }
   public DbSet<estado_domicilio>estdomicilio { get; set; }
    public DbSet<Producto> producto { get; set; }
    public DbSet<Rol> rol { get; set; }
    public DbSet<Usuario> usuari { get; set; }
    public DbSet<Token> token { get; set; }
    public DbSet<Acceso> acceso { get; set; }
    public DateTime? Date1 { get; set; }

    protected override void OnModelCreating(DbModelBuilder builder){
        builder.HasDefaultSchema("public");
        base.OnModelCreating(builder);
    }
}