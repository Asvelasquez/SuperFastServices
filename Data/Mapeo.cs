using System;
using System.Data.Entity;
using Utilitarios;
namespace Data
{
    public  class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }

        public Mapeo() : base("name=bd_inicial")
        {

        }
        //migrado
        public DbSet<UUsuario> usuari { get; set; }
        public DbSet<UToken> token { get; set; }
        public DbSet<UMac> umac { get; set; }
        public DbSet<UProducto> producto { get; set; }
        public DbSet<UEstado_pedido> estpedido { get; set; }
        public DbSet<Uestado_domicilio> estdomicilio { get; set; }
        public DbSet<UPedido> pedido1 { get; set; }
        public DbSet<UDetalle_pedido> detpedido { get; set; }
        public DbSet<UCliente> client { get; set; }
        public DbSet<UDomiciliario> domiciliari { get; set; }
        public DbSet<UAliado> aliad { get; set; }
        public DbSet<URol> rol { get; set; }
        public DateTime? Date1 { get; set; }
        public DbSet<UAcceso> acceso { get; set; }
        public DbSet<UToken_Seguridad> token_seguridad { get; set; }
        public DbSet<UAplicacion> aplicacion { get; set; }

        //no migrado


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);
        }
    }

}
