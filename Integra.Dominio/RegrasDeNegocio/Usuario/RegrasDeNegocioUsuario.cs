using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Usuario
{
    public static class RegrasDeNegocioUsuario
    {
        public static RegraDeNegocioBase DevePertencerAUmPerfil
        {
            get { return new RegraDeNegocioUsuarioDeveConterUmPerfil(); }
        }

        public static RegraDeNegocioBase NomeDeUsuarioDeveSerUmEmailValido
        {
            get { return new RegraDeNegocioUsuarioONomeDeUsuarioDeveSerUmEmailValido(); }
        }

        public static RegraDeNegocioBase DeveConterUmaSenhaValida { get { return new RegraDeNegocioUsuarioDeveConterUmaSenhaValida(); } }
    }
}