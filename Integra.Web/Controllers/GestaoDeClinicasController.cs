using Integra.Dominio;
using Integra.Dominio.Repositorios;
using Integra.ServicosDeAplicacao;
using Integra.ServicosDeAplicacao.Mensagens;
using Integra.ServicosDeAplicacao.Mensagens.Clinica;
using Integra.ServicosDeAplicacao.Mensagens.Faturamento;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.integraEssencial;
using Integra.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "GestaoDeClinicas")]
    public class GestaoDeClinicasController : BaseController
    {
        private readonly ClinicaServicoDeAplicacao _clinicaServicoDeAplicacao;
        private readonly FaturamentoServicoDeAplicacao _faturamentoServicoDeAplicacao;
        private readonly IClinicaRepositorio _clinicaRepositorio;
        private readonly IGerenteRepositorio _gerenteRepositorio;
        private readonly IInfusaoRepositorio _infusaoRepositorio;
        private readonly INotaFiscalRepositorio _notaFiscalRepositorio;
        private readonly IRepresentanteRepositorio _representanteRepositorio;
        private readonly IRepresentanteRegionalRepositorio _representanteRegionalRepositorio;
        private readonly IClinicaDocumentoRepositorio _clinicaDocumentoRepositorio;

        public GestaoDeClinicasController(ClinicaServicoDeAplicacao clinicaServicoDeAplicacao, FaturamentoServicoDeAplicacao faturamentoServicoDeAplicacao,
            IClinicaRepositorio clinicaRepositorio, IGerenteRepositorio gerenteRepositorio, IInfusaoRepositorio infusaoRepositorio, INotaFiscalRepositorio notaFiscalRepositorio,
            IRepresentanteRepositorio representanteRepositorio, IRepresentanteRegionalRepositorio representanteRegionalRepositorio, IClinicaDocumentoRepositorio clinicaDocumentoRepositorio)
        {
            _clinicaServicoDeAplicacao = clinicaServicoDeAplicacao;
            _faturamentoServicoDeAplicacao = faturamentoServicoDeAplicacao;
            _clinicaRepositorio = clinicaRepositorio;
            _gerenteRepositorio = gerenteRepositorio;
            _infusaoRepositorio = infusaoRepositorio;
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _representanteRepositorio = representanteRepositorio;
            _representanteRegionalRepositorio = representanteRegionalRepositorio;
            _clinicaDocumentoRepositorio = clinicaDocumentoRepositorio;

        }

        public ActionResult Index()
        {
            return View();
        }

        #region CLINICA
        [HttpPost]
        public JsonResult AlterarForcaDeVenda(ViewModelAlterarForcaDeVenda view)
        {
            var requisicao = new AlterarForcaDeVendaRequisicao
            {
                CodigoDaClinica = view.Codigo,
                CodigoDoGerente = view.Gerente,
                CodigoDoRepresentante = view.Representante,
                CodigoDoRepresentanteRegional = view.RepresentanteRegional,
            };
            var resposta = _clinicaServicoDeAplicacao.AlterarForcaDeVenda(requisicao);
            return Json(resposta);
        }

        public PartialViewResult AlterarForcaDeVenda(int id)
        {
            var viewModal = new AdicionarClinicaViewModel
            {
                Gerentes = _gerenteRepositorio.ObterTodos(),
                Representantes = _representanteRepositorio.ObterTodos(),
                RepresentantesRegionais = _representanteRegionalRepositorio.ObterTodos(),
            };

            var clinica = _clinicaRepositorio.ObterPor(id);
            viewModal.Codigo = clinica.Codigo;
            viewModal.CodigoDoRepresentante = clinica.Representante.Codigo;
            viewModal.CodigoDoGerente = clinica.Gerente.Codigo;
            viewModal.CodigoDoRepresentanteRegional = clinica.RepresentanteRegional.Codigo;

            return PartialView("Clinica/AlterarForcaDeVenda", viewModal);

        }

        public PartialViewResult AlterarStatus(int id)
        {
            var clinica = _clinicaRepositorio.ObterPor(id);
            return PartialView("Clinica/AlterarStatus", clinica);
        }

        [HttpPost]
        public JsonResult AlterarStatus(AlterarStatusViewModel view)
        {
            var requisicao = new AlterarStatusRequisicao
                                 {
                                     CodigoDaClinica = view.CodigoDaClinica,
                                     Observacao = view.Observacao,
                                     NovoStatus = view.NovoStatus
                                 };
            var resposta = _clinicaServicoDeAplicacao.AlterarStatus(requisicao);
            return Json(resposta);
        }

        public ActionResult Clinica()
        {
            var clinicas = _clinicaRepositorio.ObterTodos(Session.ProgramaAtivo()).ToViewModel();
            return View("Clinica/Index", clinicas);
        }

        public PartialViewResult AddEditClinica(int? id)
        {
            var viewModal = new AdicionarClinicaViewModel
                                {
                                    Gerentes = _gerenteRepositorio.ObterTodos(),
                                    Representantes = _representanteRepositorio.ObterTodos(),
                                    RepresentantesRegionais = _representanteRegionalRepositorio.ObterTodos(),
                                    ListaDeStatus = typeof(StatusDaClinica).ToViewModel()
                                };
            if (id != null)
            {
                var clinica = _clinicaRepositorio.ObterPor(id.Value);
                viewModal.Codigo = clinica.Codigo;
                viewModal.CodigoDoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo;
                viewModal.Nome = clinica.Nome;
                viewModal.RazaoSocial = clinica.RazaoSocial;
                viewModal.Cnpj = clinica.Cnpj;
                viewModal.InscricaoEstadual = clinica.InscricaoEstadual;
                viewModal.Endereco = clinica.Endereco;
                viewModal.Cidade = clinica.Cidade;
                viewModal.Uf = clinica.Uf;
                viewModal.Telefone = clinica.Telefone;
                viewModal.Contato = clinica.Contato;
                viewModal.CodigoDoRepresentante = clinica.Representante != null ? clinica.Representante.Codigo : 0;
                viewModal.CodigoDoGerente = clinica.Gerente != null ? clinica.Gerente.Codigo : 0;
                viewModal.CodigoDoRepresentanteRegional = clinica.RepresentanteRegional != null ? clinica.RepresentanteRegional.Codigo : 0;
                viewModal.Observacoes = clinica.Observacoes;
                viewModal.Status = clinica.Status;
                viewModal.Email = clinica.Email;
                viewModal.Telefone2 = clinica.Telefone2;
                viewModal.Telefone3 = clinica.Telefone3;
                viewModal.IndicaNovosPacientes = clinica.IndicarNovosPacientes;
                viewModal.ValorInfusao = clinica.ValorDeInfusao;
                viewModal.Bairro = clinica.Bairro;
            }
            return PartialView("Clinica/AddEditClinica", viewModal);
        }

        [HttpPost]
        public JsonResult AddEditClinica(AdicionarClinicaViewModel viewModal)
        {
            if (viewModal.Codigo > 0)
            {
                var clinicaOld = _clinicaRepositorio.ObterPor(viewModal.Codigo).Status; //Recuperando o Status Atual(Antes da mudança) da clinica na base.
                var resposta = AlterarClinica(viewModal);
                if (clinicaOld != StatusDaClinica.Ativo && viewModal.Status == StatusDaClinica.Ativo) //Comparação Se o Status anterior diferente de Ativo e se o novo Status é Igual a Ativo.
                {
                    using (var integraClinicaWs = new IntegraEssencial())
                    {
                        //Se o e-mail não existir na base do site essencial dispara o e-mail, para caso de a clinica ter tido status = Ativo algum dia não disparar o e-mail novamente para cada alteração.
                        if (integraClinicaWs.VerifyUser(resposta.Clinica.Email) == "FALSE")//Novo metodo no service VerifyUser(String email). Verifica se o e-mail existe na base do Essencial, se sim TRUE, se não FALSE.
                        {
                            integraClinicaWs.AddNewUser(resposta.Clinica.Email, "clinica#123", resposta.Clinica.Codigo, resposta.Clinica.Nome); //Envia Um e-mail com a senha.
                        }
                        else
                        {
                            integraClinicaWs.AddNewUserNotify(resposta.Clinica.Email, "clinica#123", resposta.Clinica.Codigo, resposta.Clinica.Nome);
                        }
                    }
                }
                return Json(new { resposta.Erros, resposta.Sucesso, Clinica = resposta.Clinica.ToViewModel() });

            }
            else
            {
                var resposta = AdicionarClinica(viewModal);
                if (resposta.Sucesso)
                {
                    resposta.Clinica.ToViewModel();

                    //Comentei esta rotina, pois o metodo AdicionarClinica já dispara um e-mail, assim estava disparando dois e-mails para o mesmo usuário com senhas diferentes.

                    //new IntegraEssencial().AddNewUser(viewModal.Email, "admin#123", viewModal.Codigo,
                    //                                  viewModal.Nome);
                }
                return Json(new { resposta.Erros, resposta.Sucesso, Clinica = resposta.Clinica.ToViewModel() });
            }
        }

        private AlterarClinicaReposta AlterarClinica(AdicionarClinicaViewModel viewModal)
        {
            var requisicao = new AlterarClinicaRequisicao
            {
                CodigoDaClinica = viewModal.Codigo,
                CodigoDoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo,
                Nome = viewModal.Nome,
                RazaoSocial = viewModal.RazaoSocial,
                Cnpj = viewModal.Cnpj,
                InscricaoEstadual = viewModal.InscricaoEstadual,
                Endereco = viewModal.Endereco,
                Cidade = viewModal.Cidade,
                Uf = viewModal.Uf,
                Telefone = viewModal.Telefone,
                Contato = viewModal.Contato,
                CodigoDoRepresentante = viewModal.CodigoDoRepresentante,
                CodigoDoRepresentanteRegional = viewModal.CodigoDoRepresentanteRegional,
                CodigoDoGerente = viewModal.CodigoDoGerente,
                Observacoes = viewModal.Observacoes,
                Status = viewModal.Status,
                Email = viewModal.Email,
                Telefone2 = viewModal.Telefone2,
                Telefone3 = viewModal.Telefone3,
                IndicaNovosPacientes = viewModal.IndicaNovosPacientes,
                ValorDeInfusao = viewModal.ValorInfusao,
                Bairro = viewModal.Bairro
            };
            return _clinicaServicoDeAplicacao.AlterarClinica(requisicao);
        }

        private AdicionarClinicaResposta AdicionarClinica(AdicionarClinicaViewModel viewModal)
        {
            var requisicao = new AdicionarClinicaRequisicao
            {
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                CodigoDoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo,
                Nome = viewModal.Nome,
                RazaoSocial = viewModal.RazaoSocial,
                Cnpj = viewModal.Cnpj,
                InscricaoEstadual = viewModal.InscricaoEstadual,
                Endereco = viewModal.Endereco,
                Cidade = viewModal.Cidade,
                Uf = viewModal.Uf,
                Telefone = viewModal.Telefone,
                Contato = viewModal.Contato,
                CodigoDoRepresentante = viewModal.CodigoDoRepresentante,
                CodigoDoRepresentanteRegional = viewModal.CodigoDoRepresentanteRegional,
                CodigoDoGerente = viewModal.CodigoDoGerente,
                Observacoes = viewModal.Observacoes,
                Status = viewModal.Status,
                Email = viewModal.Email,
                ValorInfusao = viewModal.ValorInfusao,
                Bairro = viewModal.Bairro
            };

            var resposta = _clinicaServicoDeAplicacao.AdicionarClinica(requisicao);

            if (resposta.Sucesso)
            {
                if (resposta.Clinica.Status == StatusDaClinica.Ativo) //Verifica se o status é igual a true para disparar o e-mail.
                {
                    using (var integraClinicaWs = new IntegraEssencial())
                    {
                        integraClinicaWs.AddNewUser(viewModal.Email, "clinica#123", resposta.Clinica.Codigo,
                                                    resposta.Clinica.Nome);
                    }
                }
            }

            return resposta;
        }

        [HttpPost]
        public JsonResult ExcluirClinica(int codigo)
        {
            var requisicao = new ExcluirClinicaRequisicao { CodigoDaClinica = codigo };

            var respota = _clinicaServicoDeAplicacao.ExcluirClinica(requisicao);

            return Json(respota);
        }

        public PartialViewResult AddEditClinicaDocumentos(int codigoDaClinica)
        {
            var clinica = _clinicaRepositorio.ObterPor(codigoDaClinica);

            var viewModel = new AdicionarClinicaDocumentosViewModel
            {
                CodigoDaClinica = codigoDaClinica,
                Documentos = clinica.Documentos.ToViewModel(),
                ListaDeTipoDocumentoDaClinica = typeof(TipoDocumentoDaClinica).ToViewModel(),
                ListaDeTipoStatusDocumento = typeof(DocumentoStatus).ToViewModel()
            };

            return PartialView("Clinica/AddEditClinicaDocumentos", viewModel);
        }

        [HttpPost]
        public JsonResult AddEditClinicaDocumentos(AdicionarClinicaDocumentosViewModel viewModel)
        {
            var requisicao = new AdicionarDocumentoEmUmaClinicaRequisicao
            {
                CodigoDaClinica = viewModel.CodigoDaClinica,
                CodigoDoResponsavel = User.ToPessoa().Usuario.Perfil.Grupo.Codigo,
                Nome = viewModel.Documento.FileName,
                Descricao = viewModel.Descricao,
                Documento = viewModel.Documento.InputStream,
                TipoDocumento = viewModel.TipoDocumento,
                DataDeVencimento = DateTime.Now,
                StatusDocumento = DocumentoStatus.Ativo
            };

            var resposta = _clinicaServicoDeAplicacao.AdicionarDocumentoEmUmaClinica(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Documento = resposta.Documento.ToViewModel() });
        }

        [HttpPost]
        public JsonResult AlterarClinicaDocumentos(int codigoDaClinica, int codigoDoDocumento, string status)
        {

            var clinica = _clinicaRepositorio.ObterPor(codigoDaClinica);
            var documento = clinica.Documentos.Where(doc => doc.Codigo == codigoDoDocumento);

            var requisicao = new AlterarDocumentoStatusRequisicao
            {
                CodigoDaClinica = codigoDaClinica,
                CodigoDoDocumento = codigoDoDocumento,
                Status = status
            };

            var resposta = _clinicaServicoDeAplicacao.AlterarDocumentoStatus(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Documento = resposta.Documento.ToViewModel() });
        }


        [HttpPost]
        public FileResult BaixarDocumento(int codigoDaClinica, int codigoDoDocumento)
        {
            var requisicao = new ObterDocumentoDaClinicaRequisicao
            {
                CodigoDaClinica = codigoDaClinica,
                CodigoDoDocumento = codigoDoDocumento
            };
            var resposta = _clinicaServicoDeAplicacao.ObterDocumentoDaClinica(requisicao);

            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Documento.Nome);
        }

        [HttpPost]
        public JsonResult ExcluirDocumentoClinica(int codigoDaClinica, int codigoDoDocumento)
        {
            var requisicao = new ExcluirDocumentoDaClinicaRequisicao
            {
                CodigoDaClinica = codigoDaClinica,
                CodigoDoDocumento = codigoDoDocumento
            };
            var resposta = _clinicaServicoDeAplicacao.ExcluirDocumentoDaClinica(requisicao);

            return Json(resposta);
        }

        [HttpPost]
        public JsonResult AtualizarDataDeVencimento(DateTime dataVencimento, int codigoDaClinica, int codigoDoDocumento)
        {
            var requisicao = new AtualizarDataDeVencimentoRequisicao
            {
                DataDeVencimento = dataVencimento,
                CodigoDaClinica = codigoDaClinica,
                CodigoDoDocumento = codigoDoDocumento
            };
            var resposta = _clinicaServicoDeAplicacao.AtualizarDataDeVencimento(requisicao);

            return Json(new { resposta.Sucesso, resposta.Erros, Documento = resposta.Documento.ToViewModel() });
        }
        #endregion

        #region FATURAMENTO
        public ActionResult Faturamento()
        {
            return View("Faturamento/Index");
        }

        #region PREVIA
        public ActionResult Previa()
        {
            var consultaPreviaViewModel = new ConsultaPreviaViewModel
            {
                Meses = DateTime.Now.ObterTodosOsMesesAno(),
                Anos = Enumerable.Range(DateTime.Now.Year - 1, 10).ToList()
            };
            return View("Faturamento/Previa", consultaPreviaViewModel);
        }

        public JsonResult ObterInfusoesConsultaPrevia(int ano, int mes)
        {
            return Json(_faturamentoServicoDeAplicacao.ObterConsultaPreviaNoMes(mes, ano, Session.ProgramaAtivo()).Clinicas, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult PreviaVisualizacao(int idClinica, int mes, int ano)
        {
            var infusoes = _infusaoRepositorio.ObterTodasInfusoesDaClinicaNoMes(idClinica, mes, ano).ToViewModel();
            var clinica = _clinicaRepositorio.ObterPor(idClinica).ToViewModel();
            return PartialView("Faturamento/PreviaVisualizacao", new { Infusoes = infusoes, Clinica = clinica, Mes = mes, Ano = ano });
        }
        #endregion PREVIA

        #region CONSULTA
        public ActionResult Consulta()
        {
            var clinicas = _clinicaRepositorio.ObterTodos(Session.ProgramaAtivo());
            var consultaFaturamentoViewModel = new ConsultaFaturamentoViewModel
            {
                Meses = DateTime.Now.ObterTodosOsMesesAno(),
                Anos = Enumerable.Range(DateTime.Now.Year - 1, 10).ToList()
            };
            return View("Faturamento/Consulta", consultaFaturamentoViewModel);
        }

        public JsonResult ObterInfusoesConsultaFaturamento(int ano, int mes)
        {
            var a = _notaFiscalRepositorio.ObterTodasDaClinicaNoMes(mes, ano, Session.ProgramaAtivo());
            IList<dynamic> b = new List<dynamic>();
            foreach (var notaFiscal in a)
            {
                foreach (var infusao in notaFiscal.Infusoes)
                {
                    if (notaFiscal.Status() != "Estornado")
                    {
                        b.Add(new
                                  {
                                      notaFiscal.Codigo,
                                      infusao.Clinica.Nome,
                                      infusao.Localizador,
                                      infusao.DataInfusao,
                                      infusao.Clinica.ValorDeInfusao,
                                      Status = notaFiscal.Status(),
                                      notaFiscal.Data,
                                      notaFiscal.Numero
                                  });
                    }
                }
            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }
        #endregion CONSULTA

        public ActionResult Receber()
        {
            var clinicas = _clinicaRepositorio.ObterTodos(Session.ProgramaAtivo()).OrderBy(x => x.RazaoSocial).ToList();
            return View("Faturamento/Receber", clinicas.ToViewModel());
        }

        [HttpPost]
        public void ReceberArquivo(HttpPostedFileBase arquivo)
        {
            Session.Remove("Arquivo");
            Session["Arquivo"] = arquivo;
        }

        [HttpPost]
        public JsonResult Receber(ViewReceberNotaFiscal view)
        {
            var arquivo = Session["Arquivo"] as HttpPostedFileWrapper;
            Session.Remove("Arquivo");
            var requisicao = new NovaNotaRequisicao
                                 {
                                     CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                                     CodigoDoResponsavel = User.ToPessoa().Codigo,
                                     CodigoDaClinica = view.CodigoDaClinica,
                                     Arquivo = arquivo.InputStream,
                                     DescricaoDoArquivo = arquivo.FileName,
                                     NomeDoArquivo = arquivo.FileName,
                                     //Data = view.Data,
                                     Data = Convert.ToDateTime(view.Data),
                                     DataRecebimento = view.DataRecebimento,
                                     Numero = view.Numero,
                                     Valor = view.Valor,
                                     Infusoes = view.Infusoes
                                 };
            var resposta = _faturamentoServicoDeAplicacao.NovaNota(requisicao);
            return Json(resposta);
        }

        public ActionResult Gestao()
        {
            var gestaoViewModel = new GestaoViewModel
                                      {
                                          Meses = DateTime.Now.ObterTodosOsMesesAno(),
                                          Anos = Enumerable.Range(DateTime.Now.Year - 1, 10).ToList()
                                      };
            return View("Faturamento/Gestao", gestaoViewModel);
        }

        public ActionResult Devolucao()
        {
            var gestaoViewModel = new GestaoViewModel
            {
                Meses = DateTime.Now.ObterTodosOsMesesAno(),
                Anos = Enumerable.Range(DateTime.Now.Year - 1, 10).ToList()
            };
            return View("Faturamento/Devolucao", gestaoViewModel);
        }
        #endregion

        public JsonResult ObterInfusoes(int id)
        {
            var clinica = _clinicaRepositorio.ObterPor(id);
            return Json(_infusaoRepositorio.ObterTodasNaoVinculadas(clinica).ToViewModel(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterNotas(int ano, int mes)
        {
            return Json(_notaFiscalRepositorio.ObterTodasNoMes(mes, ano, Session.ProgramaAtivo()).ToViewModel(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DevolverNota(ViewReceberNotaFiscal view)
        {
            var arquivo = Session["Arquivo"] as HttpPostedFileWrapper;
            Session.Remove("Arquivo");
            var requisicao = new DevolverNotaRequisicao
            {
                CodigoDoResponsavel = User.ToPessoa().Codigo,
                CodigoDaClinica = view.CodigoDaClinica,
                Arquivo = arquivo.InputStream,
                DescricaoDoArquivo = arquivo.FileName,
                NomeDoArquivo = arquivo.FileName,
                //Data = view.Data,
                Data = Convert.ToDateTime(view.Data),
                DataRecebimento = view.DataRecebimento,
                Numero = view.Numero,
                Valor = view.Valor,
                Infusoes = view.Infusoes,
                Motivo = view.Motivo,
                CodigoDoPrograma = Session.ProgramaAtivo().Codigo,
                TipoDeDevolucao = view.FormaDevolucao
            };
            var resposta = _faturamentoServicoDeAplicacao.DevolverNotaFiscal(requisicao);
            return Json(resposta);
        }

        public JsonResult PagarNotaFiscal(PagarNotaFiscalViewModel viewModel)
        {
            var resposta = _faturamentoServicoDeAplicacao.PagarNotaFiscal(new PagarNotaFiscalRequisicao
            {
                Observacao = viewModel.Observacao,
                CodigoDaNota = viewModel.Codigo,
                DescricaoDoComprovante = viewModel.Arquivo.FileName,
                NomeDoComprovante = viewModel.Arquivo.FileName,
                Comprovante = viewModel.Arquivo.InputStream,
                DataPagamento = Convert.ToDateTime(viewModel.DataPagamento)
            });
            return Json(resposta);
        }

        public JsonResult EstornarNotaFiscal(PagarNotaFiscalViewModel viewModel)
        {
            var resposta = _faturamentoServicoDeAplicacao.EstornarNotaFiscal(new EstornarNotaFiscalRequisicao
                                                                  {
                                                                      Observacao = viewModel.Observacao,
                                                                      CodigoDaNota = viewModel.Codigo
                                                                  });
            return Json(resposta);
        }

        [HttpPost]
        public FileResult BaixarNotaFiscal(int id)
        {
            var requisicao = new ObterArquivoDaNotaFiscalRequisicao
                                 {
                                     CodigoDaNota = id
                                 };


            var resposta = _faturamentoServicoDeAplicacao.ObterArquivoDaNotaFiscal(requisicao);
            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Nota.Arquivo.Nome);
        }

        [HttpPost]
        public FileResult BaixarComprovante(int id)
        {
            var requisicao = new ObterComprovanteRequisicao
            {
                CodigoDaNota = id
            };

            var resposta = _faturamentoServicoDeAplicacao.ObterComprovante(requisicao);
            return File(resposta.Arquivo, System.Net.Mime.MediaTypeNames.Application.Octet, resposta.Nota.Pagamento.Comprovante.Nome);
        }

        public JsonResult ObterNotasDevolvidas(int ano, int mes)
        {
            return Json(_notaFiscalRepositorio.ObterTodasNotasDevolvidasNoMes(mes, ano, Session.ProgramaAtivo()).ToViewModel(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult EnviarEmailDaPrevia(int codigoDaClinica, int mes, int ano, string email)
        {
            return Json(_faturamentoServicoDeAplicacao.EnviarPreviaPorEmail(codigoDaClinica, mes, ano, email));
        }

        public ActionResult NotasReceber()
        {
            var notasReceberViewModel = new NotasReceberViewModel
            {
                Meses = DateTime.Now.ObterTodosOsMesesAno(),
                Anos = Enumerable.Range(DateTime.Now.Year - 1, 10).ToList()
            };
            notasReceberViewModel.Meses.Remove(notasReceberViewModel.Meses[12]);

            return View("Faturamento/NotasReceber", notasReceberViewModel);
        }

        public JsonResult ObterNotasReceber(int ano, int mes)
        {
            var notasRecebidas = _notaFiscalRepositorio.ObterTodasNoMes(mes, ano, Session.ProgramaAtivo()).ToViewModel();
            var previaInfusoesMensal = _faturamentoServicoDeAplicacao.ObterConsultaPreviaNoMes(mes, ano, Session.ProgramaAtivo()).Clinicas;

            var notasParaReceber = from Notas in previaInfusoesMensal
                                   where !(from NotasPagas in notasRecebidas select NotasPagas.CodigoDaClinica).Contains(Notas.CodigoDaClinica)
                                   select Notas;

            return Json(notasParaReceber.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConsultaDocumentos()
        {
            var listaDocs = new List<ConsultaDocumentosClinicaViewModel>();
            //var documentos = _clinicaDocumentoRepositorio.ObterTodos();
            var clinicas = _clinicaRepositorio.ObterTodos(Session.ProgramaAtivo()).OrderBy(x => x.Nome);

            //foreach (var clinica in clinicas)
            //{
            //    listaDocs.AddRange(clinica.Documentos.Select(docs => new ConsultaDocumentosClinicaViewModel
            //        {
            //            DataDeUpload = docs.DataDeUpload,
            //            //TipoDocumento = ((TipoDocumentoDaClinica)docs.TipoDocumento).GetHashCode().ToString(),
            //            TipoDocumento = ((TipoDocumentoDaClinica)docs.TipoDocumento).ToString(),
            //            Descricao = docs.Descricao,
            //            Nome = docs.Nome,
            //            DataDeVencimento = docs.DataDeVencimento,
            //            StatusDocumento = docs.StatusDocumento.ToString(),
            //            ClinicaNome = clinica.Nome,
            //            ClinicaCodigo = clinica.Codigo
            //        }));
            //}

            //ContratoIntegra 
            //Alvara
            //ContratoSocial
            //VigilanciaSanitaria
            //RegimeInterno
            //DocRespClinica
            //DocRespTecnico
            //OutrosDocumentos

            foreach (var clinica in clinicas)
            {
                var addDocumentoItem = new ConsultaDocumentosClinicaViewModel() { ClinicaNome = clinica.Nome, ClinicaCodigo = clinica.Codigo };
                var ContratoIntegra = false;
                var Alvara = false;
                var ContratoSocial = false;
                var VigilanciaSanitaria = false;
                var RegimeInterno = false;
                var DocRespClinica = false;
                var DocRespTecnico = false;
                var OutrosDocumentos = false;

                var CertificadoMedico = false;
                var CertificadoEnfermeiro = false;

                foreach (var doc in clinica.Documentos)
                {
                    if (doc.StatusDocumento == DocumentoStatus.Ativo)
                    {
                        switch (doc.TipoDocumento)
                        {
                            case TipoDocumentoDaClinica.ContratoIntegra:
                                addDocumentoItem.ContratoIntegra = "Enviado";
                                addDocumentoItem.ContratoIntegraData = doc.DataDeVencimento;
                                ContratoIntegra = true;
                                break;

                            case TipoDocumentoDaClinica.Alvara:
                                addDocumentoItem.Alvara = "Enviado";
                                addDocumentoItem.AlvaraData = doc.DataDeVencimento;
                                Alvara = true;
                                break;

                            case TipoDocumentoDaClinica.ContratoSocial:
                                addDocumentoItem.ContratoSocial = "Enviado";
                                addDocumentoItem.ContratoSocialData = doc.DataDeVencimento;
                                ContratoSocial = true;
                                break;

                            case TipoDocumentoDaClinica.VigilanciaSanitaria:
                                addDocumentoItem.VigilanciaSanitaria = "Enviado";
                                addDocumentoItem.VigilanciaSanitariaData = doc.DataDeVencimento;
                                VigilanciaSanitaria = true;
                                break;

                            case TipoDocumentoDaClinica.RegimeInterno:
                                addDocumentoItem.RegimeInterno = "Enviado";
                                addDocumentoItem.RegimeInternoData = doc.DataDeVencimento;
                                RegimeInterno = true;
                                break;

                            case TipoDocumentoDaClinica.DocRespClinica:
                                addDocumentoItem.DocRespClinica = "Enviado";
                                addDocumentoItem.DocRespClinicaData = doc.DataDeVencimento;
                                DocRespClinica = true;
                                break;

                            case TipoDocumentoDaClinica.DocRespTecnico:
                                addDocumentoItem.DocRespTecnico = "Enviado";
                                addDocumentoItem.DocRespTecnicoData = doc.DataDeVencimento;
                                DocRespTecnico = true;
                                break;

                            case TipoDocumentoDaClinica.OutrosDocumentos:
                                addDocumentoItem.OutrosDocumentos = "Enviado";
                                addDocumentoItem.OutrosDocumentosData = doc.DataDeVencimento;
                                OutrosDocumentos = true;
                                break;

                            case TipoDocumentoDaClinica.CertificadoMedico:
                                addDocumentoItem.CertificadoMedico = "Enviado";
                                addDocumentoItem.CertificadoMedicoData = doc.DataDeVencimento;
                                CertificadoMedico = true;
                                break;

                            case TipoDocumentoDaClinica.CertificadoEnfermeiro:
                                addDocumentoItem.CertificadoEnfermeiro = "Enviado";
                                addDocumentoItem.CertificadoEnfermeiroData = doc.DataDeVencimento;
                                CertificadoEnfermeiro = true;
                                break;
                        }
                    }
                }

                if (!ContratoIntegra) { addDocumentoItem.ContratoIntegra = "Falta enviar"; }
                if (!Alvara) { addDocumentoItem.Alvara = "Falta enviar"; }
                if (!ContratoSocial) { addDocumentoItem.ContratoSocial = "Falta enviar"; }
                if (!VigilanciaSanitaria) { addDocumentoItem.VigilanciaSanitaria = "Falta enviar"; }
                if (!RegimeInterno) { addDocumentoItem.RegimeInterno = "Falta enviar"; }
                if (!DocRespClinica) { addDocumentoItem.DocRespClinica = "Falta enviar"; }
                if (!DocRespTecnico) { addDocumentoItem.DocRespTecnico = "Falta enviar"; }
                if (!OutrosDocumentos) { addDocumentoItem.OutrosDocumentos = "Falta enviar"; }
                if (!CertificadoMedico) { addDocumentoItem.CertificadoMedico = "Falta enviar"; }
                if (!CertificadoEnfermeiro) { addDocumentoItem.CertificadoEnfermeiro = "Falta enviar"; }

                listaDocs.Add(addDocumentoItem);

            }



            return View("Clinica/ConsultaDocumentos", listaDocs);

        }
    }
}
