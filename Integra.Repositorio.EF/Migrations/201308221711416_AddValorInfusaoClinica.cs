namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddValorInfusaoClinica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinica", "ValorDeInfusao", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 0));
        }

        public override void Down()
        {
            DropColumn("dbo.Clinica", "ValorDeInfusao");
        }
    }
}
