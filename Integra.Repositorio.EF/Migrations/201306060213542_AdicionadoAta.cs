namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AdicionadoAta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ata",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Assunto = c.String(),
                        Status = c.Int(nullable: false),
                        InicioDoPrazo = c.DateTime(nullable: false),
                        FinalDoPrazo = c.DateTime(nullable: false),
                        Anotacoes = c.String(),
                        Responsavel_Codigo = c.Int(),
                        Reuniao_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Pessoa", t => t.Responsavel_Codigo)
                .ForeignKey("dbo.Reuniao", t => t.Reuniao_Codigo, true)
                .Index(t => t.Responsavel_Codigo)
                .Index(t => t.Reuniao_Codigo);

        }

        public override void Down()
        {
            DropIndex("dbo.Ata", new[] { "Reuniao_Codigo" });
            DropIndex("dbo.Ata", new[] { "Responsavel_Codigo" });
            DropForeignKey("dbo.Ata", "Reuniao_Codigo", "dbo.Reuniao");
            DropForeignKey("dbo.Ata", "Responsavel_Codigo", "dbo.Pessoa");
            DropTable("dbo.Ata");
        }
    }
}
