using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Equipe
{
    public class RegraDeNegocioEquipeProgramaJaTemUmaEquipe : RegraDeNegocioBase
    {
        public RegraDeNegocioEquipeProgramaJaTemUmaEquipe() : base("Um programa s� pode ter uma equipe! O programa selecionado j� tem uma equipe.")
        {
        }
    }
}