using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class AprovacaoDeSolicitacaoConfiguracao : EntityTypeConfiguration<AprovacaoDeSolicitacao>
    {
        public AprovacaoDeSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}