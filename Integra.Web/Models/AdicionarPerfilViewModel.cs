using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class AdicionarPerfilViewModel
    {
        public dynamic Modulos { get; set; }
        public dynamic Grupos { get; set; }
        public string Nome { get; set; }
        public int Grupo { get; set; }
        public List<int> CodigoDosModulosSelecionados { get; set; }
    }
}