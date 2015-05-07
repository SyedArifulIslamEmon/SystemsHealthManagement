using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public class AdicionarUsuarioViewModel
    {
        public string NomeDeUsuario { get; set; }

        public dynamic Perfils { get; set; }
        public int PerfilSelecionado { get; set; }

        public dynamic Grupos { get; set; }
        public int GrupoSelecionado { get; set; }

        public IList<TipoDeCrm> TiposDeCrm { get; set; }
        public int TipoDeCrmSelecionado { get; set; }

        public string NumeroDoCrm { get; set; }
        public string NomeDoCrm { get; set; }

        public IList<Cargo> Cargos { get; set; }
        public int CodigoDoCargo { get; set; }
        public IList<Departamento> Departamentos { get; set; }
        public int CodigoDoDepartamento { get; set; }
        public bool Status { get; set; }
        public string Telefone { get; set; }
        public string Nome { get; set; }
        public string DescricaoDoCargo { get; set; }

        public Grupo GrupoIntegra { get; set; }

        public List<Programa> Programas { get; set; }

        public List<int> CodigosDosProgramas { get; set; }

        public int Codigo { get; set; }
    }
}