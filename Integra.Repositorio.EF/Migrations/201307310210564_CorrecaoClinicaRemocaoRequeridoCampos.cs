namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoClinicaRemocaoRequeridoCampos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante");
            DropForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente");
            DropForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional");
            DropIndex("dbo.Clinica", new[] { "Representante_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Gerente_Codigo" });
            DropIndex("dbo.Clinica", new[] { "RepresentanteRegional_Codigo" });
            AlterColumn("dbo.Clinica", "Representante_Codigo", c => c.Int());
            AlterColumn("dbo.Clinica", "Gerente_Codigo", c => c.Int());
            AlterColumn("dbo.Clinica", "RepresentanteRegional_Codigo", c => c.Int());
            CreateIndex("dbo.Clinica", "Representante_Codigo");
            CreateIndex("dbo.Clinica", "Gerente_Codigo");
            CreateIndex("dbo.Clinica", "RepresentanteRegional_Codigo");
            AddForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante", "Codigo");
            AddForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente", "Codigo");
            AddForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional");
            DropForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente");
            DropForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante");
            DropIndex("dbo.Clinica", new[] { "RepresentanteRegional_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Gerente_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Representante_Codigo" });
            AlterColumn("dbo.Clinica", "RepresentanteRegional_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Clinica", "Gerente_Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Clinica", "Representante_Codigo", c => c.Int(nullable: false));
            CreateIndex("dbo.Clinica", "RepresentanteRegional_Codigo");
            CreateIndex("dbo.Clinica", "Gerente_Codigo");
            CreateIndex("dbo.Clinica", "Representante_Codigo");
            AddForeignKey("dbo.Clinica", "RepresentanteRegional_Codigo", "dbo.RepresentanteRegional", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "Gerente_Codigo", "dbo.Gerente", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Clinica", "Representante_Codigo", "dbo.Representante", "Codigo", cascadeDelete: true);
        }
    }
}
