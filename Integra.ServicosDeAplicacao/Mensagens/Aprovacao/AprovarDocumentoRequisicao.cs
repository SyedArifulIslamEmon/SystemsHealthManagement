namespace Integra.ServicosDeAplicacao.Mensagens.Aprovacao
{
    public class AprovarDocumentoRequisicao
    {
        public int CodigoDaAprovacao { get; set; }
        public int CodigoDoResponsavel { get; set; }
        public bool Aprovar { get; set; }
    }
}