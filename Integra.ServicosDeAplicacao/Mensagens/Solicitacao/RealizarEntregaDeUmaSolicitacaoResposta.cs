namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarEntregaDeUmaSolicitacaoResposta : RespostaBase
    {
        public Dominio.Solicitacao Solicitacao { get; set; }
    }
}