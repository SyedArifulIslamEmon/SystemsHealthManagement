namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoModClinicas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pessoa", "CRM_Codigo", "dbo.CRM");
            DropIndex("dbo.Pessoa", new[] { "CRM_Codigo" });
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        RazaoSocial = c.String(),
                        Cnpj = c.String(),
                        InscricaoEstadual = c.String(),
                        Endereco = c.String(),
                        Cidade = c.String(),
                        Uf = c.String(),
                        Telefone = c.String(),
                        Contato = c.String(),
                        Representante = c.String(),
                        Gerente = c.String(),
                        Observacoes = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Programa_Codigo = c.Int(nullable: false),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .Index(t => t.Programa_Codigo)
                .Index(t => t.Responsavel_Codigo);
            
            CreateTable(
                "dbo.ClinicaDocumentos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataDeUpload = c.DateTime(nullable: false),
                        TipoDocumento = c.Int(nullable: false),
                        Descricao = c.String(),
                        Nome = c.String(),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .Index(t => t.Responsavel_Codigo);
            
            CreateTable(
                "dbo.ClinicaClinicaDocumentos",
                c => new
                    {
                        Clinica_Codigo = c.Int(nullable: false),
                        ClinicaDocumentos_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Clinica_Codigo, t.ClinicaDocumentos_Codigo })
                .ForeignKey("dbo.Clinica", t => t.Clinica_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.ClinicaDocumentos", t => t.ClinicaDocumentos_Codigo, cascadeDelete: true)
                .Index(t => t.Clinica_Codigo)
                .Index(t => t.ClinicaDocumentos_Codigo);
            
            AlterColumn("dbo.Pessoa", "Crm_Codigo", c => c.Int());
            CreateIndex("dbo.Pessoa", "Crm_Codigo");
            AddForeignKey("dbo.Pessoa", "Crm_Codigo", "dbo.CRM", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClinicaClinicaDocumentos", "ClinicaDocumentos_Codigo", "dbo.ClinicaDocumentos");
            DropForeignKey("dbo.ClinicaClinicaDocumentos", "Clinica_Codigo", "dbo.Clinica");
            DropForeignKey("dbo.ClinicaDocumentos", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Clinica", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Clinica", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Pessoa", "Crm_Codigo", "dbo.CRM");
            DropIndex("dbo.ClinicaClinicaDocumentos", new[] { "ClinicaDocumentos_Codigo" });
            DropIndex("dbo.ClinicaClinicaDocumentos", new[] { "Clinica_Codigo" });
            DropIndex("dbo.ClinicaDocumentos", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Clinica", new[] { "Programa_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "Crm_Codigo" });
            AlterColumn("dbo.Pessoa", "CRM_Codigo", c => c.Int());
            DropTable("dbo.ClinicaClinicaDocumentos");
            DropTable("dbo.ClinicaDocumentos");
            DropTable("dbo.Clinica");
            CreateIndex("dbo.Pessoa", "CRM_Codigo");
            AddForeignKey("dbo.Pessoa", "CRM_Codigo", "dbo.CRM", "Codigo");
        }
    }
}
