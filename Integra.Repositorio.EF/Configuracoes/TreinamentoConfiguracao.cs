using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class TreinamentoConfiguracao : EntityTypeConfiguration<Treinamento>
    {
        public TreinamentoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasMany(it => it.Anexos).WithMany();
            HasMany(it => it.Participantes).WithMany();
            HasRequired(it => it.Programa);
            HasRequired(it => it.Responsavel);
            HasRequired(it => it.Programa);
        }
    }
}
