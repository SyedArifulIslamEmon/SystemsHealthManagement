using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarParticipantesReuniaoViewModel
    {
        public IList<PessoaViewModel> Pessoas { get; set; }
        public IList<PessoaViewModel> Participantes { get; set; }
        public int CodigoDaReuniao { get; set; }
    }
}