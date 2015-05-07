namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentificadorNoTratamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tratamento", "Indetificador", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tratamento", "Indetificador");
        }
    }
}
