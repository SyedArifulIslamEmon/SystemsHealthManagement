using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class RepresentanteRegionalConfiguracao : EntityTypeConfiguration<RepresentanteRegional>
    {
        public RepresentanteRegionalConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}