using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class EquipeConfiguracao:EntityTypeConfiguration<Equipe>
    {
        public EquipeConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
            HasMany(it => it.MenbrosDaEquipe).WithMany();
        }
    }
}