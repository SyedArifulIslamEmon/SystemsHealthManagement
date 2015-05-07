using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class UsuarioConfiguracao:EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Perfil);            
        }
    }
}
