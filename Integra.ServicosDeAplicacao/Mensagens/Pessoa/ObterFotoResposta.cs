using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Pessoa
{
    public class ObterFotoResposta : RespostaBase
    {
        public Stream Foto { get; set; }
    }
}