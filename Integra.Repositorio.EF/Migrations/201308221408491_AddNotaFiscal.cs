namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotaFiscal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Numero = c.String(),
                        Data = c.DateTime(nullable: false),
                        DataRecebimento = c.DateTime(nullable: false),
                        Clinica_Codigo = c.Int(),
                        Responsavel_Codigo = c.Int(),
                        Arquivo_Codigo = c.Int(),
                        Pagamento_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clinica", t => t.Clinica_Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .ForeignKey("dbo.Arquivo", t => t.Arquivo_Codigo)
                .ForeignKey("dbo.Pagamento", t => t.Pagamento_Codigo)
                .Index(t => t.Clinica_Codigo)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Arquivo_Codigo)
                .Index(t => t.Pagamento_Codigo);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Observacao = c.String(),
                        Comprovante_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Arquivo", t => t.Comprovante_Codigo)
                .Index(t => t.Comprovante_Codigo);
            
            AddColumn("dbo.Infusao", "NotaFiscal_Codigo", c => c.Int());
            CreateIndex("dbo.Infusao", "NotaFiscal_Codigo");
            AddForeignKey("dbo.Infusao", "NotaFiscal_Codigo", "dbo.NotaFiscal", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotaFiscal", "Pagamento_Codigo", "dbo.Pagamento");
            DropForeignKey("dbo.Pagamento", "Comprovante_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.NotaFiscal", "Arquivo_Codigo", "dbo.Arquivo");
            DropForeignKey("dbo.Infusao", "NotaFiscal_Codigo", "dbo.NotaFiscal");
            DropForeignKey("dbo.NotaFiscal", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.NotaFiscal", "Clinica_Codigo", "dbo.Clinica");
            DropIndex("dbo.NotaFiscal", new[] { "Pagamento_Codigo" });
            DropIndex("dbo.Pagamento", new[] { "Comprovante_Codigo" });
            DropIndex("dbo.NotaFiscal", new[] { "Arquivo_Codigo" });
            DropIndex("dbo.Infusao", new[] { "NotaFiscal_Codigo" });
            DropIndex("dbo.NotaFiscal", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.NotaFiscal", new[] { "Clinica_Codigo" });
            DropColumn("dbo.Infusao", "NotaFiscal_Codigo");
            DropTable("dbo.Pagamento");
            DropTable("dbo.NotaFiscal");
        }
    }
}
