using Integra.Dominio;
using Integra.Dominio.Repositorios;
using Integra.ServicosDeAplicacao;
using Integra.ServicosDeAplicacao.Mensagens.Tratamento;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.Models;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "GestaoDeTratamentos")]
    public class TratamentoController : BaseController
    {
        private readonly TratamentoServicoDeAplicacao _tratamentoServicoDeAplicacao;
        private readonly ITratamentoRepositorio _tratamentoRepositorio;

        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public TratamentoController(TratamentoServicoDeAplicacao tratamentoServicoDeAplicacao, ITratamentoRepositorio tratamentoRepositorio, IFuncionarioRepositorio funcionarioRepositorio)
        {
            _tratamentoServicoDeAplicacao = tratamentoServicoDeAplicacao;
            _tratamentoRepositorio = tratamentoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public ActionResult Index()
        {
            var tratamentos = _tratamentoRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View(tratamentos);
        }

        public PartialViewResult AddEditTratamento()
        {
            var viewModal = new AdicionarTratamentoViewModel
                {
                    Funcionarios = _funcionarioRepositorio.ObterTodos().ToViewModel(),
                    ListaDeStatus = typeof (StatusDoTratamento).ToViewModel()
                };
            return PartialView(viewModal);
        }

        [HttpPost]
        public JsonResult AddEditTratamento(AdicionarTratamentoViewModel novoTratamentoViewModel)
        {
            var requisicao = new AdicionarTratamentoRequisicao
            {
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                DataSolicitacao = novoTratamentoViewModel.DataSolicitacao,
                Ifx = novoTratamentoViewModel.Ifx,
                Medico = novoTratamentoViewModel.Medico,
                Representante = novoTratamentoViewModel.Representante,
                MotivoSolicitacao = novoTratamentoViewModel.MotivoSolicitacao,
                CodigoDoGrupoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo
            };

            var resposta = _tratamentoServicoDeAplicacao.AdicionarTratamento(requisicao);

            return Json(new { resposta.Erros, resposta.Sucesso, Tratamento = resposta.Tratamento.ToViewModel() });
        }

        [HttpPost]
        public JsonResult ExcluirTratamento(int codigo)
        {
            var requisicao = new ExcluirTratamentoRequisicao
            {
                CodigoDoTratamento = codigo
            };

            var respota = _tratamentoServicoDeAplicacao.ExcluirTratamento(requisicao);

            return Json(respota);
        }

        [HttpPost]
        public JsonResult AprovarTratamento(int codigoDoTratamento, bool aprovado, string observacoes)
        {
            var requisicao = new AprovarTratamentoRequisicao
            {
                Aprovar = aprovado,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                CodigoDoTratamento = codigoDoTratamento,
                Observacoes = observacoes
            };
            var resposta = _tratamentoServicoDeAplicacao.AprovarTratamento(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Tratamento = resposta.Tratamento.ToViewModel() });
        }
    }
}
