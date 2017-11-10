using Modelo.Tabelas;
using Persistencia.Migrations;
using Modelo.Cadastros.Models;
using Modelo.Tabelas.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Context
{
  public class EFContext : DbContext
    {
        public EFContext() : base("ASP_NET_MVC_CS"){
        Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        //          Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Preferencia> Preferencias { get; set; }

    }
}
