using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class ClinicaDocumentoViewModel
    {
        public string TipoDoDocumento { get; set; }

        public DateTime DataDeUpload { get; set; }

        public string Descricao { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Responsavel { get; set; }

        public DateTime DataDeVencimento { get; set; }

        public string StatusDocumento { get; set; }
    }
}