namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AdicionadoSolicitacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoDaSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        SLA = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Solicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Situacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.AberturaDeSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        DataDaAbertura = c.DateTime(nullable: false),
                        Protocolo = c.String(),
                        Solicitacao = c.String(),
                        Tipo_Codigo = c.Int(),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.TipoDaSolicitacao", t => t.Tipo_Codigo, true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, true)
                .ForeignKey("dbo.Solicitacao", t => t.Codigo, true)
                .Index(t => t.Tipo_Codigo)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Codigo);

            CreateTable(
                "dbo.AnaliseDeSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        DataDaAnalise = c.DateTime(nullable: false),
                        Analise = c.String(),
                        Custo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiasParaEntrega = c.Int(nullable: false),
                        Atividade = c.String(),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, true)
                .ForeignKey("dbo.Solicitacao", t => t.Codigo, true)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Codigo);

            CreateTable(
                "dbo.AprovacaoDeSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Aprovado = c.Boolean(nullable: false),
                        DataDeAprovacao = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, true)
                .ForeignKey("dbo.Solicitacao", t => t.Codigo, true)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Codigo);

            CreateTable(
                "dbo.ProcessoDaSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        DataDoProcesso = c.DateTime(nullable: false),
                        Solucao = c.String(),
                        Observacoes = c.String(),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, true)
                .ForeignKey("dbo.Solicitacao", t => t.Codigo, true)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Codigo);

            CreateTable(
                "dbo.EntregaDaSolicitacao",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Aceita = c.Boolean(nullable: false),
                        Observacoes = c.String(),
                        DataDoAceite = c.DateTime(nullable: false),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, true)
                .ForeignKey("dbo.Solicitacao", t => t.Codigo, true)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Codigo);

            Sql(@"INSERT INTO dbo.TipoDaSolicitacao (Descricao, SLA) Values ('Solicitação de Dados',2);
                INSERT INTO dbo.TipoDaSolicitacao (Descricao, SLA) Values ('Aumento de Serviço',2);
                INSERT INTO dbo.TipoDaSolicitacao (Descricao, SLA) Values ('Diminuição de Serviço',2);
                INSERT INTO dbo.TipoDaSolicitacao (Descricao, SLA) Values ('Alteração de Escopo',2);
                INSERT INTO dbo.TipoDaSolicitacao (Descricao, SLA) Values ('Alteração de Script',2);
                ");
        }

        public override void Down()
        {
            DropForeignKey("dbo.EntregaDaSolicitacao", "Codigo", "dbo.Solicitacao");
            DropForeignKey("dbo.EntregaDaSolicitacao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.ProcessoDaSolicitacao", "Codigo", "dbo.Solicitacao");
            DropForeignKey("dbo.ProcessoDaSolicitacao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.AprovacaoDeSolicitacao", "Codigo", "dbo.Solicitacao");
            DropForeignKey("dbo.AprovacaoDeSolicitacao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.AnaliseDeSolicitacao", "Codigo", "dbo.Solicitacao");
            DropForeignKey("dbo.AnaliseDeSolicitacao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.AberturaDeSolicitacao", "Codigo", "dbo.Solicitacao");
            DropForeignKey("dbo.AberturaDeSolicitacao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.AberturaDeSolicitacao", "Tipo_Codigo", "dbo.TipoDaSolicitacao");
            DropIndex("dbo.EntregaDaSolicitacao", new[] { "Codigo" });
            DropIndex("dbo.EntregaDaSolicitacao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.ProcessoDaSolicitacao", new[] { "Codigo" });
            DropIndex("dbo.ProcessoDaSolicitacao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.AprovacaoDeSolicitacao", new[] { "Codigo" });
            DropIndex("dbo.AprovacaoDeSolicitacao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.AnaliseDeSolicitacao", new[] { "Codigo" });
            DropIndex("dbo.AnaliseDeSolicitacao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.AberturaDeSolicitacao", new[] { "Codigo" });
            DropIndex("dbo.AberturaDeSolicitacao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.AberturaDeSolicitacao", new[] { "Tipo_Codigo" });
            DropTable("dbo.EntregaDaSolicitacao");
            DropTable("dbo.ProcessoDaSolicitacao");
            DropTable("dbo.AprovacaoDeSolicitacao");
            DropTable("dbo.AnaliseDeSolicitacao");
            DropTable("dbo.AberturaDeSolicitacao");
            DropTable("dbo.Solicitacao");
            DropTable("dbo.TipoDaSolicitacao");
        }
    }
}
