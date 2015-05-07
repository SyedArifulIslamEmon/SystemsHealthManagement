using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Perfil
{
    public static class RegrasDeNegocioPerfil
    {
        public static RegraDeNegocioBase DeveConterUmGrupo { get { return new RegraDeNegocioPerfilDeveConterUmGrupo(); }
        }
    }
}