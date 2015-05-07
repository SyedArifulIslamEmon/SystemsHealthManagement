using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class GerenteConfiguracao : EntityTypeConfiguration<Gerente>
    {
        public GerenteConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}