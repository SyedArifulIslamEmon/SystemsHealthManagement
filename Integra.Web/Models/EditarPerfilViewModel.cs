using System.Collections.Generic;

namespace Integra.Web.Models
{
    public class EditarPerfilViewModel
    {
        public dynamic Modulos { get; set; }
        public dynamic Grupos { get; set; }
        public string Nome { get; set; }
        public int Grupo { get; set; }
        public int CodigoPerfil { get; set; }
        public List<int> CodigoDosModulosSelecionados { get; set; }
    }
}