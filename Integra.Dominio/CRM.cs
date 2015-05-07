using Integra.Dominio.Base;
using Integra.Dominio.RegrasDeNegocio.Crm;

namespace Integra.Dominio
{
    public class CRM : EntidadeBase<int>
    {
        public virtual string NumeroDoCRM { get; set; }
        public virtual TipoDeCrm Tipo { get; private set; }
        public virtual string NomeDoCRM { get; set; }

        protected CRM()
        {

        }

        public CRM(string numeroDoCRM, TipoDeCrm tipo, string nomeDoCRM)
        {
            NumeroDoCRM = numeroDoCRM;
            Tipo = tipo;
            NomeDoCRM = nomeDoCRM;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (Tipo == null)
                AdicionarRegraQuebrada(RegrasDeNegocioCrm.RequerUmTipoDeCrm);
            //if (string.IsNullOrWhiteSpace(NumeroDoCRM))
            //    AdicionarRegraQuebrada(RegrasDeNegocioCrm.RequerUmNumeroDoCrmValido);
            NotificarSeHouverAlgumErro();
        }
    }
}