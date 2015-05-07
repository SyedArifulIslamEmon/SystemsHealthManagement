using System;

namespace Integra.ServicosDeAplicacao.Mensagens.Treinamento
{
    public class AlterarTreinamentoRequisicao
    {
        public int CodigoDoTreinamento { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Local { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}