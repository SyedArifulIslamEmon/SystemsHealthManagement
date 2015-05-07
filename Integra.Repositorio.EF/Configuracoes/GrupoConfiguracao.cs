using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class GrupoConfiguracao : EntityTypeConfiguration<Grupo>
    {
        public GrupoConfiguracao()
        {
            HasKey(it => it.Codigo);
            ToTable("Grupos");
        }
    }
}