using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AlterarReuniaoRequisicao
    {
        public int CodigoDoResponsavel { get; set; }
        public int CodigoDaReuniao { get; set; }
        public StatusDaReunicao Status { get; set; }
        public DateTime Realizacao { get; set; }
        public string Assunto { get; set; }
        public string Local { get; set; }
    }
}