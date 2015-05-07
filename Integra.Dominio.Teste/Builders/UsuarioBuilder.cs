namespace Integra.Dominio.Teste.Builders
{
    public class UsuarioBuilder
    {
        private const string NomeDeUsuario = "algumacoisa@algumacoisa.com";
        private const string Senha = "algumasenha";
        private Perfil _perfils = PerfilBuilder.DadoUmPerfil().Build();

        private UsuarioBuilder()
        {
        }

        public static UsuarioBuilder DadoUmUsuario()
        {
            return new UsuarioBuilder();
        }

        public UsuarioBuilder ComOPerfil(Perfil perfil)
        {
            _perfils = perfil;
            return this;
        }

        public Usuario Build()
        {
            return new Usuario(NomeDeUsuario, Senha, _perfils);
        }
    }
}