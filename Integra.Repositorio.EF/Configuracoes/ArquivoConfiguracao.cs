using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ArquivoConfiguracao : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoConfiguracao()
        {
            HasKey(it => it.Codigo);
            Property(it => it.DataDeUpload);
        }
    }
}
