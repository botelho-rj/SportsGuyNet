namespace Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        ModalidadeId = c.Int(),
                        Titulo = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Horario = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.EventoId)
                .ForeignKey("dbo.Modalidade", t => t.ModalidadeId)
                .Index(t => t.ModalidadeId);
            
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "ModalidadeId", "dbo.Modalidade");
            DropIndex("dbo.Evento", new[] { "ModalidadeId" });
            DropTable("dbo.Modalidade");
            DropTable("dbo.Evento");
        }
    }
}
