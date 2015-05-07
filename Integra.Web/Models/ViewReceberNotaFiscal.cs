using System;
using System.Collections.Generic;
using System.Web;
using Integra.ServicosDeAplicacao.Mensagens.Faturamento;

namespace Integra.Web.Models
{
    public class ViewReceberNotaFiscal
    {
        public ViewReceberNotaFiscal()
        {
            Infusoes = new List<AssociarInfusao>();
        }
        public List<AssociarInfusao> Infusoes { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
        public int CodigoDaClinica { get; set; }
        public string Data { get; set; }
        public DateTime DataRecebimento { get; set; }
        public Decimal Valor { get; set; }
        public string Numero { get; set; }
        public string FormaDevolucao { get; set; }
        public string Motivo { get; set; }
    }
}