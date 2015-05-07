namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarAnalizeDeUmaSolicitacaoRequisicao
    {
        public int CodigoDaSolicitacao { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public bool ClientePrecisaAprovar { get; set; }
        public string Atividade { get; set; }
        public decimal Custo { get; set; }
        public int DiasParaEntrega { get; set; }
        public string Analise { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}