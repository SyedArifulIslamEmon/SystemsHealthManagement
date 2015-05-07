using System;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class SolicitacaoViewModel
    {
        public string Protocolo { get; set; }
        public DateTime DataDeAbertura { get; set; }
        public string Situacao { get; set; }
        public int Codigo { get; set; }
        public int DiasSLA { get; set; }
        public SituacaoDaSolicitacao SituacaoCodigo { get; set; }
        public string Solicitante { get; set; }
        public string Tipo { get; set; }
        public Programa Programa { get; set; }
    }
}