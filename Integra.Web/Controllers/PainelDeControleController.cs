using Integra.Dominio;
using Integra.Dominio.Repositorios;
using Integra.ServicosDeAplicacao;
using Integra.ServicosDeAplicacao.Mensagens.Aprovacao;
using Integra.ServicosDeAplicacao.Mensagens.Equipe;
using Integra.ServicosDeAplicacao.Mensagens.Fatura;
using Integra.ServicosDeAplicacao.Mensagens.Ovidoria;
using Integra.ServicosDeAplicacao.Mensagens.Pessoa;
using Integra.ServicosDeAplicacao.Mensagens.Reuniao;
using Integra.ServicosDeAplicacao.Mensagens.ServicosContratados;
using Integra.ServicosDeAplicacao.Mensagens.Solicitacao;
using Integra.ServicosDeAplicacao.Mensagens.Treinamento;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "PainelDeControle")]
    public class PainelDeControleController : BaseController
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        private readonly EquipeServicoDeAplicacao _equipeServicoDeAplicacao;
        private readonly IEquipeRepositorio _equipeRepositorio;

        private readonly FaturaServicoDeAplicacao _faturaServicoDeAplicacao;
        private readonly IFaturaRepositorio _faturaRepositorio;

        private readonly ReuniaoServicoDeAplicacao _reuniaoServicoDeAplicacao;
        private readonly IReuniaoRepositorio _reuniaoRepositorio;

        private readonly ServicosContratadosServicoDeAplicacao _servicosContratadosServicoDeAplicacao;
        private readonly IServicosContratadosRepositorio _servicosContratadosRepositorio;

        private readonly TreinamentoServicoDeAplicacao _treinamentoServicoDeAplicacao;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        private readonly ISolicitacaoRepositorio _solicitacaoRepositorio;
        private readonly ITipoDaSolicitacaoRepositorio _tipoDaSolicitacaoRepositorio;
        private readonly PessoaServicoDeAplicacao _pessoaServicoDeAplicacao;

        private readonly AprovacaoServicoDeAplicacao _aprovacaoServicoDeAplicacao;
        private readonly SolicitacaoServicoDeAplicacao _solicitacaoServicoDeAplicacao;
        private readonly OuvidoriaServicoDeAplicacao _ouvidoriaServicoDeAplicacao;

        public PainelDeControleController(ReuniaoServicoDeAplicacao reuniaoServicoDeAplicacao, EquipeServicoDeAplicacao equipeServicoDeAplicacao,
            FaturaServicoDeAplicacao faturaServicoDeAplicacao, ServicosContratadosServicoDeAplicacao servicosContratadosServicoDeAplicacao,
            TreinamentoServicoDeAplicacao treinamentoServicoDeAplicacao, AprovacaoServicoDeAplicacao aprovacaoServicoDeAplicacao, SolicitacaoServicoDeAplicacao solicitacaoServicoDeAplicacao,
            OuvidoriaServicoDeAplicacao ouvidoriaServicoDeAplicacao, IPessoaRepositorio pessoaRepositorio, IFuncionarioRepositorio funcionarioRepositorio,
            IEquipeRepositorio equipeRepositorio, IFaturaRepositorio faturaRepositorio, IReuniaoRepositorio reuniaoRepositorio,
            IServicosContratadosRepositorio servicosContratadosRepositorio, ITreinamentoRepositorio treinamentoRepositorio,
            ISolicitacaoRepositorio solicitacaoRepositorio, ITipoDaSolicitacaoRepositorio tipoDaSolicitacaoRepositorio, PessoaServicoDeAplicacao pessoaServicoDeAplicacao)
        {
            _reuniaoServicoDeAplicacao = reuniaoServicoDeAplicacao;
            _equipeServicoDeAplicacao = equipeServicoDeAplicacao;
            _faturaServicoDeAplicacao = faturaServicoDeAplicacao;
            _servicosContratadosServicoDeAplicacao = servicosContratadosServicoDeAplicacao;
            _treinamentoServicoDeAplicacao = treinamentoServicoDeAplicacao;
            _aprovacaoServicoDeAplicacao = aprovacaoServicoDeAplicacao;
            _solicitacaoServicoDeAplicacao = solicitacaoServicoDeAplicacao;
            _ouvidoriaServicoDeAplicacao = ouvidoriaServicoDeAplicacao;
            _pessoaRepositorio = pessoaRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _equipeRepositorio = equipeRepositorio;
            _faturaRepositorio = faturaRepositorio;
            _reuniaoRepositorio = reuniaoRepositorio;
            _servicosContratadosRepositorio = servicosContratadosRepositorio;
            _treinamentoRepositorio = treinamentoRepositorio;
            _solicitacaoRepositorio = solicitacaoRepositorio;
            _tipoDaSolicitacaoRepositorio = tipoDaSolicitacaoRepositorio;
            _pessoaServicoDeAplicacao = pessoaServicoDeAplicacao;
        }

        public ActionResult Index()
        {
            return View();
        }

        #region APROVACAO-ONLINE

        public ActionResult AprovacaoOnline()
        {
            var aprovacaoOnlineViewModel = new AprovacaoOnlineViewModel();
            aprovacaoOnlineViewModel.Escopos = _aprovacaoServicoDeAplicacao.ObterAprovacoesDoTipo(TipoDaAprovacao.Escopo).Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList().ToViewModel();
            aprovacaoOnlineViewModel.Scripts = _aprovacaoServicoDeAplicacao.ObterAprovacoesDoTipo(TipoDaAprovacao.Script).Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList().ToViewModel();
            aprovacaoOnlineViewModel.Mudancas = _aprovacaoServicoDeAplicacao.ObterAprovacoesDoTipo(TipoDaAprovacao.Mudanca).Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList().ToViewModel();
            aprovacaoOnlineViewModel.Materiais = _aprovacaoServicoDeAplicacao.ObterAprovacoesDoTipo(TipoDaAprovacao.Material).Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList().ToViewModel();
            aprovacaoOnlineViewModel.Internos = _aprovacaoServicoDeAplicacao.ObterAprovacoesDoTipo(TipoDaAprovacao.Interno).Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList().ToViewModel();

            return View(aprovacaoOnlineViewModel);
        }

        public PartialViewResult AddEditAprovacao(TipoDaAprovacao tipo)
        {
            return PartialView(tipo);
        }

        [HttpPost]
        public JsonResult AddEditAprovacao(AprovacaoOnlineViewModel model)
        {
            var requisicao = new AdicionarAprovacaoRequisicao
            {
                Arquivo = model.Arquivo.InputStream,
                Descricao = model.Descricao,
                Tipo = model.Tipo,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                Titulo = model.Titulo,
                CodigoDoGrupoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo,
                NomeDoAnexo = model.Arquivo.FileName
            };
            var resposta = _aprovacaoServicoDeAplicacao.AdicionarAprovacao(requisicao);

            return Json(new { resposta.Erros, resposta.Sucesso, Aprovacao = resposta.Aprovacao.ToViewModel() });
        }

        [HttpPost]
        public JsonResult AprovarDocumento(int codigoDoDocumento, bool aprovado)
        {
            var requisicao = new AprovarDocumentoRequisicao
            {
                Aprovar = aprovado,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                CodigoDaAprovacao = codigoDoDocumento
            };
            var resposta = _aprovacaoServicoDeAplicacao.AprovarDocumento(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Aprovacao = resposta.Aprovacao.ToViewModel() });
        }

        [HttpPost]
        public FileResult BaixarArquivoDaAprovacao(int codigoDaAprovacao)
        {
            var requisicao = new ObterArquivoDaAprovacaoRequisicao
            {
                CodigoDaAprovacao = codigoDaAprovacao
            };
            var resposta = _aprovacaoServicoDeAplicacao.ObterArquiviDaAprovacao(requisicao);
            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Anexo.Nome);
        }

        [HttpPost]
        public JsonResult ExcluirAprovacao(int codigoDaAprovacao)
        {
            var requisicao = new ExcluirAprovacaoRequisicao
            {
                CodigoDaAprovacao = codigoDaAprovacao
            };
            var resposta = _aprovacaoServicoDeAplicacao.ExcluirAprovacao(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros, CodigoDaAprovacao = codigoDaAprovacao });
        }
        #endregion

        #region OUVIDORIA
        public ActionResult Ouvidoria()
        {
            return View();
        }

        public JsonResult NovaOuvidoria(string assunto, string mensagem)
        {
            var requisicao = new AdicionarOuvidoriaRequisicao { Assunto = assunto, Mensagem = mensagem };
            var resposta = _ouvidoriaServicoDeAplicacao.AdicionarOuvidoria(requisicao);
            return Json(resposta);
        }
        #endregion

        #region TREINAMENTO
        public ActionResult Treinamentos()
        {
            var treinamentos = _treinamentoRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View(treinamentos);
        }

        public PartialViewResult AddEditTreinamento(int? codigo)
        {
            var viewModel = new AdicionarTreinamentoViewModel
            {
                Funcionarios = _funcionarioRepositorio.ObterTodos().ToViewModel()
            };
            if (codigo != null)
            {
                var treinamento = _treinamentoRepositorio.ObterPor(codigo.Value);
                viewModel.Codigo = treinamento.Codigo;
                viewModel.DataRealizacao = treinamento.DataRealizacao;
                viewModel.CodigoDoResponsavel = treinamento.Responsavel.Codigo;
                viewModel.Local = treinamento.Local;
                viewModel.Titulo = treinamento.Titulo;
                viewModel.Descricao = treinamento.Descricao;
            }
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult AddEditTreinamento(AdicionarTreinamentoViewModel viewModel)
        {
            if (viewModel.Codigo > 0)
            {
                var resposta = AlterarTreinamento(viewModel);
                return
                    Json(new { resposta.Sucesso, resposta.Erros, Treinamento = resposta.Treinamento.ToViewModel() });
            }
            else
            {
                var resposta = IncluirTreinamento(viewModel);
                return
                    Json(new
                    {
                        resposta.Sucesso,
                        resposta.Erros,
                        Treinamento = resposta.Treinamento.ToViewModel()
                    });
            }
        }

        private AdicionarTreinamentoResposta IncluirTreinamento(AdicionarTreinamentoViewModel viewModel)
        {
            var requisicao = new AdicionarTreinamentoRequisicao
            {
                DataRealizacao = viewModel.DataRealizacao,
                CodigoDoResponsavel = viewModel.CodigoDoResponsavel,
                Local = viewModel.Local,
                Titulo = viewModel.Titulo,
                Descricao = viewModel.Descricao,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo
            };
            var resposta = _treinamentoServicoDeAplicacao.AdicionarTreinamento(requisicao);
            return resposta;
        }

        private AlterarTreinamentoResposta AlterarTreinamento(AdicionarTreinamentoViewModel viewModel)
        {
            var requisicao = new AlterarTreinamentoRequisicao
                                 {
                                     DataRealizacao = viewModel.DataRealizacao,
                                     CodigoDoResponsavel = viewModel.CodigoDoResponsavel,
                                     Local = viewModel.Local,
                                     Titulo = viewModel.Titulo,
                                     Descricao = viewModel.Descricao,
                                     CodigoDoTreinamento = viewModel.Codigo
                                 };
            var resposta = _treinamentoServicoDeAplicacao.AlterarTreinamento(requisicao);
            return resposta;
        }

        [HttpPost]
        public JsonResult ExcluirTreinamento(int codigo)
        {
            var requisicao = new ExcluirTreinamentoRequisicao
                                 {
                                     CodigoDoTreinamento = codigo
                                 };

            var respota = _treinamentoServicoDeAplicacao.ExcluirTreinamento(requisicao);

            return Json(respota);
        }

        public PartialViewResult AddEditParticipantesTreinamento(int codigoDoTreinamento)
        {
            var viewModel = new AdicionarParticipantesTreinamentoViewModel();
            var treinamento = _treinamentoRepositorio.ObterPor(codigoDoTreinamento);
            viewModel.CodigoDoTreinamento = codigoDoTreinamento;
            viewModel.Pessoas =
                _pessoaRepositorio.ObterTodosQueNaoEstejaNoTreinamento(treinamento).ToViewModel();
            viewModel.Participantes = treinamento.Participantes.ToViewModel();
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult AddEditParticipantesTreinamento(List<int> codigosDosParticipantes, int codigoDoTreinamento)
        {
            var requisicao = new AdicionarParticipantesNoTreinamentoRequisicao
            {
                CodigoDoTreinamento = codigoDoTreinamento,
                CodigosDosParticipantes = codigosDosParticipantes ?? new List<int>()
            };
            var resposta = _treinamentoServicoDeAplicacao.AdicionarParticipantesNoTreinamento(requisicao);
            return Json(resposta);
        }

        public PartialViewResult AddEditAnexoTreinamento(int codigoDoTreinamento)
        {
            var treinamento = _treinamentoRepositorio.ObterPor(codigoDoTreinamento);
            var viewModel = new AdicionarAnexoTreinamentoViewModel
            {
                Anexos = treinamento.Anexos,
                CodigoDoTreinamento = codigoDoTreinamento
            };
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult AddEditAnexoTreinamento(HttpPostedFileBase arquivo, string descricao, int codigoDoTreinamento)
        {
            var requisicao = new AdicionarAnexoEmTreinamentoRequisicao
            {
                CodigoDoTreinamento = codigoDoTreinamento,
                Descricao = descricao,
                Arquivo = arquivo.InputStream,
                Nome = arquivo.FileName
            };
            var resposta = _treinamentoServicoDeAplicacao.AdicionarAnexoEmTreinamento(requisicao);
            return Json(resposta);
        }

        [HttpPost]
        public FileResult BaixarArquivoTreinamento(int codigoDoTreinamento, int codigoDoAnexo)
        {
            var requisicao = new ObterAnexoDoTreinamentoRequisicao
            {
                CodigoDoTreinamento = codigoDoTreinamento,
                CodigoDoAnexo = codigoDoAnexo
            };
            var resposta = _treinamentoServicoDeAplicacao.ObterAnexoDoTreinamento(requisicao);

            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Anexo.Nome);
        }

        [HttpPost]
        public JsonResult ExcluirAnexoTreinamento(int codigoDoTreinamento, int codigoDoAnexo)
        {
            var requisicao = new ExcluirAnexoDoTreinamentoRequisicao
            {
                CodigoDoTreinamento = codigoDoTreinamento,
                CodigoDoAnexo = codigoDoAnexo
            };
            var resposta = _treinamentoServicoDeAplicacao.ExcluirAnexoDoTreinamento(requisicao);

            return Json(resposta);
        }

        #endregion

        #region EQUIPE

        public ActionResult Equipe()
        {
            var equipe = _equipeRepositorio.ObterPor(Session.ProgramaAtivo()) ?? new Equipe(Session.ProgramaAtivo());
            return View(equipe.ToViewModel());
        }

        public PartialViewResult AddEditMembro()
        {
            var equipe = _equipeRepositorio.ObterPor(Session.ProgramaAtivo());
            var funcionarios = _funcionarioRepositorio.ObterTodosQueNaoEstaoNaEquipe(equipe);
            var adicionarMembrosNaEquipeViewModel = new AdicionarMembrosEquipeViewModel
                                                        {
                                                            Funcionarios = funcionarios.ToViewModel(),
                                                            Membros =
                                                                equipe.MenbrosDaEquipe.ToViewModel(),
                                                            CodigoDaEquipe = equipe.Codigo
                                                        };
            return PartialView(adicionarMembrosNaEquipeViewModel);
        }

        [HttpPost]
        public JsonResult AddEditMembro(List<int> codigosDosMembros, int codigoDaEquipe)
        {
            var requisicao = new AdicionarMembrosNaEquipeRequisicao
                                 {
                                     CodigoDaEquipe = codigoDaEquipe,
                                     CodigosDosFuncionarios = codigosDosMembros ?? new List<int>()
                                 };
            var resposta = _equipeServicoDeAplicacao.AdicionarMembrosNaEquipe(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros, Equipe = resposta.Equipe.ToViewModel() });
        }

        #endregion

        #region FATURAMENTO

        public ActionResult Faturamento()
        {
            var faturas = _faturaRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View(faturas);
        }

        public PartialViewResult AddEditFatura(int? codigo)
        {
            var statusDaFatura = typeof(StatusDaFatura).ToViewModel();
            var tiposDaFatura = typeof(TipoDaFatura).ToViewModel();
            var tiposDoDocumento = typeof(TipoDeDocumento).ToViewModel();
            var viewModel = new AdicionarFaturaViewModel
                                {
                                    StatusDaFatura = statusDaFatura,
                                    TiposDaFatura = tiposDaFatura,
                                    TiposDoDocumento = tiposDoDocumento,
                                };
            if (codigo != null)
            {
                var fatura = _faturaRepositorio.ObterPor(codigo.Value);
                viewModel.Tipo = fatura.Tipo;
                viewModel.Codigo = fatura.Codigo;
                viewModel.Statu = fatura.Status;
                viewModel.Valor = fatura.Valor;
                viewModel.Data = fatura.Data;
                viewModel.Descricao = fatura.Descricao;
                viewModel.NumeroDoDocumento = fatura.NumeroDoDocumento;
                viewModel.TipoDoDocumento = fatura.Documento;
            }
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult AddEditFatura(AdicionarFaturaViewModel novaFaturaViewModel)
        {
            if (novaFaturaViewModel.Codigo > 0)
            {
                var resposta = AlterarFatura(novaFaturaViewModel);
                return Json(new { resposta.Sucesso, resposta.Erros, Fatura = resposta.Fatura.ToViewModel() });
            }
            else
            {
                var resposta = IncluirFatura(novaFaturaViewModel);
                return Json(new { resposta.Sucesso, resposta.Erros, Fatura = resposta.Fatura.ToViewModel() });
            }
        }

        private AlterarFaturaResposta AlterarFatura(AdicionarFaturaViewModel novaFaturaViewModel)
        {
            var requisicao = new AlterarFaturaRequisicao
                                 {
                                     Data = novaFaturaViewModel.Data,
                                     Descricao = novaFaturaViewModel.Descricao,
                                     NumeroDoDocumento = novaFaturaViewModel.NumeroDoDocumento,
                                     Tipo = novaFaturaViewModel.Tipo,
                                     Status = novaFaturaViewModel.Statu,
                                     TipoDoDocumento = novaFaturaViewModel.TipoDoDocumento,
                                     Valor = novaFaturaViewModel.Valor,
                                     CodigoDaFatura = novaFaturaViewModel.Codigo
                                 };
            var resposta = _faturaServicoDeAplicacao.AlterarFatura(requisicao);
            return resposta;
        }

        private AdicionarFaturaResposta IncluirFatura(AdicionarFaturaViewModel novaFaturaViewModel)
        {
            var requisicao = new AdicionarFaturaRequisicao
                                 {
                                     Data = novaFaturaViewModel.Data,
                                     Descricao = novaFaturaViewModel.Descricao,
                                     NumeroDoDocumento = novaFaturaViewModel.NumeroDoDocumento,
                                     Tipo = novaFaturaViewModel.Tipo,
                                     Status = novaFaturaViewModel.Statu,
                                     TipoDoDocumento = novaFaturaViewModel.TipoDoDocumento,
                                     Valor = novaFaturaViewModel.Valor,
                                     CodigoDoPrograma = Session.ProgramaAtivo().Codigo
                                 };
            var resposta = _faturaServicoDeAplicacao.AdicionarFatura(requisicao);
            return resposta;
        }

        [HttpPost]
        public JsonResult ExcluirFatura(int codigo)
        {
            var requisicao = new ExcluirFaturaRequisicao
                                 {
                                     CodigoDaFatura = codigo
                                 };

            var respota = _faturaServicoDeAplicacao.ExcluirFatura(requisicao);

            return Json(respota);
        }

        #endregion

        #region SERVICOS_CONTRATADOS

        public ActionResult ServicosContratados()
        {
            var servicosContratados =
                _servicosContratadosRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View(servicosContratados);
        }

        public PartialViewResult AddEditServicoContratado(int? codigo)
        {
            var viewModel = new AdicionarServicoContratoViewModel();
            if (codigo != null)
            {
                var servicoContratado = _servicosContratadosRepositorio.ObterPor(codigo.Value);
                viewModel.Codigo = servicoContratado.Codigo;
                viewModel.Nome = servicoContratado.Nome;
                viewModel.Descricao = servicoContratado.Descricao;
                viewModel.Quantidade = servicoContratado.Quantidade;
                viewModel.Observacoes = servicoContratado.Observacoes;
                viewModel.DataContratacao = servicoContratado.DataContratacao;
            }
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult AddEditServicoContratado(AdicionarServicoContratoViewModel novoServicoContratoViewModel)
        {
            if (novoServicoContratoViewModel.Codigo > 0)
            {
                var resposta = AlterarServicosContratados(novoServicoContratoViewModel);
                return Json(new { resposta.Sucesso, resposta.Erros, ServicosContratados = resposta.ServicosContratados.ToViewModel() });
            }
            else
            {
                var resposta = IncluirServicosContratados(novoServicoContratoViewModel);
                return Json(new { resposta.Sucesso, resposta.Erros, ServicosContratados = resposta.ServicosContratados.ToViewModel() });
            }
        }

        private AlterarServicosContratadosResposta AlterarServicosContratados(
            AdicionarServicoContratoViewModel novoServicoContratoViewModel)
        {
            var requisicao = new AlterarServicosContratadosRequisicao
                                 {
                                     Nome = novoServicoContratoViewModel.Nome,
                                     Descricao = novoServicoContratoViewModel.Descricao,
                                     Quantidade = novoServicoContratoViewModel.Quantidade,
                                     Observacoes = novoServicoContratoViewModel.Observacoes,
                                     DataContratacao = novoServicoContratoViewModel.DataContratacao,
                                     CodigoSevicoContratado = novoServicoContratoViewModel.Codigo
                                 };
            var resposta = _servicosContratadosServicoDeAplicacao.AlterarServicosContratados(requisicao);
            return resposta;
        }

        private AdicionarServicosContratadosResposta IncluirServicosContratados(
            AdicionarServicoContratoViewModel novoServicoContratoViewModel)
        {
            var requisicao = new AdicionarServicosContratadosRequisicao
                                 {
                                     Nome = novoServicoContratoViewModel.Nome,
                                     Descricao = novoServicoContratoViewModel.Descricao,
                                     Quantidade = novoServicoContratoViewModel.Quantidade,
                                     Observacoes = novoServicoContratoViewModel.Observacoes,
                                     DataContratacao = novoServicoContratoViewModel.DataContratacao,
                                     CodigoDoPrograma = Session.ProgramaAtivo().Codigo
                                 };
            var resposta = _servicosContratadosServicoDeAplicacao.AdicionarServicosContratados(requisicao);
            return resposta;
        }

        [HttpPost]
        public JsonResult ExcluirServicoContratado(int codigo)
        {
            var requisicao = new ExcluirServicosContratadosRequisicao
                                 {
                                     CodigoServicoContratado = codigo
                                 };

            var respota = _servicosContratadosServicoDeAplicacao.ExcluirServicosContratados(requisicao);

            return Json(respota);
        }

        #endregion

        #region REUNIAO
        public ActionResult Reunioes()
        {
            var reunioes = _reuniaoRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View(reunioes);
        }

        public PartialViewResult AddEditReuniao(int? id)
        {
            var adicionarReuniaoViewModel = new AdicionarReuniaoViewModel();
            adicionarReuniaoViewModel.Funcionarios = _funcionarioRepositorio.ObterTodos().ToViewModel();
            adicionarReuniaoViewModel.ListaDeStatus = typeof(StatusDaReunicao).ToViewModel();
            if (id != null)
            {
                var reuniao = _reuniaoRepositorio.ObterPor(id.Value);
                adicionarReuniaoViewModel.Codigo = reuniao.Codigo;
                adicionarReuniaoViewModel.CodigoDoResponsavel = reuniao.Responsavel.Codigo;
                adicionarReuniaoViewModel.Local = reuniao.Local;
                adicionarReuniaoViewModel.Realizacao = reuniao.Realizacao;
                adicionarReuniaoViewModel.Assunto = reuniao.Assunto;
                adicionarReuniaoViewModel.Status = reuniao.Status;
            }
            return PartialView(adicionarReuniaoViewModel);
        }

        [HttpPost]
        public JsonResult AddEditReuniao(AdicionarReuniaoViewModel adicionarReuniaoViewModel)
        {
            if (adicionarReuniaoViewModel.Codigo > 0)
            {
                var resposta = AlterarReuniao(adicionarReuniaoViewModel);
                return Json(new { resposta.Erros, resposta.Sucesso, Reuniao = resposta.Reuniao.ToViewModel() });
            }
            else
            {
                var resposta = AdicionarReuniao(adicionarReuniaoViewModel);
                return Json(new { resposta.Erros, resposta.Sucesso, Reuniao = resposta.Reuniao.ToViewModel() });
            }
        }

        private AlterarReuniaoReposta AlterarReuniao(AdicionarReuniaoViewModel adicionarReuniaoViewModel)
        {
            var requisicao = new AlterarReuniaoRequisicao
            {
                CodigoDaReuniao = adicionarReuniaoViewModel.Codigo,
                CodigoDoResponsavel = adicionarReuniaoViewModel.CodigoDoResponsavel,
                Local = adicionarReuniaoViewModel.Local,
                Realizacao = adicionarReuniaoViewModel.Realizacao,
                Assunto = adicionarReuniaoViewModel.Assunto,
                Status = adicionarReuniaoViewModel.Status
            };
            return _reuniaoServicoDeAplicacao.AlterarReuniao(requisicao);
        }

        private AdicionarReuniaoResposta AdicionarReuniao(AdicionarReuniaoViewModel adicionarReuniaoViewModel)
        {
            var requisicao = new AdicionarReuniaoRequisicao
                                 {
                                     CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                                     CodigoDoResponsavel = adicionarReuniaoViewModel.CodigoDoResponsavel,
                                     Local = adicionarReuniaoViewModel.Local,
                                     Realizacao = adicionarReuniaoViewModel.Realizacao,
                                     Assunto = adicionarReuniaoViewModel.Assunto,
                                     Status = adicionarReuniaoViewModel.Status
                                 };
            return _reuniaoServicoDeAplicacao.AdicionarReuniao(requisicao);
        }


        public PartialViewResult AddEditParticipantesReuniao(int codigoDaReuniao)
        {
            var adicionarParticipantesNaReuniaoViewModel = new AdicionarParticipantesReuniaoViewModel();
            var reuniao = _reuniaoRepositorio.ObterPor(codigoDaReuniao);
            adicionarParticipantesNaReuniaoViewModel.CodigoDaReuniao = codigoDaReuniao;
            adicionarParticipantesNaReuniaoViewModel.Pessoas = _pessoaRepositorio.ObterTodosQueNaoEstejaNaReuniao(reuniao).ToViewModel();
            adicionarParticipantesNaReuniaoViewModel.Participantes = reuniao.Participantes.ToViewModel();
            return PartialView(adicionarParticipantesNaReuniaoViewModel);
        }

        [HttpPost]
        public JsonResult AdicionarParticipantesNaReuniao(List<int> codigosDosParticipantes, int codigoDaReuniao)
        {
            var requisicao = new AdicionarParticipantesNaReuniaoRequisicao
                                 {
                                     CodigoDaReuniao = codigoDaReuniao,
                                     CodigosDosParticipantes = codigosDosParticipantes ?? new List<int>()
                                 };
            var resposta = _reuniaoServicoDeAplicacao.AdicionarParticipantesNaReuniao(requisicao);
            return Json(resposta);
        }

        [HttpPost]
        public JsonResult ExcluirReuniao(int codigo)
        {
            var requisicao = new ExcluirReuniaoRequisicao { CodigoDaReuniao = codigo };

            var respota = _reuniaoServicoDeAplicacao.ExcluirReuniao(requisicao);

            return Json(respota);
        }

        [HttpPost]
        public JsonResult AddEditAnexoReuniao(AdicionarAnexoReuniaoViewModel addEditAnexoReuniaoViewModel)
        {
            var requisicao = new AdicionarAnexoEmUmareuniaoRequisicao
            {
                CodigoDaReuniao = addEditAnexoReuniaoViewModel.CodigoDaReuniao,
                Descricao = addEditAnexoReuniaoViewModel.Descricao,
                Arquivo = addEditAnexoReuniaoViewModel.Arquivo.InputStream,
                Nome = addEditAnexoReuniaoViewModel.Arquivo.FileName
            };

            var resposta = _reuniaoServicoDeAplicacao.AdicionarAnexoEmUmaReuniao(requisicao);

            return Json(resposta);
        }

        [HttpPost]
        public FileResult BaixarArquivo(int codigoDaReuniao, int codigoDoAnexo)
        {
            var requisicao = new ObterAnexoDaReuniaoRequisicao
            {
                CodigoDaReuniao = codigoDaReuniao,
                CodigoDoAnexo = codigoDoAnexo
            };
            var resposta = _reuniaoServicoDeAplicacao.ObterAnexoDaReuniao(requisicao);

            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Anexo.Nome);
        }

        public PartialViewResult AddEditAnexoReuniao(int codigoDaReuniao)
        {
            var reuniao = _reuniaoRepositorio.ObterPor(codigoDaReuniao);
            var adicionarAnexoViewModel = new AdicionarAnexoReuniaoViewModel
            {
                Anexos = reuniao.Anexos,
                CodigoDaReuniao = codigoDaReuniao
            };
            return PartialView(adicionarAnexoViewModel);
        }

        [HttpPost]
        public JsonResult ExcluirAnexoReuniao(int codigoDoAnexo, int codigoDaReuniao)
        {
            var requisicao = new ExcluirAnexoDaReuniaoRequisicao
            {
                CodigoDaReuniao = codigoDaReuniao,
                CodigoDoAnexo = codigoDoAnexo
            };
            var resposta = _reuniaoServicoDeAplicacao.ExcluirAnexoDaReuniao(requisicao);

            return Json(resposta);
        }
        #endregion

        #region ATA
        public ActionResult Atas(int codigoDaReuniao)
        {
            var reuniao = _reuniaoRepositorio.ObterPor(codigoDaReuniao);
            var atasViewModel = new AtasViewModel
                                    {
                                        Atas = reuniao.Atas.ToViewModel(),
                                        CodigoDaReuniao = reuniao.Codigo,
                                    };
            return View(atasViewModel);
        }

        public PartialViewResult AddEditAta(int codigoDaReuniao, int? codigoDaAta)
        {
            AdicionarAtaViewModel novaAtaViewModel;
            if (codigoDaAta.HasValue)
            {
                novaAtaViewModel = new AdicionarAtaViewModel
                {
                    Funcionarios = _funcionarioRepositorio.ObterTodos().ToViewModel(),
                    ListaDeStatusDaAta = typeof(StatusDaAta).ToViewModel(),
                    CodigoDaReuniao = codigoDaReuniao,
                    Ata = _reuniaoRepositorio.ObterAtaDaReuniao(codigoDaReuniao, codigoDaAta.Value).ToViewModel()
                };
            }
            else
            {
                novaAtaViewModel = new AdicionarAtaViewModel
                                           {
                                               Funcionarios = _funcionarioRepositorio.ObterTodos().ToViewModel(),
                                               ListaDeStatusDaAta = typeof(StatusDaAta).ToViewModel(),
                                               CodigoDaReuniao = codigoDaReuniao
                                           };
            }
            return PartialView(novaAtaViewModel);
        }

        [HttpPost]
        public ActionResult SalvarNovaAta(AdicionarAtaViewModel novaAtaViewModel)
        {
            if (novaAtaViewModel.Codigo > 0)
            {
                var requisicao = new AlterarAtaEmUmaReuniaoRequisicao
                {
                    CodigoDaAta = novaAtaViewModel.Codigo,
                    Anotacoes = novaAtaViewModel.Anotacoes,
                    Assunto = novaAtaViewModel.Assunto,
                    CodigoDaReuniao = novaAtaViewModel.CodigoDaReuniao,
                    CodigoDoResponsavel = novaAtaViewModel.CodigoDoResponsavel,
                    FinalDoPrazo = novaAtaViewModel.FinalDoPrazo,
                    InicioDoPrazo = novaAtaViewModel.InicioDoPrazo,
                    Status = novaAtaViewModel.Status
                };
                var resposta = _reuniaoServicoDeAplicacao.AlterarAtaEmUmaReuniao(requisicao);
                return Json(new { resposta.Sucesso, resposta.Erros, Ata = resposta.Ata.ToViewModel() });
            }
            else
            {

                var requisicao = new AdicionarAtaEmUmaReuniaoRequisicao
                                     {
                                         Anotacoes = novaAtaViewModel.Anotacoes,
                                         Assunto = novaAtaViewModel.Assunto,
                                         CodigoDaReuniao = novaAtaViewModel.CodigoDaReuniao,
                                         CodigoDoResponsavel = novaAtaViewModel.CodigoDoResponsavel,
                                         FinalDoPrazo = novaAtaViewModel.FinalDoPrazo,
                                         InicioDoPrazo = novaAtaViewModel.InicioDoPrazo,
                                         Status = novaAtaViewModel.Status
                                     };
                var resposta = _reuniaoServicoDeAplicacao.AdicionarAtaEmUmaReuniao(requisicao);
                return Json(new { resposta.Sucesso, resposta.Erros, Ata = resposta.Ata.ToViewModel() });
            }
        }

        [HttpPost]
        public JsonResult AddEditAnexoAta(AdicionarAnexoAtaViewModel adicionarAnexoEmUmaAtaRequisicao)
        {
            var requisicao = new AdicionarAnexoEmUmaAtaRequisicao
                                 {
                                     Descricao = adicionarAnexoEmUmaAtaRequisicao.Descricao,
                                     Arquivo = adicionarAnexoEmUmaAtaRequisicao.Arquivo.InputStream,
                                     NomeDoArquivo = adicionarAnexoEmUmaAtaRequisicao.Arquivo.FileName,
                                     CodigoDaReuniao = adicionarAnexoEmUmaAtaRequisicao.CodigoDaReuniao,
                                     CodigoDaAta = adicionarAnexoEmUmaAtaRequisicao.CodigoDaAta
                                 };

            var resposta = _reuniaoServicoDeAplicacao.AdicionarAnexoEmUmaAta(requisicao);

            return Json(resposta);
        }


        public PartialViewResult AddEditAnexoAta(int codigoDaReuniao, int codigoDaAta)
        {
            var ata = _reuniaoRepositorio.ObterAtaDaReuniao(codigoDaReuniao, codigoDaAta);
            var adicionarAnexoEmUmaAtaViewModel = new AdicionarAnexoAtaViewModel
                                                      {
                                                          Anexos = ata.Anexos,
                                                          CodigoDaReuniao = codigoDaReuniao,
                                                          CodigoDaAta = codigoDaAta
                                                      };
            return PartialView(adicionarAnexoEmUmaAtaViewModel);
        }

        [HttpPost]
        public FileResult BaixarAnexoDeUmaAta(int codigoDaReuniao, int codigoDaAta, int codigoDoAnexo)
        {
            var requisicao = new ObterAnexoDeUmaAtaRequisicao
            {
                CodigoDaReuniao = codigoDaReuniao,
                CodigoDaAta = codigoDaAta,
                CodigoDoAnexo = codigoDoAnexo
            };

            var resposta = _reuniaoServicoDeAplicacao.ObterAnexoDeUmaAta(requisicao);
            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Anexo.Nome);
        }

        public JsonResult ExcluirAnexoDeUmaAta(int codigoDaReuniao, int codigoDaAta, int codigoDoAnexo)
        {
            var requisicao = new ExcluirAnexoDeUmaAtaRequisicao
            {
                CodigoDaReuniao = codigoDaReuniao,
                CodigoDaAta = codigoDaAta,
                CodigoDoAnexo = codigoDoAnexo
            };

            var resposta = _reuniaoServicoDeAplicacao.ExcluirAnexoDeUmaAta(requisicao);
            return Json(resposta);
        }

        [HttpPost]
        public JsonResult ExcluirAta(int codigoDaReuniao, int codigoDaAta)
        {
            var requisicao = new ExcluirAtaDaReuniaoRequisicao
            {
                CodigoDaAta = codigoDaAta,
                CodigoDaReuniao = codigoDaReuniao
            };
            var resposta = _reuniaoServicoDeAplicacao.ExcluirAtaDaReuniao(requisicao);
            return Json(resposta);
        }
        #endregion

        #region CHAMADOS
        public ActionResult ChamadosOnline()
        {
            //var solicitacoes = _solicitacaoRepositorio.ObterTodos().ToViewModel();
            var solicitacoes = _solicitacaoRepositorio.ObterTodos().ToViewModel();
            return View(solicitacoes.Where(x => x.Programa.CodPrograma == Session.ProgramaAtivo().CodPrograma).ToList());
        }

        [HttpPost]
        public JsonResult AddSolicitacao(NovaSolicitacaoViewModel novaSolicitacaoViewModel)
        {
            var requisicao = new AbrirUmaSolicitacaoRequisicao
            {
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                CodigoDoTipoDaSolicitacao = novaSolicitacaoViewModel.CodigoDoTipoDaSolicitacao,
                Descricao = novaSolicitacaoViewModel.Solicitacao,
                Protocolo = novaSolicitacaoViewModel.Protocolo,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo
            };
            var resposta = _solicitacaoServicoDeAplicacao.AbrirUmaSolicitacao(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros, Solicitacao = resposta.Solicitacao.ToViewModel() });
        }

        public PartialViewResult AddSolicitacao()
        {
            var resposta = _solicitacaoServicoDeAplicacao.ObterUmProtocolo(new ObterUmProtocoloRequisicao());
            var novaSolicitacao = new NovaSolicitacaoViewModel
            {
                Tipos = _tipoDaSolicitacaoRepositorio.ObterTodos(),
                Solicitacao = string.Empty,
                Protocolo = resposta.Protocolo,
                DataDaSolicitacao = DateTime.Now
            };

            return PartialView(novaSolicitacao);
        }

        public PartialViewResult VisualizarSolicitacao(int id)
        {
            var solicitacao = _solicitacaoRepositorio.ObterPor(id);
            switch (solicitacao.Situacao)
            {
                case SituacaoDaSolicitacao.Analise:
                    return PartialView("VisualizarSolicitacaoAnalise", solicitacao.ToViewModel());
                case SituacaoDaSolicitacao.Aprovacao:
                    return PartialView("VisualizarSolicitacaoAprovacao", solicitacao.ToViewModel());
                case SituacaoDaSolicitacao.Processo:
                    return PartialView("VisualizarSolicitacaoProcesso", solicitacao.ToViewModel());
                case SituacaoDaSolicitacao.Entregue:
                    return PartialView("VisualizarSolicitacaoEntregue", solicitacao.ToViewModel());
                default:
                    return PartialView("VisualizarSolicitacaoFinalizada", solicitacao.ToViewModel());
            }
        }

        [HttpPost]
        public JsonResult SalvarAnaliseDeSolicitacao(AnaliseDeSolicitacaoViewModel viewModel)
        {
            var requisicao = new RealizarAnalizeDeUmaSolicitacaoRequisicao
            {
                Atividade = viewModel.Atividade,
                ClientePrecisaAprovar = viewModel.AprovacaoDoCliente,
                Custo = viewModel.Custo,
                DiasParaEntrega = viewModel.DiasParaEntrega,
                CodigoDaSolicitacao = viewModel.Codigo,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                Analise = viewModel.Analise,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo
            };
            var resposta = _solicitacaoServicoDeAplicacao.RealizarAnalizeDeUmaSolicitacao(requisicao);
            return Json(new { resposta.Sucesso, resposta.Erros, Solicitacao = resposta.Solicitacao != null ? resposta.Solicitacao.ToViewModel() : null });
        }

        public JsonResult SalvarAprovacaoDeSolicitacao(AprovacaoDeSolicitacaoViewModel viewModel)
        {
            var requisicao = new RealizarAprovacaoDeUmaSolicitacaoRequisicao
            {
                Aprovado = viewModel.Aprovado,
                Observacoes = viewModel.Observacao,
                CodigoDaSolicitacao = viewModel.Codigo,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                CodigoDoPrograma = Session.ProgramaAtivo().CodPrograma
            };
            var resposta = _solicitacaoServicoDeAplicacao.RealizarAprovacaoDeUmaSolicitacao(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Solicitacao = resposta.Solicitacao != null ? resposta.Solicitacao.ToViewModel() : null });
        }

        public JsonResult SalvarProcessoDeSolicitacao(ProcessoDeSolicitacaoViewModel viewModel)
        {
            var requisicao = new RealizarProcessoDeUmaSolicitacaoRequisicao
            {
                Observacoes = viewModel.Observacao,
                CodigoDaSolicitacao = viewModel.Codigo,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                Solucao = viewModel.Solucao,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo
            };
            var resposta = _solicitacaoServicoDeAplicacao.RealizarProcessoDeUmaSolicitacao(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Solicitacao = resposta.Solicitacao != null ? resposta.Solicitacao.ToViewModel() : null });
        }

        public JsonResult SalvarEntregaDeSolicitacao(EntregaDaSolicitacaoViewModel viewModel)
        {
            var requisicao = new RealizarEntregaDeUmaSolicitacaoRequisicao
            {
                Observacoes = viewModel.Observacao,
                CodigoDaSolicitacao = viewModel.Codigo,
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                Aceita = viewModel.Aceita,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo
            };

            var resposta = _solicitacaoServicoDeAplicacao.RealizarEntregaDeUmaSolicitacao(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Solicitacao = resposta.Solicitacao != null ? resposta.Solicitacao.ToViewModel() : null });
        }

        public PartialViewResult ResumoSolicitacao(int id)
        {
            var solicitacao = _solicitacaoRepositorio.ObterPor(id);
            return PartialView(solicitacao);
        }

        [HttpPost]
        public JsonResult ExcluirSolicitacao(int codigo)
        {
            var requisicao = new ExcluirSolicitacaoRequisicao
            {
                CodigoDaSolicitacao = codigo
            };

            var respota = _solicitacaoServicoDeAplicacao.ExcluirSolicitacao(requisicao);

            return Json(respota);
        }
        #endregion

        public ActionResult Foto(int id)
        {
            var requisicao = new ObterFotoRequisicao
            {
                CodigoDaPessoa = id
            };
            var resposta = _pessoaServicoDeAplicacao.ObterFoto(requisicao);
            if (resposta.Sucesso)
                return File(resposta.Foto, "image/jpg");

            var convert = new ImageConverter();
            var img = convert.ConvertTo(Properties.Resources.ico_nophoto, typeof(byte[]));
            Stream stream = new MemoryStream(img as byte[]);
            return File(stream, "image/jpg");
        }
    }
}




