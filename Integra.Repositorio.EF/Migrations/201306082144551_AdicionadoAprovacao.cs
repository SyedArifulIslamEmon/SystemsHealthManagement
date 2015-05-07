namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoAprovacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aprovacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        DataDaAprovacao = c.DateTime(),
                        Tipo = c.Int(nullable: false),
                        ResponsavelPelaAprovacao_Codigo = c.Int(),
                        GrupoResponsavel_Codigo = c.Int(),
                        Anexo_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.ResponsavelPelaAprovacao_Codigo)
                .ForeignKey("dbo.Grupos", t => t.GrupoResponsavel_Codigo)
                .ForeignKey("dbo.Arquivo", t => t.Anexo_Codigo)
                .Index(t => t.ResponsavelPelaAprovacao_Codigo)
                .Index(t => t.GrupoResponsavel_Codigo)
                .Index(t => t.Anexo_Codigo);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Aprovacao", new[] { "Anexo_Codigo" });
            DropIndex("dbo.Aprovacao", new[] { "GrupoResponsavel_Codigo" });
            DropIndex("dbo.Aprovacao", new[] { "ResponsavelPelaAprovacao_Codigo" });
            DropForeignKey("dbo.Aprovacao", "Anexo_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.Aprovacao", "GrupoResponsavel_Codigo", "dbo.Grupos");
            DropForeignKey("dbo.Aprovacao", "ResponsavelPelaAprovacao_Codigo", "dbo.Pessoa");
            DropTable("dbo.Aprovacao");
        }
    }
}
