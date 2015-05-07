namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoTelefonesEIndicaNaClinica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinica", "IndicarNovosPacientes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clinica", "Telefone2", c => c.String());
            AddColumn("dbo.Clinica", "Telefone3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinica", "Telefone3");
            DropColumn("dbo.Clinica", "Telefone2");
            DropColumn("dbo.Clinica", "IndicarNovosPacientes");
        }
    }
}
