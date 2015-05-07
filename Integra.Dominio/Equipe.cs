using System.Collections.Generic;
using System.Linq;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Equipe;

namespace Integra.Dominio
{
    public class Equipe : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Programa Programa { get; private set; }
        public virtual List<Funcionario> MenbrosDaEquipe { get; private set; }

        protected Equipe() { }

        public Equipe(Programa programa)
        {
            MenbrosDaEquipe = new List<Funcionario>();
            Programa = programa;
            Validar();
        }

        public void AdicionarMembro(Funcionario funcionario)
        {
            if (MenbrosDaEquipe.Any(f => f.Codigo == funcionario.Codigo))
                RegraQuebrada(RegrasDeNegocioEquipe.FuncionarioJaPertenceAEstaEquipe);
            MenbrosDaEquipe.Add(funcionario);
        }

        protected override sealed void Validar()
        {
            if(Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioEquipe.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }
    }
}