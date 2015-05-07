namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoAnexosNaAta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtaArquivo",
                c => new
                    {
                        Ata_Codigo = c.Int(nullable: false),
                        Arquivo_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ata_Codigo, t.Arquivo_Codigo })
                .ForeignKey("dbo.Ata", t => t.Ata_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Arquivo", t => t.Arquivo_Codigo, cascadeDelete: true)
                .Index(t => t.Ata_Codigo)
                .Index(t => t.Arquivo_Codigo);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AtaArquivo", new[] { "Arquivo_Codigo" });
            DropIndex("dbo.AtaArquivo", new[] { "Ata_Codigo" });
            DropForeignKey("dbo.AtaArquivo", "Arquivo_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.AtaArquivo", "Ata_Codigo", "dbo.Ata");
            DropTable("dbo.AtaArquivo");
        }
    }
}
