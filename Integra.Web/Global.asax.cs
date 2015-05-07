using Integra.Dominio.Repositorios;
using Integra.Repositorio.EF;
using Integra.Web.App_Start;
using Integra.Web.CustomMembership;
using StructureMap;
using System;
using System.Globalization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Integra.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
            var pessoaRepositorio = ObjectFactory.GetInstance<IPessoaRepositorio>();
            var pessoa = pessoaRepositorio.ObterPeloNomeDeUsuario(ticket.Name);
            var identity = new UsuarioIdentity(pessoa);
            var principal = new UsuarioPrincipal(identity);
            HttpContext.Current.User = principal;
        }

        protected void Application_Start()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("PT-BR");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IntegraContexto.Initialize();            
        }
    }
}