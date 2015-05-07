using Integra.Web.CustomMembership;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "Todos")]
    public class ErrosController : Controller
    {
        public ActionResult SemAutorizacao()
        {
            return View();
        }

        public ActionResult NaoExiste()
        {
            return View();
        }

        public ActionResult Erro()
        {
            return View();
        }
    }
}
