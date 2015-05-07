namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoModServicosContratados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServicosContratados",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Observacoes = c.String(),
                        DataContratacao = c.DateTime(nullable: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        Programa_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .Index(t => t.Programa_Codigo);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ServicosContratados", new[] { "Programa_Codigo" });
            DropForeignKey("dbo.ServicosContratados", "Programa_Codigo", "dbo.Programa");
            DropTable("dbo.ServicosContratados");
        }
    }
}
