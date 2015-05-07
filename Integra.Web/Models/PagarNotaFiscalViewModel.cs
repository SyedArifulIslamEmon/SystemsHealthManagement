using System;
using System.Web;

namespace Integra.Web.Models
{
    public class PagarNotaFiscalViewModel
    {
        public HttpPostedFileBase Arquivo { get; set; }
        public int Codigo { get; set; }
        public string Observacao { get; set; }
        public string DataPagamento { get; set; }
    }
}