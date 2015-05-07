namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoFotoAPessoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "Foto_Codigo", c => c.Int());
            CreateIndex("dbo.Pessoa", "Foto_Codigo");
            AddForeignKey("dbo.Pessoa", "Foto_Codigo", "dbo.Arquivo", "Codigo");
            DropColumn("dbo.Pessoa", "CaminhoFoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoa", "CaminhoFoto", c => c.String());
            DropForeignKey("dbo.Pessoa", "Foto_Codigo", "dbo.Arquivo");
            DropIndex("dbo.Pessoa", new[] { "Foto_Codigo" });
            DropColumn("dbo.Pessoa", "Foto_Codigo");
        }
    }
}
