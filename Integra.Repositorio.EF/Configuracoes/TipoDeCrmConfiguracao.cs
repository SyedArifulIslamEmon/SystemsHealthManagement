using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class TipoDeCrmConfiguracao : EntityTypeConfiguration<TipoDeCrm>
    {
        public TipoDeCrmConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}