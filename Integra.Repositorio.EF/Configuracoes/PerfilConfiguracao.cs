using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class PerfilConfiguracao : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}