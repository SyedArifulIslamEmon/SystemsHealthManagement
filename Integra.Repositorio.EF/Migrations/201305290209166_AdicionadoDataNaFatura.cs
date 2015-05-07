namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoDataNaFatura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fatura", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Fatura", "MesDeReferencia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fatura", "MesDeReferencia", c => c.Int(nullable: false));
            DropColumn("dbo.Fatura", "Data");
        }
    }
}
