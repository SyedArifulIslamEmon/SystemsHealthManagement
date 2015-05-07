using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.ServicosContratados
{
    public class AlterarServicosContratadosRequisicao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CodigoSevicoContratado { get; set; }
    }
}
