using System;
using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AdicionarDocumentoEmUmaClinicaRequisicao
    {
        public Stream Documento { get; set; }
        public int CodigoDaClinica { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TipoDocumentoDaClinica TipoDocumento { get; set; }

        public int CodigoDoResponsavel { get; set; }

        public DateTime DataDeVencimento { get; set; }
        public DocumentoStatus StatusDocumento { get; set; }
    }
}
