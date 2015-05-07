namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarAprovacaoDeUmaSolicitacaoRequisicao
    {
        public int CodigoDaSolicitacao { get; set; }

        public int CodigoDoResponsavel { get; set; }

        public bool Aprovado { get; set; }

        public string Observacoes { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}