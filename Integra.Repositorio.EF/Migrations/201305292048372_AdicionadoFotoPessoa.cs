namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoFotoPessoa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "CaminhoFoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoa", "CaminhoFoto");
        }
    }
}
