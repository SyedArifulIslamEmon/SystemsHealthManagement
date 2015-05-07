namespace Integra.ServicosDeAplicacao.Mensagens.Faturamento
{
    public class DevolverNotaRequisicao : NovaNotaRequisicao
    {
        public string Motivo { get; set; }
        public string TipoDeDevolucao { get; set; }
    }
}