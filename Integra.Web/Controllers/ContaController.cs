using System.Collections.Generic;
using System.Data.SqlClient;
using Integra.Dominio.Repositorios;
using Integra.Repositorio.EF.Repositorios;
using Integra.ServicosDeAplicacao;
using Integra.ServicosDeAplicacao.Mensagens.Perfil;
using Integra.ServicosDeAplicacao.Mensagens.Pessoa;
using Integra.ServicosDeAplicacao.Mensagens.Programa;
using Integra.ServicosDeAplicacao.Mensagens.Usuario;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Integra.Web.Controllers
{
    public class ContaController : BaseController
    {
        private readonly PessoaServicoDeAplicacao _pessoaServicoDeAplicacao;
        private readonly ProgramaServicoDeAplicacao _programaServicoDeAplicacao;
        private readonly PerfilServicoDeAplicacao _perfilServicoDeAplicacao;
        private readonly ITipoDeCrmRepositorio _tipoDeCrmRepositorio;
        private readonly IPerfilRepositorio _perfilRepositorio;
        private readonly IGrupoRepositorio _grupoRepositorio;
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IModuloRepositorio _moduloRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public ContaController(ITipoDeCrmRepositorio tipoDeCrmRepositorio, IPerfilRepositorio perfilRepositorio,
            IGrupoRepositorio grupoRepositorio, ICargoRepositorio cargoRepositorio, IDepartamentoRepositorio departamentoRepositorio
            , IProgramaRepositorio programaRepositorio, IModuloRepositorio moduloRepositorio, IPessoaRepositorio pessoaRepositorio
            , IClienteRepositorio clienteRepositorio, IFuncionarioRepositorio funcionarioRepositorio,
            PerfilServicoDeAplicacao perfilServicoDeAplicacao, PessoaServicoDeAplicacao pessoaServicoDeAplicacao, ProgramaServicoDeAplicacao programaServicoDeAplicacao)
        {
            _tipoDeCrmRepositorio = tipoDeCrmRepositorio;
            _perfilRepositorio = perfilRepositorio;
            _grupoRepositorio = grupoRepositorio;
            _cargoRepositorio = cargoRepositorio;
            _departamentoRepositorio = departamentoRepositorio;
            _programaRepositorio = programaRepositorio;
            _moduloRepositorio = moduloRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _perfilServicoDeAplicacao = perfilServicoDeAplicacao;

            _pessoaServicoDeAplicacao = pessoaServicoDeAplicacao;
            _programaServicoDeAplicacao = programaServicoDeAplicacao;
        }

        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public ActionResult Index()
        {
            return View(_pessoaRepositorio.ObterTodos().ToViewModel());
        }

        public PartialViewResult AlterarSenha()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (SecurityHelper.Authenticate(User.ToPessoa().Usuario.NomeDeUsuario, viewModel.Senha))
            {
                var requisicao = new AlterarSenhaRequisicao
                                     {
                                         CodigoDaPessoa = User.ToPessoa().Codigo,
                                         NovaSenha = viewModel.NovaSenha
                                     };
                var resposta = _pessoaServicoDeAplicacao.AlterarSenha(requisicao);
                return Json(resposta);
            }
            return Json(new { Sucesso = false });
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (SecurityHelper.Authenticate(model.NomeDeUsuario, model.Senha))
                {
                    FormsAuthentication.SetAuthCookie(model.NomeDeUsuario, model.Relembrar);
                    var pessoa = _pessoaServicoDeAplicacao.RegistrarAcesso(model.NomeDeUsuario);
                    Session.SetProgramaAtivo(pessoa.ProgramasPermitidos[0]);
                    return Redirect(string.IsNullOrWhiteSpace(model.ReturnUrl) ? Url.Action("Index", "Relatorios") : model.ReturnUrl);
                }
            }
            catch (Exception exception)
            {
                ViewBag.HasError = true;
                Error(exception.Message);
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SecurityHelper.Logout();
            return RedirectToAction("Login");
        }


        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public ActionResult Editar(int id)
        {
            var perfils =
                _perfilRepositorio.ObterTodos().Select(t => new { t.Codigo, t.Nome, CodigoDoGrupo = t.Grupo.Codigo });
            var grupoIntegra = _grupoRepositorio.ObterGrupoIntegra();
            var grupos = _grupoRepositorio.ObterTodos().Select(t => new { t.Codigo, t.Descricao });
            var tipos = _tipoDeCrmRepositorio.ObterTodos().ToList();
            var departamentos = _departamentoRepositorio.ObterTodos().ToList();
            var cargos = _cargoRepositorio.ObterTodos().ToList();
            var programas = _programaRepositorio.ObterTodos().ToList();
            var novoUsuario = new AdicionarUsuarioViewModel
                                  {
                                      Perfils = perfils,
                                      Grupos = grupos,
                                      TiposDeCrm = tipos,
                                      Cargos = cargos,
                                      Departamentos = departamentos,
                                      GrupoIntegra = grupoIntegra,
                                      Programas = programas
                                  };

            var cliente = _clienteRepositorio.ObterPor(id);
            if (cliente == null)
            {
                var funcionario = _funcionarioRepositorio.ObterPor(id);
                novoUsuario.Codigo = funcionario.Codigo;
                novoUsuario.PerfilSelecionado = funcionario.Usuario.Perfil.Codigo;
                novoUsuario.NomeDeUsuario = funcionario.Usuario.NomeDeUsuario;
                novoUsuario.GrupoSelecionado = funcionario.Usuario.Perfil.Grupo.Codigo;
                novoUsuario.CodigoDoCargo = funcionario.Cargo != null ? funcionario.Cargo.Codigo : 1;
                novoUsuario.CodigoDoDepartamento = funcionario.Departamento != null ? funcionario.Departamento.Codigo : 1;
                novoUsuario.Nome = funcionario.Nome;
                novoUsuario.Telefone = funcionario.Telefone;
                novoUsuario.Status = funcionario.Inativo;
                novoUsuario.CodigosDosProgramas = funcionario.ProgramasPermitidos.Select(it => it.Codigo).ToList();
                novoUsuario.DescricaoDoCargo = funcionario.Descricao;
            }
            else
            {
                novoUsuario.Codigo = cliente.Codigo;
                novoUsuario.PerfilSelecionado = cliente.Usuario.Perfil.Codigo;
                novoUsuario.NomeDeUsuario = cliente.Usuario.NomeDeUsuario;
                novoUsuario.GrupoSelecionado = cliente.Usuario.Perfil.Grupo.Codigo;
                novoUsuario.Nome = cliente.Nome;
                if (cliente.Crm != null)
                {
                    novoUsuario.NumeroDoCrm = cliente.Crm.NumeroDoCRM;
                    novoUsuario.TipoDeCrmSelecionado = cliente.Crm.Tipo.Codigo;
                    novoUsuario.NomeDoCrm = cliente.Crm.NomeDoCRM;
                }
                novoUsuario.Telefone = cliente.Telefone;
                novoUsuario.Status = cliente.Inativo;
                novoUsuario.CodigosDosProgramas = cliente.ProgramasPermitidos.Select(it => it.Codigo).ToList();

            }

            return View("NovoUsuario", novoUsuario);
        }


        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public ActionResult NovoUsuario()
        {
            var perfils = _perfilRepositorio.ObterTodos().Select(t => new { t.Codigo, t.Nome, CodigoDoGrupo = t.Grupo.Codigo });
            var grupoIntegra = _grupoRepositorio.ObterGrupoIntegra();
            var grupos = _grupoRepositorio.ObterTodos().Select(t => new { t.Codigo, t.Descricao });
            var tipos = _tipoDeCrmRepositorio.ObterTodos().ToList();
            var departamentos = _departamentoRepositorio.ObterTodos().ToList();
            var cargos = _cargoRepositorio.ObterTodos().ToList();
            var programas = _programaRepositorio.ObterTodos().ToList();
            var novoUsuario = new AdicionarUsuarioViewModel
                                  {
                                      Perfils = perfils,
                                      Grupos = grupos,
                                      TiposDeCrm = tipos,
                                      Cargos = cargos,
                                      Departamentos = departamentos,
                                      GrupoIntegra = grupoIntegra,
                                      Programas = programas
                                  };

            return View(novoUsuario);
        }

        [HttpPost]
        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public JsonResult NovoUsuario(AdicionarUsuarioViewModel novoUsuarioModel)
        {
            return Json(novoUsuarioModel.Codigo == 0 ? AdicionarPessoa(novoUsuarioModel) : EditarPessoa(novoUsuarioModel));
        }

        private object EditarPessoa(AdicionarUsuarioViewModel viewModel)
        {
            var novoUsuarioRequisicao = new AlterarUmaPessoaRequisicao
            {
                Codigo = viewModel.Codigo,
                CodigoDoPerfil = viewModel.PerfilSelecionado,
                CodigoDoTipoDeCrm = viewModel.TipoDeCrmSelecionado,
                NumeroDoCrm = viewModel.NumeroDoCrm,
                CodigoDoDepartamento = viewModel.CodigoDoDepartamento,
                CodigoDoCargo = viewModel.CodigoDoCargo,
                Nome = viewModel.Nome,
                Telefone = viewModel.Telefone,
                Inativo = viewModel.Status,
                NomeDeUsuario = viewModel.NomeDeUsuario,
                Descricao = viewModel.DescricaoDoCargo,
                CodigosDosProgramas = viewModel.CodigosDosProgramas,
                NomeDoCrm = viewModel.NomeDoCrm
            };
            var resposta = _pessoaServicoDeAplicacao.AlterarUmaPessoa(novoUsuarioRequisicao);
            return resposta;
        }

        private AdicionarUmaPessoaResposta AdicionarPessoa(AdicionarUsuarioViewModel novoUsuarioModel)
        {
            var novoUsuarioRequisicao = new AdicionarUmaPessoaRequisicao
                                            {
                                                CodigoDoPerfil = novoUsuarioModel.PerfilSelecionado,
                                                NomeDeUsuario = novoUsuarioModel.NomeDeUsuario,
                                                CodigoDoGrupo = novoUsuarioModel.GrupoSelecionado,
                                                CodigoDoTipoDeCrm = novoUsuarioModel.TipoDeCrmSelecionado,
                                                NumeroDoCrm = novoUsuarioModel.NumeroDoCrm,
                                                CodigoDoDepartamento = novoUsuarioModel.CodigoDoDepartamento,
                                                CodigoDoCargo = novoUsuarioModel.CodigoDoCargo,
                                                Nome = novoUsuarioModel.Nome,
                                                Telefone = novoUsuarioModel.Telefone,
                                                Inativo = novoUsuarioModel.Status,
                                                Descricao = novoUsuarioModel.DescricaoDoCargo,
                                                CodigosDosProgramas = novoUsuarioModel.CodigosDosProgramas,
                                                NomeDoCrm = novoUsuarioModel.NomeDoCrm
                                            };

            var resposta = _pessoaServicoDeAplicacao.AdicionarUmaPessoa(novoUsuarioRequisicao, Session.ProgramaAtivo().CodPrograma);
            return resposta;
        }

        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public PartialViewResult CadastroDePrograma()
        {
            var cadastroDePrograma = new AdicionarProgramaViewModel();
            return PartialView(cadastroDePrograma);
        }

        [HttpPost]
        public JsonResult NovoPrograma(AdicionarProgramaViewModel cadastroDeProgramaViewModel)
        {
            var adicionarProgramaRequisicao = new AdicionarProgramaRequisicao
            {
                Nome = cadastroDeProgramaViewModel.Nome,
                Descricao = cadastroDeProgramaViewModel.Descricao,
                Identificador = cadastroDeProgramaViewModel.Identificador,
                CodigoAuxiliar = cadastroDeProgramaViewModel.CodigoAuxiliar
            };
            var resposta = _programaServicoDeAplicacao.AdicionarPrograma(adicionarProgramaRequisicao);
            return Json(new
            {
                resposta.Sucesso,
                resposta.Erros,
                Programa = new
                {
                    resposta.Programa.Codigo,
                    resposta.Programa.Nome,
                }
            });
        }

        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public PartialViewResult CadastroDePerfil()
        {
            var cadastroDePerfil = new AdicionarPerfilViewModel
                                       {
                                           Modulos = _moduloRepositorio.ObterTodos().Select(m => new { m.Codigo, m.Nome }),
                                           Grupos = _grupoRepositorio.ObterTodos().Select(g => new { g.Codigo, g.Descricao })
                                       };
            return PartialView(cadastroDePerfil);
        }

        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public PartialViewResult EdicaoDePerfil(int id, int grupoID, string perfilNome)
        {
            var modulosPermitidos = _perfilRepositorio.ObterTodos().Where(perfil => perfil.Codigo == id).ToList().Select(permitidos => new { permitidos.ModulosPermitidos, permitidos.Nome, permitidos.Codigo }).ToList();
            var modulosPermitidosInt = modulosPermitidos[0].ModulosPermitidos.Select(t => t.Codigo).ToList();

            ViewBag.NomePerfil = perfilNome;
            ViewBag.CodigoPerfil = id;
            ViewBag.CodigoGrupo = grupoID;

            var edicaoDePerfil = new EditarPerfilViewModel
            {
                Modulos = _moduloRepositorio.ObterTodos().Select(m => new { m.Codigo, m.Nome }),
                Grupos = _grupoRepositorio.ObterTodos().Select(g => new { g.Codigo, g.Descricao }),
                CodigoDosModulosSelecionados = modulosPermitidosInt
            };

            return PartialView(edicaoDePerfil);
        }

        [AuthorizeCustom(Modulo = "GestaoUsuario")]
        public PartialViewResult SelecionarAcesso(int id)
        {
            var clsClass = new RelatorioRepositorio();
            var tipoCrm = _tipoDeCrmRepositorio.ObterPor(id);
            clsClass.MclsDaoFiltroRelatorio.Parametros.Add(new SqlParameter("TipoConsulta", tipoCrm.FlagCrm));
            var lstDados = clsClass.MclsDaoFiltroRelatorio.ExecutarListaProcedure("spAcessoNomes");
            return PartialView(lstDados);
        }


        [HttpPost]
        public JsonResult NovoPerfil(AdicionarPerfilViewModel cadastroDePerfilViewModel)
        {
            var adicionarPerfilRequisicao = new AdicionarPerfilRequisicao
                                                {
                                                    Nome = cadastroDePerfilViewModel.Nome,
                                                    CodigoDoGrupo = cadastroDePerfilViewModel.Grupo,
                                                    CodigosDosModulosPermitidos = cadastroDePerfilViewModel.CodigoDosModulosSelecionados
                                                };
            var resposta = _perfilServicoDeAplicacao.AdicionarPerfil(adicionarPerfilRequisicao);
            return Json(new
                            {
                                resposta.Sucesso,
                                resposta.Erros,
                                Perfil = new
                                             {
                                                 resposta.Perfil.Codigo,
                                                 resposta.Perfil.Nome,
                                                 CodigoDoGrupo = resposta.Perfil.Grupo.Codigo
                                             }
                            });
        }

        [HttpPost]
        public JsonResult EdicaoDePerfil(EditarPerfilViewModel cadastroDePerfilViewModel)
        {
            var perfilModulo = _perfilRepositorio.ObterTodos().FirstOrDefault(perfil => perfil.Codigo == cadastroDePerfilViewModel.CodigoPerfil);
            var modulos = _moduloRepositorio.ObterTodos();
            bool deletar;

            perfilModulo.ModulosPermitidos.Clear();

            foreach (var disponivel in modulos)
            {
                deletar = cadastroDePerfilViewModel.CodigoDosModulosSelecionados.All(selecionado => disponivel.Codigo != selecionado);
                if (!deletar)
                {
                    perfilModulo.ModulosPermitidos.Add(disponivel);
                }
            }

            var resposta = _perfilServicoDeAplicacao.AlterarPerfil(perfilModulo);


            return Json(new
                {
                    resposta.Sucesso,
                    resposta.Erros
                });

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarSenha(LoginViewModel model)
        {
            var requisicao = new RecuperarSenhaRequisicao
                                 {
                                     NomeDoUsuario = model.NomeDeUsuario
                                 };
            var resposta = _pessoaServicoDeAplicacao.RecuperarSenha(requisicao);
            if (!resposta.Sucesso)
            {
                ViewBag.HasError = true;
                var mensagem = string.Empty;
                resposta.Erros.ForEach(it => { mensagem += it.Mensagem + Environment.NewLine; });
                Error(mensagem);
            }
            else
            {
                Success("Uma nova senha foi enviada para seu email!");
            }
            return RedirectToAction("Login");
        }
    }
}
