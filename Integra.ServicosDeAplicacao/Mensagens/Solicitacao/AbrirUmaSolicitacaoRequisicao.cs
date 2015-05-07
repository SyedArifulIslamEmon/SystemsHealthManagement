namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class AbrirUmaSolicitacaoRequisicao
    {
        public int CodigoDoTipoDaSolicitacao { get; set; }

        public string Protocolo { get; set; }

        public string Descricao { get; set; }

        public int CodigoDoResponsavel { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}