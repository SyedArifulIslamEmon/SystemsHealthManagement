using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Perfil
{
    public class RegraDeNegocioPerfilDeveConterUmGrupo : RegraDeNegocioBase
    {
        public RegraDeNegocioPerfilDeveConterUmGrupo() : base("Um perfil deve conter um grupo!")
        {
        }
    }
}