using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Usuario
{
    public class RegraDeNegocioUsuarioDeveConterUmPerfil : RegraDeNegocioBase
    {
        public RegraDeNegocioUsuarioDeveConterUmPerfil()
            : base("Um usuario deve conter um perfil.")
        {
        }
    }
}