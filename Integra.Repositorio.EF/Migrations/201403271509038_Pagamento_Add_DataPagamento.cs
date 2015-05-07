namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pagamento_Add_DataPagamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagamento", "DataPagamento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamento", "DataPagamento");
        }
    }
}
