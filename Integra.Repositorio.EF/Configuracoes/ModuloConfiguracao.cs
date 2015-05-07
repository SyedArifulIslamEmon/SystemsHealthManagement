using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ModuloConfiguracao:EntityTypeConfiguration<Modulo>
    {
        public ModuloConfiguracao()
        {
            HasKey(it => it.Codigo);
        } 
    }
}