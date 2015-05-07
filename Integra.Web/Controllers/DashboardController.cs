using Integra.Web.CustomMembership;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "Dashboard")]
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
