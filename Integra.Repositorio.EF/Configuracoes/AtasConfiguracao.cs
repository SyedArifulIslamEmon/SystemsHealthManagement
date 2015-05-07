using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class AtasConfiguracao:EntityTypeConfiguration<Ata>
    {
        public AtasConfiguracao()
        {
            HasMany(it => it.Anexos).WithMany();
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
        }
    }
}