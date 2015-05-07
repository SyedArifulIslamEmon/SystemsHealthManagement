using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class AdicionarMembrosEquipeViewModel
    {
        public IList<FuncionarioViewModel> Funcionarios { get; set; } 
        public IList<FuncionarioViewModel> Membros { get; set; }

        public int CodigoDaEquipe { get; set; }
    }
}