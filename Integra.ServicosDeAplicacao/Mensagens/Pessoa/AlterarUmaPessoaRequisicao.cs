using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Pessoa
{
    public class AlterarUmaPessoaRequisicao
    {
        public int CodigoDoCargo { get; set; }

        public int CodigoDoDepartamento { get; set; }

        public int CodigoDoPerfil { get; set; }

        public List<int> CodigosDosProgramas { get; set; }

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Descricao { get; set; }

        public bool Inativo { get; set; }

        public string NumeroDoCrm { get; set; }

        public int CodigoDoTipoDeCrm { get; set; }

        public string NomeDeUsuario { get; set; }

        public string NomeDoCrm { get; set; }

    }
}