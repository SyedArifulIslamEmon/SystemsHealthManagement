using System.IO;

namespace Integra.ServicosDeAplicacao.Mensagens.Treinamento
{
    public class AdicionarAnexoEmTreinamentoRequisicao
    {
        public Stream Arquivo { get; set; }
        public int CodigoDoTreinamento { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
    }
}