namespace Integra.Repositorio.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<IntegraContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SqlClient", new NonSystemTableSqlGenerator());
        }

        protected override void Seed(IntegraContexto context)
        {

        }
    }
}
