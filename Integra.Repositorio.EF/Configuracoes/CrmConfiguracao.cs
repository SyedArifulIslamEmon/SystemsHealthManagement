using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class CrmConfiguracao : EntityTypeConfiguration<CRM>
    {
        public CrmConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}