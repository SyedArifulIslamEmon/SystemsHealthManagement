using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.Dominio.Base.Infra;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Pessoa;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Pessoa;
using Integra.ServicosDeAplicacao.Mensagens.Usuario;
using System.Linq;
using Integra.ServicosDeAplicacao.Properties;

namespace Integra.ServicosDeAplicacao
{
    public class PessoaServicoDeAplicacao
    {
        private readonly IPerfilRepositorio _perfilRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly FuncionarioServico _funcionarioServico;
        private readonly ClienteServico _clienteServico;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly ITipoDeCrmRepositorio _tipoDeCrmRepositorio;
        private readonly RepositorioDeArquivos _repositorioDeArquivos;

        public PessoaServicoDeAplicacao(IPerfilRepositorio perfilRepositorio, IUnitOfWork unitOfWork, IFuncionarioRepositorio funcionarioRepositorio,
            IClienteRepositorio clienteRepositorio, ICargoRepositorio cargoRepositorio, IDepartamentoRepositorio departamentoRepositorio, IPessoaRepositorio pessoaRepositorio,
            FuncionarioServico funcionarioServico, ClienteServico clienteServico, IProgramaRepositorio programaRepositorio,
            ITipoDeCrmRepositorio tipoDeCrmRepositorio, RepositorioDeArquivos repositorioDeArquivos)
        {
            _perfilRepositorio = perfilRepositorio;
            _unitOfWork = unitOfWork;
            _funcionarioRepositorio = funcionarioRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _cargoRepositorio = cargoRepositorio;
            _departamentoRepositorio = departamentoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _funcionarioServico = funcionarioServico;
            _clienteServico = clienteServico;
            _programaRepositorio = programaRepositorio;
            _tipoDeCrmRepositorio = tipoDeCrmRepositorio;
            _repositorioDeArquivos = repositorioDeArquivos;
        }

        public AdicionarUmaPessoaResposta AdicionarUmaPessoa(AdicionarUmaPessoaRequisicao requisicao, int codPrograma)
        {
            var resposta = new AdicionarUmaPessoaResposta();

            try
            {

                var departamento = _departamentoRepositorio.ObterPor(requisicao.CodigoDoDepartamento);
                var perfil = _perfilRepositorio.ObterPor(requisicao.CodigoDoPerfil);
                var senha = GeradorDeSenhas.Gerar(GeradorDeSenhas.RandomType.Alphanumeric, 8);


                var novoUsuario = new Usuario(requisicao.NomeDeUsuario, senha, perfil);
                var existeEmailCadastrado = _pessoaRepositorio.ObterPeloNomeDeUsuario(requisicao.NomeDeUsuario);
                if (existeEmailCadastrado != null)
                    novoUsuario.RegraQuebrada(RegrasDeNegocioPessoa.EmailJaExiste);
                novoUsuario.AlterarSenha(Crypto.HashPassword(senha));

                var programas = requisicao.CodigosDosProgramas.Select(codigoDoPrograma => _programaRepositorio.ObterPor(codigoDoPrograma)).ToList();

                //perfil.Grupo.Codigo

                if (perfil.Grupo.Codigo == 1)
                {
                    departamento = _departamentoRepositorio.ObterPor(1);
                    var cargo = _cargoRepositorio.ObterPor(1);
                    _funcionarioServico.AdicionarUmNovoFuncionario(requisicao.Nome, requisicao.Telefone,
                                                                   novoUsuario, departamento, cargo, programas, requisicao.Descricao);

                }
                else
                {
                    var cliente = _clienteServico.AdicionarUmNovoCliente(requisicao.Nome, requisicao.Telefone,
                          requisicao.Inativo, novoUsuario, programas);

                    var tipoDoCrm = _tipoDeCrmRepositorio.ObterPor(requisicao.CodigoDoTipoDeCrm);
                    if (tipoDoCrm != null)
                    {
                            var crm = new CRM(requisicao.NumeroDoCrm, tipoDoCrm, requisicao.NomeDoCrm);
                            cliente.InformarCrm(crm);
                    }
                }
                foreach (var programa in programas)
                {
                    EnviarEmailParaNovoUsarioDoPrograma(programa.Codigo, novoUsuario, senha);
                    break;
                }

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraDeNegocio)
            {
                resposta.Erros = regraDeNegocio.Erros.ToList();
            }

            return resposta;
        }

