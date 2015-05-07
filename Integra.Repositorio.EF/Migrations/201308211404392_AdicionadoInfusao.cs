namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoInfusao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infusao",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Localizador = c.String(),
                        Cpf = c.String(),
                        DataInfusao = c.DateTime(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        StatusDaInfusao = c.Int(nullable: false),
                        Clinica_Codigo = c.Int(nullable: false),
                        Responsavel_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clinica", t => t.Clinica_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .Index(t => t.Clinica_Codigo)
                .Index(t => t.Responsavel_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Infusao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Infusao", "Clinica_Codigo", "dbo.Clinica");
            DropIndex("dbo.Infusao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Infusao", new[] { "Clinica_Codigo" });
            DropTable("dbo.Infusao");
        }
    }
}
