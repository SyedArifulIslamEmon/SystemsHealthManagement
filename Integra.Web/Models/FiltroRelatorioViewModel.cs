using System.Web;
using Integra.Dominio;

namespace Integra.Web.Models
{
    public static class FiltroRelatorioViewModel
    {
/*
        static FiltroRelatorioParametros _listaParametros;
*/

        //static FiltroRelatorioViewModel()
        //{
        //    _listaParametros = new FiltroRelatorioParametros();
        //}


        public static FiltroRelatorioParametros ListarRelatorioParametros
        {
            //get
            //{
            //    if (HttpContext.Current.Session["RelatorioFiltros"] != null)
            //    {
            //        _listaParametros = (FiltroRelatorioParametros)HttpContext.Current.Session["RelatorioFiltros"];
            //    }
            //    else
            //    {
            //        HttpContext.Current.Session["RelatorioFiltros"] = new FiltroRelatorioParametros();
            //        _listaParametros = new FiltroRelatorioParametros();
            //    }
            //    return _listaParametros;
            //}
            //set { HttpContext.Current.Session["RelatorioFiltros"] = value; }

            get { return (FiltroRelatorioParametros) HttpContext.Current.Session["RelatorioFiltros"]; }
            set { HttpContext.Current.Session["RelatorioFiltros"] = value; }

        }

        public static FiltroRelatorioParametros SetP1
        {
            set
            {
                HttpContext.Current.Session["RelatorioFiltros"] = value;
            }
        }
    }
}