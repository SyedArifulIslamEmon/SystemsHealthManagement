using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.ServicosContratados
{
    public class AdicionarServicosContratadosRequisicao
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataContratacao { get; set; }
        public int CodigoDoPrograma { get; set; }
    }
}
