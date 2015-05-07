using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Treinamento
{
    public class AdicionarParticipantesNoTreinamentoRequisicao
    {
        public int CodigoDoTreinamento { get; set; }
        public List<int> CodigosDosParticipantes { get; set; }
    }
}