using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class InfusaoConfiguracao : EntityTypeConfiguration<Infusao>
    {
        public InfusaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Clinica);
            HasRequired(it => it.Programa);
        }
    }
}
