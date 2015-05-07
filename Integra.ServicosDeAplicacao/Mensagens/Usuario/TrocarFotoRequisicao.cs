using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Usuario
{
    public class TrocarFotoRequisicao
    {
        public int CodigoDaPessoa { get; set; }
        public string Nome { get; set; }
        public Stream Foto { get; set; }
    }
}