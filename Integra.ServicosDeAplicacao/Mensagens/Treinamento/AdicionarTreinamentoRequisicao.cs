using System;

namespace Integra.ServicosDeAplicacao.Mensagens.Treinamento
{
    public class AdicionarTreinamentoRequisicao
    {
        public int CodigoDoPrograma { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public DateTime DataRealizacao { get; set; }        
        public string Local { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}