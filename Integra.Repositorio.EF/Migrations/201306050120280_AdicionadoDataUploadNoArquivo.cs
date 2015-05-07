namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoDataUploadNoArquivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Arquivo", "Nome", c => c.String());
            AddColumn("dbo.Arquivo", "DataDeUpload", c => c.DateTime(nullable: false));
            DropColumn("dbo.Arquivo", "Caminho");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arquivo", "Caminho", c => c.String());
            DropColumn("dbo.Arquivo", "DataDeUpload");
            DropColumn("dbo.Arquivo", "Nome");
        }
    }
}
