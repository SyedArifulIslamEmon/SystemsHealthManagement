namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGerenteRepresentantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Representante",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Gerente",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.RepresentanteRegional",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Clinica", "Representante_Codigo", c => c.Int(nullable: false));
            AddColumn("dbo.Clinica", "Gerente_Codigo", c => c.Int(nullable: false));
            AddColumn("dbo.Clinica", "RepresentanteRegional_Codigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Clinica", "Representante_Codigo");
            CreateIndex("dbo.Clinica", "Gerente_Codigo");
            CreateIndex("dbo.Clinica", "RepresentanteRegional_Codigo");
            AddForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional", "Codigo", cascadeDelete: true);
            DropColumn("dbo.Clinica", "Representante");
            DropColumn("dbo.Clinica", "Gerente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clinica", "Gerente", c => c.String());
            AddColumn("dbo.Clinica", "Representante", c => c.String());
            DropForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional");
            DropForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente");
            DropForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante");
            DropIndex("dbo.Clinica", new[] { "RepresentanteRegional_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Gerente_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Representante_Codigo" });
            DropColumn("dbo.Clinica", "RepresentanteRegional_Codigo");
            DropColumn("dbo.Clinica", "Gerente_Codigo");
            DropColumn("dbo.Clinica", "Representante_Codigo");
            DropTable("dbo.RepresentanteRegional");
            DropTable("dbo.Gerente");
            DropTable("dbo.Representante");
        }
    }
}
