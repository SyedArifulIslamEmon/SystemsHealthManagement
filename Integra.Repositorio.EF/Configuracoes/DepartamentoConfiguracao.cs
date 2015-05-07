using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class DepartamentoConfiguracao : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}