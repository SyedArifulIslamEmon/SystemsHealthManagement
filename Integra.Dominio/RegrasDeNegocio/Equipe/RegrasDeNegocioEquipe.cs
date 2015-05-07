using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Equipe
{
    public static class RegrasDeNegocioEquipe
    {
        public static RegraDeNegocioBase FuncionarioJaPertenceAEstaEquipe
        {
            get { return new RegraDeNegocioEquipeFuncionarioJaPertenceAEstaEquipe(); }
        }

        public static RegraDeNegocioBase DeveTerUmPrograma { get { return new RegraDeNegocioEquipeDeveTerUmPrograma(); } }

        public static RegraDeNegocioBase EsteProgramaJaTemUmaEquipe { get { return new RegraDeNegocioEquipeProgramaJaTemUmaEquipe(); } }
    }
}