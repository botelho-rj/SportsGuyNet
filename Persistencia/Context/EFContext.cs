using SportsGuyNet.Modelo.Cadastros.Models;
using SportsGuyNet.Modelo.Tabelas.Models;
using SportsGuyNet.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportsGuyNet.Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("ASP_NET_MVC_CS"){
            //Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Autenticacao> Usuarios { get; set; }
        public DbSet<Preferencia> Preferencias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}