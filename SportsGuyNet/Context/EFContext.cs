using SportsGuyNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsGuyNet.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("ASP_NET_MVC_CS"){
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
    }
}