        private static void EnviarEmailParaNovoUsarioDoPrograma(int codigo, Usuario novoUsuario,
                                                                string senha)
        {
            string nomePrograma;
            string urlPrograma;
            string mailPrograma;
            switch (codigo)
            {
                case 1:
                    //nomePrograma = "Programa Essencial Remicade";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    //mailPrograma = "programaessencial@integramedical.com.br";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 2:
                    //nomePrograma = "Juntos e Livres";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 3:
                    //nomePrograma = "Bem Estar";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 4:
                    //nomePrograma = "Pró-Memória";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 5:
                    //nomePrograma = "Faz Bem";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 6:
                    //nomePrograma = "Coaguchek e Você";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 7:
                    //nomePrograma = "Procaps";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 8:
                    //nomePrograma = "Enzimais";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 9:
                    //nomePrograma = "Inclusão";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 10:
                    //nomePrograma = "Inspiração";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 11:
                    //nomePrograma = "Omnitrope";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                case 12:
                    //nomePrograma = "Porque Ver é Viver";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "atendimento@integramedical.com.br";
                    break;
                default:
                    //nomePrograma = "Essencial";
                    nomePrograma = "Íntegra Medical";
                    urlPrograma = "http://www.integramedical.com.br/paineldecontrole";
                    mailPrograma = "programaessencial@integramedical.com.br";
                    break;
            }

            new ServicoDeEmail().EnviarEmail(novoUsuario.NomeDeUsuario,
                                             "Acesso Painel de Controle ",
                                             String.Format(
                                                 @"Prezado usuário, <br /><br /><br />Você foi cadastrado para utilização do Painel de Controle. <br /><br />O endereço é: "
                                                 + urlPrograma +
                                                 " <br />Seu login é: {0}<br />Sua senha é: {1}<br /><br /><br />Atenciosamente, <br /><br />"
                                                 + nomePrograma + "<br />(11) 5054-9199<br />" + mailPrograma,
                                                 novoUsuario.NomeDeUsuario, senha));
        }

        public AlterarUmaPessoaResposta AlterarUmaPessoa(AlterarUmaPessoaRequisicao requisicao)
        {
            var resposta = new AlterarUmaPessoaResposta();
            try
            {
                var departamento = _departamentoRepositorio.ObterPor(requisicao.CodigoDoDepartamento);

                var perfil = _perfilRepositorio.ObterPor(requisicao.CodigoDoPerfil);


                var programas = requisicao.CodigosDosProgramas.Select(_programaRepositorio.ObterPor).ToList();

                if (perfil.Grupo.Codigo == 1)
                {
                    var cargo = _cargoRepositorio.ObterPor(requisicao.CodigoDoCargo);
                    var funcionario = _funcionarioRepositorio.ObterPor(requisicao.Codigo);
                    funcionario.Usuario.NomeDeUsuario = requisicao.NomeDeUsuario;
                    funcionario.Cargo = cargo ?? _cargoRepositorio.ObterPor(1);
                    funcionario.Usuario.Perfil = perfil;
                    funcionario.Departamento = departamento ?? _departamentoRepositorio.ObterPor(1);
                    funcionario.ProgramasPermitidos.Clear();
                    funcionario.ProgramasPermitidos = programas;
                    funcionario.Nome = requisicao.Nome;
                    funcionario.Telefone = requisicao.Telefone;
                    funcionario.Descricao = requisicao.Descricao;
                    funcionario.Inativo = requisicao.Inativo;
                }
                else
                {
                    var cliente = _clienteRepositorio.ObterPor(requisicao.Codigo);
                    cliente.Usuario.NomeDeUsuario = requisicao.NomeDeUsuario;
                    cliente.Nome = requisicao.Nome;
                    cliente.Telefone = requisicao.Telefone;
                    cliente.ProgramasPermitidos.Clear();
                    cliente.ProgramasPermitidos = programas;
                    cliente.Usuario.Perfil = perfil;
                    cliente.Inativo = requisicao.Inativo;
                    if (cliente.Crm != null)
                    {
                        if (cliente.Crm.Tipo.Codigo != requisicao.CodigoDoTipoDeCrm)
                        {
                            var tipoDoCrm = _tipoDeCrmRepositorio.ObterPor(requisicao.CodigoDoTipoDeCrm);
                            var crm = new CRM(requisicao.NumeroDoCrm, tipoDoCrm, requisicao.NomeDoCrm);
                            cliente.InformarCrm(crm);
                        }
                        else
                        {
                            cliente.Crm.NumeroDoCRM = requisicao.NumeroDoCrm;
                            cliente.Crm.NomeDoCRM = requisicao.NomeDoCrm;
                        }
                    }
                    else
                    {
                        var tipoDoCrm = _tipoDeCrmRepositorio.ObterPor(requisicao.CodigoDoTipoDeCrm);
                        var crm = new CRM(requisicao.NumeroDoCrm, tipoDoCrm, requisicao.NomeDoCrm);
                        cliente.InformarCrm(crm);
                    }
                }
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraDeNegocio)
            {
                resposta.Erros = regraDeNegocio.Erros.ToList();
            }

            return resposta;
        }

