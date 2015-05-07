using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.TipoDeCrm;

namespace Integra.Dominio
{
    public class TipoDeCrm : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual string Descricao { get; private set; }
        public virtual string FlagCrm { get; private set; }

        protected TipoDeCrm()
        {

        }

        public TipoDeCrm(string descricao, string flagCrm)
        {
            Descricao = descricao;
            FlagCrm = flagCrm;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                AdicionarRegraQuebrada(RegrasDeNegocioTipoDeCrm.DeveConterUmaDescricao);
            NotificarSeHouverAlgumErro();
        }
    }
}