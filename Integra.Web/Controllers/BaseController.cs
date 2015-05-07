using BootstrapSupport;
using Integra.Dominio.Repositorios;
using StructureMap;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var grupoRepositorio = ObjectFactory.GetInstance<IGrupoRepositorio>();
            ViewBag.GrupoIntegra = grupoRepositorio.ObterGrupoIntegra();
        }

        public void Attention(string message)
        {
            TempData.Add(Alerts.ATTENTION, message);
        }

        public void Success(string message)
        {
            TempData.Add(Alerts.SUCCESS, message);
        }

        public void Information(string message)
        {
            TempData.Add(Alerts.INFORMATION, message);
        }

        public void Error(string message)
        {
            TempData.Add(Alerts.ERROR, message);
        }
    }
}
