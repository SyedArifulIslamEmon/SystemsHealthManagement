namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddVencimentoDoDocumentoDaClinica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClinicaDocumentos", "DataDeVencimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClinicaDocumentos", "DataDeVencimento");
        }
    }
}
