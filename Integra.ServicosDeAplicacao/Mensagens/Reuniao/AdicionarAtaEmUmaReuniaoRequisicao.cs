using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarAtaEmUmaReuniaoRequisicao
    {
        public int CodigoDaReuniao { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public string Assunto { get; set; }
        public DateTime FinalDoPrazo { get; set; }
        public DateTime InicioDoPrazo { get; set; }
        public string Anotacoes { get; set; }
        public StatusDaAta Status { get; set; }
    }
}