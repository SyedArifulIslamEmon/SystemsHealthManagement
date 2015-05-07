namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClinicaDocumentos_DocumentoStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClinicaDocumentos", "StatusDocumento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClinicaDocumentos", "StatusDocumento"); 
        }
    }
}
