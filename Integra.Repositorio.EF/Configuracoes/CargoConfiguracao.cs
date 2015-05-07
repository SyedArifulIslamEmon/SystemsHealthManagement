using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class CargoConfiguracao : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}