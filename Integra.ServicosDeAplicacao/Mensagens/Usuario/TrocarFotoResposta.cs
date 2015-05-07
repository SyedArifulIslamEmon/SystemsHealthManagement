using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Usuario
{
    public class TrocarFotoResposta : RespostaBase
    {
        public Arquivo Foto { get; set; }
    }
}