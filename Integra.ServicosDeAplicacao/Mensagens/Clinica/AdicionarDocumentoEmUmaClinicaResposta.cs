namespace Integra.ServicosDeAplicacao.Mensagens.Clinica
{
    public class AdicionarDocumentoEmUmaClinicaResposta : RespostaBase
    {
        public Dominio.ClinicaDocumentos Documento { get; set; }
    }
}