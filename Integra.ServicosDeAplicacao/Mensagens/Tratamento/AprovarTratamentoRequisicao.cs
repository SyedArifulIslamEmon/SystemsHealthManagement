namespace Integra.ServicosDeAplicacao.Mensagens.Tratamento
{
    public class AprovarTratamentoRequisicao
    {
        public int CodigoDoTratamento { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public bool Aprovar { get; set; }
        public string Observacoes { get; set; }
    }
}