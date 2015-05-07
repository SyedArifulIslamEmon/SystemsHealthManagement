using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Crm
{
    public class RegrasDeNegocioCrm
    {
        public static RegraDeNegocioBase RequerUmTipoDeCrm
        {
            get { return new RegraDeNegocioCrmRequerUmTipoDeCrm(); }
        }

        public static RegraDeNegocioBase RequerUmNumeroDoCrmValido
        {
            get { return new RegraDeNegocioCrmRequerUmNumeroValido(); }
        }
    }
}
