using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Equipe
{
    public class RegraDeNegocioEquipeProgramaJaTemUmaEquipe : RegraDeNegocioBase
    {
        public RegraDeNegocioEquipeProgramaJaTemUmaEquipe() : base("Um programa só pode ter uma equipe! O programa selecionado já tem uma equipe.")
        {
        }
    }
}