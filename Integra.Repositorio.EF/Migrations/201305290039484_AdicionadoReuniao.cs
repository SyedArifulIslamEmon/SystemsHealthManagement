namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AdicionadoReuniao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reuniao",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Criacao = c.DateTime(nullable: false),
                        Realizacao = c.DateTime(nullable: false),
                        Assunto = c.String(nullable: false),
                        Local = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Programa_Codigo = c.Int(nullable: false),
                        Responsavel_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo, cascadeDelete: true)
                .Index(t => t.Programa_Codigo)
                .Index(t => t.Responsavel_Codigo);

            CreateTable(
                "dbo.ReuniaoPessoa",
                c => new
                    {
                        Reuniao_Codigo = c.Int(nullable: false),
                        Pessoa_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reuniao_Codigo, t.Pessoa_Codigo })
                .ForeignKey("dbo.Reuniao", t => t.Reuniao_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Pessoa_Codigo)
                .Index(t => t.Reuniao_Codigo)
                .Index(t => t.Pessoa_Codigo);

        }

        public override void Down()
        {
            DropIndex("dbo.ReuniaoPessoa", new[] { "Pessoa_Codigo" });
            DropIndex("dbo.ReuniaoPessoa", new[] { "Reuniao_Codigo" });
            DropIndex("dbo.Reuniao", new[] { "Responsavel_Codigo" });
            DropIndex("dbo.Reuniao", new[] { "Programa_Codigo" });
            DropForeignKey("dbo.ReuniaoPessoa", "Pessoa_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.ReuniaoPessoa", "Reuniao_Codigo", "dbo.Reuniao");
            DropForeignKey("dbo.Reuniao", "Responsavel_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.Reuniao", "Programa_Codigo", "dbo.Programa");
            DropTable("dbo.ReuniaoPessoa");
            DropTable("dbo.Reuniao");
        }
    }
}
