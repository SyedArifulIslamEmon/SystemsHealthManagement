namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoModGestaoTratamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tratamento",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataSolicitacao = c.DateTime(),
                        Ifx = c.String(),
                        Medico = c.String(),
                        Representante = c.String(),
                        MotivoSolicitacao = c.String(),
                        Status = c.Int(nullable: false),
                        DataStatus = c.DateTime(),
                        Observacoes = c.String(),
                        Programa_Codigo = c.Int(nullable: false),
                        Responsavel_Codigo = c.Int(),
                        GrupoResponsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .ForeignKey("dbo.Grupos", t => t.GrupoResponsavel_Codigo)
                .Index(t => t.Programa_Codigo)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.GrupoResponsavel_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tratamento", "GrupoResponsavel_Codigo", "dbo.Grupos");
            DropForeignKey("dbo.Tratamento", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Tratamento", "Programa_Codigo", "dbo.Programa");
            DropIndex("dbo.Tratamento", new[] { "GrupoResponsavel_Codigo" });
            DropIndex("dbo.Tratamento", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Tratamento", new[] { "Programa_Codigo" });
            DropTable("dbo.Tratamento");
        }
    }
}
