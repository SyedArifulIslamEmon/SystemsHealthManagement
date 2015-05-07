using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Grupo
{
    public static class RegrasDeNegocioGrupo
    {
        public static RegraDeNegocioBase DeveConterUmaDescricaoValida { get { return new RegraDeNegocioGrupoDeveConterUmaDescricaoValida(); } }
    }
}