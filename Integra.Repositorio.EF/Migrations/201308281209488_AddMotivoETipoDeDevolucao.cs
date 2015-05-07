namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMotivoETipoDeDevolucao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NotaFiscal", "TipoDeDevolucao", c => c.String());
            AddColumn("dbo.NotaFiscal", "Motivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NotaFiscal", "Motivo");
            DropColumn("dbo.NotaFiscal", "TipoDeDevolucao");
        }
    }
}
