using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.RegrasDeNegocio.Ata
{
    public static class RegrasDeNegocioAta
    {
        public static RegraDeNegocioBase RequerUmResponsavel
        {
            get { return new RegraDeNegocioAtaRequerUmResponsavel(); }
        }
    }
}