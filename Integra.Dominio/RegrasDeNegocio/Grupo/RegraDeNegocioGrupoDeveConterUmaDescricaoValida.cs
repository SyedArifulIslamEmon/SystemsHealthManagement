using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Grupo
{
    public class RegraDeNegocioGrupoDeveConterUmaDescricaoValida : RegraDeNegocioBase
    {
        public RegraDeNegocioGrupoDeveConterUmaDescricaoValida()
            : base("Um grupo deve conter uma descrição valida!")
        {
        }
    }
}