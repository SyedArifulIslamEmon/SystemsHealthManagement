namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovosItensInfusao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Infusao", "NomePaciente", c => c.String());
            AddColumn("dbo.Infusao", "Dosagem", c => c.String());
            AddColumn("dbo.Infusao", "Ampola", c => c.String());
            AddColumn("dbo.Infusao", "Lote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Infusao", "Lote");
            DropColumn("dbo.Infusao", "Ampola");
            DropColumn("dbo.Infusao", "Dosagem");
            DropColumn("dbo.Infusao", "NomePaciente");
        }
    }
}
