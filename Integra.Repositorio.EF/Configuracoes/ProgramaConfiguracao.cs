using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ProgramaConfiguracao : EntityTypeConfiguration<Programa>
    {
        public ProgramaConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}