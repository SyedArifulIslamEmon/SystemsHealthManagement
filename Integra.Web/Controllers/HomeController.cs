using Integra.Dominio.Repositorios;
using Integra.ServicosDeAplicacao;
using Integra.ServicosDeAplicacao.Mensagens.Pessoa;
using Integra.ServicosDeAplicacao.Mensagens.Usuario;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "TODOS")]
    public class HomeController : BaseController
    {
        private readonly IModuloRepositorio _moduloRepositorio;
        private readonly PessoaServicoDeAplicacao _pessoaServicoDeAplicacao;

        public HomeController(IModuloRepositorio moduloRepositorio, PessoaServicoDeAplicacao pessoaServicoDeAplicacao)
        {
            _moduloRepositorio = moduloRepositorio;
            _pessoaServicoDeAplicacao = pessoaServicoDeAplicacao;
        }

        public PartialViewResult AlterarFoto()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AlterarFoto(HttpPostedFileBase foto)
        {
            var requisicao = new TrocarFotoRequisicao
                                 {
                                     Foto = foto.InputStream,
                                     Nome = foto.FileName,
                                     CodigoDaPessoa = User.ToPessoa().Codigo
                                 };

            var resposta = _pessoaServicoDeAplicacao.TrocarFoto(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros });
        }

        public ActionResult Index()
        {
            var homeIndexModel = new HomeIndexViewModel { Modulos = _moduloRepositorio.ObterTodos() };
            return View(homeIndexModel);
        }

        public ActionResult Ajuda()
        {
            return View();
        }

        public ActionResult TermosUso()
        {
            return View();
        }

        public ActionResult PoliticaPrivacidade()
        {
            return View();
        }

        public ActionResult Desenvolvimento()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RemoverFoto()
        {
            var requisicao = new RemoverFotoRequisicao
            {
                CodigoDaPessoa = User.ToPessoa().Codigo
            };

            var resposta = _pessoaServicoDeAplicacao.RemoverFoto(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros });
        }

        public ActionResult Foto()
        {
            var requisicao = new ObterFotoRequisicao
                                 {
                                     CodigoDaPessoa = User.ToPessoa().Codigo
                                 };
            var foto = _pessoaServicoDeAplicacao.ObterFoto(requisicao);
            return File(foto.Foto, "image/jpg");
        }

        public JsonResult TrocarProgramaAtivo(int codigo)
        {
            Session.SetProgramaAtivo(User.ToPessoa().ProgramasPermitidos.SingleOrDefault(it => it.Codigo == codigo));
            return Json(true);
        }
    }
}
