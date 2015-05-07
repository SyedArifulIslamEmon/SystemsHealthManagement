using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class PagamentoConfiguracao : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoConfiguracao()
        {
            HasKey(it => it.Codigo);
        }

    }
}