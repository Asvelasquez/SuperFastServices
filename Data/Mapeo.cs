using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DbSet<UMac> acceso { get; set; }
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
        //no migrado
        //public DateTime? Date1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);
        }
    }

}
