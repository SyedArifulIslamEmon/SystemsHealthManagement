using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ClinicaDocumentosConfiguracao : EntityTypeConfiguration<ClinicaDocumentos>
    {
        public ClinicaDocumentosConfiguracao()
        {
            HasKey(it => it.Codigo);
            Property(it => it.DataDeUpload).IsRequired();
        }
    }
}
