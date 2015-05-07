using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class TipoDaSolicitacaoConfiguracao : EntityTypeConfiguration<TipoDaSolicitacao>
    {
        public TipoDaSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}