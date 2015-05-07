using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Equipe
{
    public class RegraDeNegocioEquipeFuncionarioJaPertenceAEstaEquipe : RegraDeNegocioBase
    {
        public RegraDeNegocioEquipeFuncionarioJaPertenceAEstaEquipe() : base("Este funcionario já pertence a esta equipe!")
        {
        }
    }
}