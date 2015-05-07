using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class AberturaDeSolicitacaoConfiguracao : EntityTypeConfiguration<AberturaDeSolicitacao>
    {
        public AberturaDeSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}