using System.Collections.Generic;

namespace Integra.Dominio.Teste.Builders
{
    public class PessoaBuilder
    {
        private readonly Usuario _usuario;
        private readonly List<Programa> _programa;
        private readonly string _nome;
        private readonly string _telefone;
        private PessoaBuilder()
        {
            _usuario = UsuarioBuilder.DadoUmUsuario().Build();
            _programa = ProgramaBuilder.DadoUmPrograma().Build();
            _nome = "Nome da pessoa";
            _telefone = "9191919191";
        }

        public static PessoaBuilder DadoUmaPessoa()
        {
            return new PessoaBuilder();
        }

        public Pessoa Build()
        {
            return new Pessoa(_usuario, _nome, _telefone, _programa);
        }
    }
}