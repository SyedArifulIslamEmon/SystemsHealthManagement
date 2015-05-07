using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace Integra.Repositorio.EF.Migrations
{
    public class NonSystemTableSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected void GenerateMakeSystemTable(
            CreateTableOperation createTableOperation)
        {
        }
    }
}