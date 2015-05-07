namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddDevolucaoDaNota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotaFiscal", "Devolvida", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.NotaFiscal", "DataCriacao", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.NotaFiscal", "DataCriacao");
            DropColumn("dbo.NotaFiscal", "Devolvida");
        }
    }
}
