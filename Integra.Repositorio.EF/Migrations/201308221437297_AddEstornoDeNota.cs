namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstornoDeNota : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estorno",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.NotaFiscal", "Estorno_Codigo", c => c.Int());
            CreateIndex("dbo.NotaFiscal", "Estorno_Codigo");
            AddForeignKey("dbo.NotaFiscal", "Estorno_Codigo", "dbo.Estorno", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotaFiscal", "Estorno_Codigo", "dbo.Estorno");
            DropIndex("dbo.NotaFiscal", new[] { "Estorno_Codigo" });
            DropColumn("dbo.NotaFiscal", "Estorno_Codigo");
            DropTable("dbo.Estorno");
        }
    }
}
