using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class SolicitacaoConfiguracao : EntityTypeConfiguration<Solicitacao>
    {
        public SolicitacaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasOptional(it => it.Aprovacao).WithRequired();
            HasOptional(it => it.Abertura).WithRequired();
            HasOptional(it => it.Analise).WithRequired();
            HasOptional(it => it.Entrega).WithRequired();
            HasOptional(it => it.Processo).WithRequired();
        }
    }
}