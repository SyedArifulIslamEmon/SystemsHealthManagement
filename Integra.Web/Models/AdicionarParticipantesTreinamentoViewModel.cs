using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarParticipantesTreinamentoViewModel
    {
        public IList<PessoaViewModel> Pessoas { get; set; }
        public IList<PessoaViewModel> Participantes { get; set; }
        public int CodigoDoTreinamento { get; set; }
    }
}