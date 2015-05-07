using System;
using System.Collections.Generic;
using System.Web;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarClinicaDocumentosViewModel
    {
        public int Codigo { get; set; }
        public int CodigoDaClinica { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public FuncionarioViewModel Responsavel { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public HttpPostedFileBase Documento { get; set; }
        public IList<ClinicaDocumentoViewModel> Documentos { get; set; }
        public DateTime DataDeUpload { get; set; }

        public TipoDocumentoDaClinica TipoDocumento { get; set; }
        public dynamic ListaDeTipoDocumentoDaClinica { get; set; }

        public DateTime DataDeVencimento { get; set; }

        public DocumentoStatus StatusDocumento { get; set; }
        public dynamic ListaDeTipoStatusDocumento { get; set; }
    }
}