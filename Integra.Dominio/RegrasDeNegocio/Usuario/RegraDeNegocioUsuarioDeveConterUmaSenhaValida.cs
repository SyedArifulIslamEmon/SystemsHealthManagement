using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Usuario
{
    public class RegraDeNegocioUsuarioDeveConterUmaSenhaValida : RegraDeNegocioBase
    {
        public RegraDeNegocioUsuarioDeveConterUmaSenhaValida() : base("Um usuario deve conter uma senha válida!")
        {
        }
    }
}