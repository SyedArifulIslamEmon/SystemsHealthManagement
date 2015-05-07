using System;
using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Faturamento
{
    public class PagarNotaFiscalRequisicao
    {
        public int CodigoDaNota { get; set; }
        public string DescricaoDoComprovante { get; set; }
        public string NomeDoComprovante { get; set; }
        public string Observacao { get; set; }
        public Stream Comprovante { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}