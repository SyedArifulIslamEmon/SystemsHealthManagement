using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ServicosContratadosConfiguracao : EntityTypeConfiguration<ServicosContratados>
    {
        public ServicosContratadosConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasRequired(it => it.Programa);

            Property(it => it.Nome).IsRequired();
            Property(it => it.DataContratacao).IsRequired();            

            ToTable("ServicosContratados");
        }
    }
}
