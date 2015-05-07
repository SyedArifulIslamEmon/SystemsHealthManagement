namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoAnexosNaReuniao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReuniaoArquivo",
                c => new
                    {
                        Reuniao_Codigo = c.Int(nullable: false),
                        Arquivo_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reuniao_Codigo, t.Arquivo_Codigo })
                .ForeignKey("dbo.Reuniao", t => t.Reuniao_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Arquivo", t => t.Arquivo_Codigo, cascadeDelete: true)
                .Index(t => t.Reuniao_Codigo)
                .Index(t => t.Arquivo_Codigo);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReuniaoArquivo", new[] { "Arquivo_Codigo" });
            DropIndex("dbo.ReuniaoArquivo", new[] { "Reuniao_Codigo" });
            DropForeignKey("dbo.ReuniaoArquivo", "Arquivo_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.ReuniaoArquivo", "Reuniao_Codigo", "dbo.Reuniao");
            DropTable("dbo.ReuniaoArquivo");
        }
    }
}
