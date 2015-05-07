using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class EquipeViewModel
    {
        public int Codigo { get; set; }
        public string Programa { get; set; }
        public IList<FuncionarioViewModel> Membros { get; set; }
    }
}