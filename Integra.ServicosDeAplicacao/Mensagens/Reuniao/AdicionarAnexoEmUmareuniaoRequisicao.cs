using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarAnexoEmUmareuniaoRequisicao
    {
        public Stream Arquivo { get; set; }
        public int CodigoDaReuniao { get; set; }

        public string Descricao { get; set; }

        public string Nome { get; set; }
    }
}