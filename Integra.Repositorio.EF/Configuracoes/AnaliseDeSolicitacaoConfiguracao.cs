using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class AnaliseDeSolicitacaoConfiguracao : EntityTypeConfiguration<AnaliseDeSolicitacao>
    {
        public AnaliseDeSolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}