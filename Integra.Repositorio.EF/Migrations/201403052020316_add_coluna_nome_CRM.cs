namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_coluna_nome_CRM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CRM", "NomeDoCRM", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CRM", "NomeDoCRM");
        }
    }
}
