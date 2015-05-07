using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ClinicaConfiguracao : EntityTypeConfiguration<Clinica>
    {
        public ClinicaConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);
            HasMany(it => it.Documentos).WithMany();
        }
    }
}
