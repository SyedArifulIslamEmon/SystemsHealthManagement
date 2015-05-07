using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Programa
{
    public class AdicionarProgramaRequisicao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Identificador { get; set; }
        public int CodigoAuxiliar { get; set; }
    }
}