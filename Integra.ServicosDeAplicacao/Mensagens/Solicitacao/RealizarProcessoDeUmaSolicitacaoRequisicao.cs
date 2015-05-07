namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarProcessoDeUmaSolicitacaoRequisicao
    {
        public string Solucao { get; set; }

        public string Observacoes { get; set; }

        public int CodigoDaSolicitacao { get; set; }

        public int CodigoDoResponsavel { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}