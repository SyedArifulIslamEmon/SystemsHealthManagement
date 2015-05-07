namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AlteradoPropriedadeDaAprovacao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aprovacao", "Titulo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aprovacao", "Titulo");
        }
    }
}