        public Pessoa RegistrarAcesso(string nomeDeUsuario)
        {
            var pessoa = _pessoaRepositorio.ObterPeloNomeDeUsuario(nomeDeUsuario);
            pessoa.Usuario.RegristarAcesso();
            _unitOfWork.Commit();
            return pessoa;
        }

        public TrocarFotoResposta TrocarFoto(TrocarFotoRequisicao requisicao)
        {
            var resposta = new TrocarFotoResposta();
            try
            {
                var pessoa = _pessoaRepositorio.ObterPor(requisicao.CodigoDaPessoa);
                var data = SystemTime.Now;
                var foto = new Arquivo(requisicao.Nome, requisicao.Nome, data);

                if (requisicao.Foto.Length < 263166)
                {
                    var repositorioDeArquivos = new RepositorioDeArquivos();
                    repositorioDeArquivos.ArmazenarArquivo(requisicao.Foto, requisicao.Nome, data);
                    pessoa.Foto = foto;
                    _unitOfWork.Commit();
                    resposta.Foto = foto;
                    resposta.Sucesso = true;
                }
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public AlterarSenhaResposta AlterarSenha(AlterarSenhaRequisicao requisicao)
        {
            var resposta = new AlterarSenhaResposta();
            try
            {
                var pessoa = _pessoaRepositorio.ObterPor(requisicao.CodigoDaPessoa);
                var senha = Crypto.HashPassword(requisicao.NovaSenha);
                pessoa.Usuario.AlterarSenha(senha);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public RecuperarSenhaResposta RecuperarSenha(RecuperarSenhaRequisicao requisicao)
        {
            var resposta = new RecuperarSenhaResposta();
            try
            {
                var pessoa = _pessoaRepositorio.ObterPeloNomeDeUsuario(requisicao.NomeDoUsuario);
                if (pessoa != null)
                {
                    var senha = DateTime.Now.ToString("MddYYffffmmss");
                    pessoa.Usuario.AlterarSenha(Crypto.HashPassword(senha));
                    var servicoDeEmail = new ServicoDeEmail(pessoa.Usuario.NomeDeUsuario);
                    servicoDeEmail.EnviarEmail("Acesso Painel de Controle - Recuperar Senha",
                        String.Format(@"Prezado usuário, <br /><br /><br />Sua nova senha para utilização do Painel de Controle.<br /><br />O endereço é: http://www.integramedical.com.br/paineldecontrole <br />Seu login é: {0}<br />Sua senha é: {1}<br /><br /><br />Atenciosamente, <br /><br />Íntegra Medical<br />(11) 5054-9199<br />atendimento@integramedical.com.br", requisicao.NomeDoUsuario, senha));
                    _unitOfWork.Commit();
                    resposta.Sucesso = true;
                }
                else
                {
                    resposta.Erros.Add(new RegraDeNegocioBase("Usuário não encontrado!"));
                }
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ObterFotoResposta ObterFoto(ObterFotoRequisicao requisicao)
        {
            var resposta = new ObterFotoResposta();
            var pessoa = _pessoaRepositorio.ObterPor(requisicao.CodigoDaPessoa);
            if (pessoa.Foto == null)
            {
                var converter = new ImageConverter();
                var bytes = (byte[])converter.ConvertTo(Resources.ico_nophoto, typeof(byte[]));
                resposta.Foto = new MemoryStream(bytes);
            }
            else
            {
                resposta.Foto = _repositorioDeArquivos.ObterArquivo(pessoa.Foto.Nome, pessoa.Foto.DataDeUpload);
            }
            resposta.Sucesso = true;
            return resposta;
        }

        public RemoverFotoResposta RemoverFoto(RemoverFotoRequisicao requisicao)
        {
            var resposta = new RemoverFotoResposta();
            var pessoa = _pessoaRepositorio.ObterPor(requisicao.CodigoDaPessoa);
            if (pessoa.Foto != null)
            {
                _repositorioDeArquivos.RemoverArquivo(pessoa.Foto.Nome, pessoa.Foto.DataDeUpload);
                _pessoaRepositorio.RemoverFoto(pessoa.Foto);
                pessoa.Foto = null;
                _unitOfWork.Commit();
            }
            resposta.Sucesso = true;
            return resposta;
        }
    }
}