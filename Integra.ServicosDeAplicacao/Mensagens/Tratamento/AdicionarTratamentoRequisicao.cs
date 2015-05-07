using System;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Tratamento
{
    public class AdicionarTratamentoRequisicao
    {
        public int CodigoDoPrograma { get; set; }

        public DateTime DataSolicitacao { get; set; }
        public string Ifx { get; set; }
        public string Medico { get; set; }
        public string Representante { get; set; }
        public string MotivoSolicitacao { get; set; }

        public int CodigoDoGrupoResponsavel { get; set; }
    }
}