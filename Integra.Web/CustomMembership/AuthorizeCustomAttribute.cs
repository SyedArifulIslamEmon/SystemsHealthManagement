using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Integra.Dominio.Repositorios;
using Integra.Web.Helpers;
using StructureMap;

namespace Integra.Web.CustomMembership
{
    public class AuthorizeCustomAttribute : AuthorizeAttribute
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IModuloRepositorio _moduloRepositorio;
        public string Modulo { get; set; }

        public AuthorizeCustomAttribute()
        {
            _pessoaRepositorio = ObjectFactory.GetInstance<IPessoaRepositorio>();
            _moduloRepositorio = ObjectFactory.GetInstance<IModuloRepositorio>();
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var httpContext = filterContext.HttpContext;
            if (!httpContext.User.Identity.IsAuthenticated) return;

            var pessoa = _pessoaRepositorio.ObterPeloNomeDeUsuario(httpContext.User.Identity.Name);
            var modulo = _moduloRepositorio.ObterPor(Modulo);
            if (modulo == null)
            {
                if (pessoa != null && Modulo.ToUpper().Equals("TODOS") && httpContext.Session.ProgramaAtivo() == null)
                {
                    httpContext.Session.SetProgramaAtivo(pessoa.ProgramasPermitidos[0]);
                }
                return;
            }

            if (modulo.TemPermissao(pessoa.Usuario))
            {
                httpContext.Session.SetProgramaAtivo(httpContext.Session.ProgramaAtivo() ?? pessoa.ProgramasPermitidos[0]);
                return;
            }

            SemAutorizacaoParaAcessarEssaArea(filterContext);
        }

        private static void SemAutorizacaoParaAcessarEssaArea(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.SkipAuthorization = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {
                        {"action", "SemAutorizacao"},
                        {"controller", "Erros"}
                    });
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
            filterContext.HttpContext.Response.End();
        }
    }
}
