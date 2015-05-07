using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class RepresentanteConfiguracao : EntityTypeConfiguration<Representante>
    {
        public RepresentanteConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}