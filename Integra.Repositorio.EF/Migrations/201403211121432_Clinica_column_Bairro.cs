namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clinica_column_Bairro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clinica", "Bairro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clinica", "Bairro");
        }
    }
}
