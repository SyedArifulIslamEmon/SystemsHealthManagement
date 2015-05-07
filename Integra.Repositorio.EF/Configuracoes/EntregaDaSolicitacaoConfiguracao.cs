using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class EntregaDaSolicitacaoConfiguracao : EntityTypeConfiguration<EntregaDaSolicitacao>
    {
        public EntregaDaSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}