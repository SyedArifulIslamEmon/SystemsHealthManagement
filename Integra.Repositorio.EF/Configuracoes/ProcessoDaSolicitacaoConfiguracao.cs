using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ProcessoDaSolicitacaoConfiguracao : EntityTypeConfiguration<ProcessoDaSolicitacao>
    {
        public ProcessoDaSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}