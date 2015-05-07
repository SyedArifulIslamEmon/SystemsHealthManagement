namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoModTreinamentoComArquivos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arquivo",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Caminho = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Treinamento",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        DataRealizacao = c.DateTime(nullable: false),
                        Local = c.String(),
                        Titulo = c.String(),
                        Descricao = c.String(),
                        Programa_Codigo = c.Int(nullable: false),
                        Responsavel_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, cascadeDelete: true)
                .Index(t => t.Programa_Codigo)
                .Index(t => t.Responsavel_Codigo);
            
            CreateTable(
                "dbo.TreinamentoArquivo",
                c => new
                    {
                        Treinamento_Codigo = c.Int(nullable: false),
                        Arquivo_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Treinamento_Codigo, t.Arquivo_Codigo })
                .ForeignKey("dbo.Treinamento", t => t.Treinamento_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Arquivo", t => t.Arquivo_Codigo, cascadeDelete: true)
                .Index(t => t.Treinamento_Codigo)
                .Index(t => t.Arquivo_Codigo);
            
            CreateTable(
                "dbo.TreinamentoPessoa",
                c => new
                    {
                        Treinamento_Codigo = c.Int(nullable: false),
                        Pessoa_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Treinamento_Codigo, t.Pessoa_Codigo })
                .ForeignKey("dbo.Treinamento", t => t.Treinamento_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Codigo, cascadeDelete: false)
                .Index(t => t.Treinamento_Codigo)
                .Index(t => t.Pessoa_Codigo);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TreinamentoPessoa", new[] { "Pessoa_Codigo" });
            DropIndex("dbo.TreinamentoPessoa", new[] { "Treinamento_Codigo" });
            DropIndex("dbo.TreinamentoArquivo", new[] { "Arquivo_Codigo" });
            DropIndex("dbo.TreinamentoArquivo", new[] { "Treinamento_Codigo" });
            DropIndex("dbo.Treinamento", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Treinamento", new[] { "Programa_Codigo" });
            DropForeignKey("dbo.TreinamentoPessoa", "Pessoa_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.TreinamentoPessoa", "Treinamento_Codigo", "dbo.Treinamento");
            DropForeignKey("dbo.TreinamentoArquivo", "Arquivo_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.TreinamentoArquivo", "Treinamento_Codigo", "dbo.Treinamento");
            DropForeignKey("dbo.Treinamento", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Treinamento", "Programa_Codigo", "dbo.Programa");
            DropTable("dbo.TreinamentoPessoa");
            DropTable("dbo.TreinamentoArquivo");
            DropTable("dbo.Treinamento");
            DropTable("dbo.Arquivo");
        }
    }
}
