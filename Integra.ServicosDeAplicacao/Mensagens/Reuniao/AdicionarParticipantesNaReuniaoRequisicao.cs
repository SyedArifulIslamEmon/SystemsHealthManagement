using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarParticipantesNaReuniaoRequisicao
    {
        public int CodigoDaReuniao { get; set; }
        public List<int> CodigosDosParticipantes { get; set; }
    }
}