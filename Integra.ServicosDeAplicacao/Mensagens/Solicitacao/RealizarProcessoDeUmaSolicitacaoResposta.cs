namespace Integra.ServicosDeAplicacao.Mensagens.Solicitacao
{
    public class RealizarProcessoDeUmaSolicitacaoResposta : RespostaBase
    {
        public Dominio.Solicitacao Solicitacao { get; set; }
    }
}