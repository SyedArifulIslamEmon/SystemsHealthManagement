namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoGestaoPrograma : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pessoa", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Fatura", "Programa_Codigo", "dbo.Programa");
            DropIndex("dbo.Pessoa", new[] { "Programa_Codigo" });
            DropIndex("dbo.Fatura", new[] { "Programa_Codigo" });

            CreateTable(
                "dbo.PessoaPrograma",
                c => new
                    {
                        Pessoa_Codigo = c.Int(nullable: false),
                        Programa_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pessoa_Codigo, t.Programa_Codigo })
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .Index(t => t.Pessoa_Codigo)
                .Index(t => t.Programa_Codigo);
            
            AddColumn("dbo.Programa", "IdentPrograma", c => c.String());
            AddColumn("dbo.Programa", "CodPrograma", c => c.Int(nullable: false));
            AddColumn("dbo.Ata", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Aprovacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.AberturaDeSolicitacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.AnaliseDeSolicitacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.AprovacaoDeSolicitacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.ProcessoDaSolicitacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.EntregaDaSolicitacao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Infusao", "Programa_Codigo", c => c.Int(nullable: false, defaultValue:1));
            AddColumn("dbo.NotaFiscal", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));
            AlterColumn("dbo.Fatura", "Programa_Codigo", c => c.Int(nullable: false, defaultValue: 1));

            CreateIndex("dbo.Ata", "Programa_Codigo");
            CreateIndex("dbo.Aprovacao", "Programa_Codigo");
            CreateIndex("dbo.AberturaDeSolicitacao", "Programa_Codigo");
            CreateIndex("dbo.AnaliseDeSolicitacao", "Programa_Codigo");
            CreateIndex("dbo.AprovacaoDeSolicitacao", "Programa_Codigo");
            CreateIndex("dbo.ProcessoDaSolicitacao", "Programa_Codigo");
            CreateIndex("dbo.EntregaDaSolicitacao", "Programa_Codigo");
            CreateIndex("dbo.Infusao", "Programa_Codigo");
            CreateIndex("dbo.NotaFiscal", "Programa_Codigo");
            CreateIndex("dbo.Fatura", "Programa_Codigo");

            AddForeignKey("dbo.Ata", "Programa_Codigo", "dbo.Programa", "Codigo");
            AddForeignKey("dbo.Aprovacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.AberturaDeSolicitacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.AnaliseDeSolicitacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.AprovacaoDeSolicitacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.ProcessoDaSolicitacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.EntregaDaSolicitacao", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Infusao", "Programa_Codigo", "dbo.Programa", "Codigo");
            AddForeignKey("dbo.NotaFiscal", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.Fatura", "Programa_Codigo", "dbo.Programa", "Codigo", cascadeDelete: true);

            Sql(Properties.Resources.CorrecaoPrograma);

            DropColumn("dbo.Pessoa", "Programa_Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoa", "Programa_Codigo", c => c.Int());
            DropForeignKey("dbo.Fatura", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.NotaFiscal", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Infusao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.EntregaDaSolicitacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.ProcessoDaSolicitacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.AprovacaoDeSolicitacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.AnaliseDeSolicitacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.AberturaDeSolicitacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Aprovacao", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Ata", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.PessoaPrograma", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.PessoaPrograma", "Pessoa_Codigo", "dbo.Pessoa");
            DropIndex("dbo.Fatura", new[] { "Programa_Codigo" });
            DropIndex("dbo.NotaFiscal", new[] { "Programa_Codigo" });
            DropIndex("dbo.Infusao", new[] { "Programa_Codigo" });
            DropIndex("dbo.EntregaDaSolicitacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.ProcessoDaSolicitacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.AprovacaoDeSolicitacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.AnaliseDeSolicitacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.AberturaDeSolicitacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.Aprovacao", new[] { "Programa_Codigo" });
            DropIndex("dbo.Ata", new[] { "Programa_Codigo" });
            DropIndex("dbo.PessoaPrograma", new[] { "Programa_Codigo" });
            DropIndex("dbo.PessoaPrograma", new[] { "Pessoa_Codigo" });
            AlterColumn("dbo.Fatura", "Programa_Codigo", c => c.Int());
            DropColumn("dbo.NotaFiscal", "Programa_Codigo");
            DropColumn("dbo.Infusao", "Programa_Codigo");
            DropColumn("dbo.EntregaDaSolicitacao", "Programa_Codigo");
            DropColumn("dbo.ProcessoDaSolicitacao", "Programa_Codigo");
            DropColumn("dbo.AprovacaoDeSolicitacao", "Programa_Codigo");
            DropColumn("dbo.AnaliseDeSolicitacao", "Programa_Codigo");
            DropColumn("dbo.AberturaDeSolicitacao", "Programa_Codigo");
            DropColumn("dbo.Aprovacao", "Programa_Codigo");
            DropColumn("dbo.Ata", "Programa_Codigo");
            DropColumn("dbo.Programa", "CodPrograma");
            DropColumn("dbo.Programa", "IdentPrograma");
            DropTable("dbo.PessoaPrograma");
            CreateIndex("dbo.Fatura", "Programa_Codigo");
            CreateIndex("dbo.Pessoa", "Programa_Codigo");
            AddForeignKey("dbo.Fatura", "Programa_Codigo", "dbo.Programa", "Codigo");
            AddForeignKey("dbo.Pessoa", "Programa_Codigo", "dbo.Programa", "Codigo");
        }
    }
}
