namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class coluna_flag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoDeCrm", "FlagCrm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoDeCrm", "FlagCrm");
        }
    }
}
