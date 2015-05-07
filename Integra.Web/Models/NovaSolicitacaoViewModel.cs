using System;
using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class NovaSolicitacaoViewModel
    {
        public IList<TipoDaSolicitacao> Tipos { get; set; }
        public string Solicitacao { get; set; }
        public string Protocolo { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public int CodigoDoTipoDaSolicitacao { get; set; }
    }
}