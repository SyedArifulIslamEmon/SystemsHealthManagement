using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class AtasViewModel
    {
        public IList<AtaViewModel> Atas { get; set; }
        public int CodigoDaReuniao { get; set; }
    }
}