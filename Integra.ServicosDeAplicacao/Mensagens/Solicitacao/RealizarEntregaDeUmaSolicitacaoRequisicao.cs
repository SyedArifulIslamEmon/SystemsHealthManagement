namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarEntregaDeUmaSolicitacaoRequisicao
    {
        public int CodigoDaSolicitacao { get; set; }

        public int CodigoDoResponsavel { get; set; }

        public string Observacoes { get; set; }

        public bool Aceita { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}