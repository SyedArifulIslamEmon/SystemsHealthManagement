using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Aprovacao
{
    public class AdicionarAprovacaoRequisicao
    {
        public string Descricao { get; set; }
        public string NomeDoAnexo { get; set; }
        public TipoDaAprovacao Tipo { get; set; }
        public Stream Arquivo { get; set; }
        public int CodigoDoGrupoResponsavel { get; set; }
        public string Titulo { get; set; }

        public int CodigoDoPrograma { get; set; }
    }
}