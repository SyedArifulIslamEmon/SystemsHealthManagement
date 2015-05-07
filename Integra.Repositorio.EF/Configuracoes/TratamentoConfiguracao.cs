using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class TratamentoConfiguracao : EntityTypeConfiguration<Tratamento>
    {
        public TratamentoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}
