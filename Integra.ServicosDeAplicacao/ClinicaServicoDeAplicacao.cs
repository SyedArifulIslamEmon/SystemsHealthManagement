using System.Linq;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Clinica;

namespace Integra.ServicosDeAplicacao
{
    public class ClinicaServicoDeAplicacao
    {
        private readonly IClinicaRepositorio _clinicaRepositorio;
        private readonly IRepresentanteRepositorio _representanteRepositorio;
        private readonly IRepresentanteRegionalRepositorio _representanteRegionalRepositorio;
        private readonly IGerenteRepositorio _gerenteRepositorio;
        private readonly ServicoDeEmail _servicoDeEmail;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ClinicaServico _clinicaServico;

        public ClinicaServicoDeAplicacao(IClinicaRepositorio clinicaRepositorio, IRepresentanteRepositorio representanteRepositorio,
            IRepresentanteRegionalRepositorio representanteRegionalRepositorio, IGerenteRepositorio gerenteRepositorio, ServicoDeEmail servicoDeEmail,
            IProgramaRepositorio programaRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IUnitOfWork unitOfWork)
        {
            _clinicaRepositorio = clinicaRepositorio;
            _representanteRepositorio = representanteRepositorio;
            _representanteRegionalRepositorio = representanteRegionalRepositorio;
            _gerenteRepositorio = gerenteRepositorio;
            _servicoDeEmail = servicoDeEmail;
            _programaRepositorio = programaRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _unitOfWork = unitOfWork;

            _clinicaServico = new ClinicaServico(_clinicaRepositorio);
        }

        #region Gestão de Clinica
        /// <summary>
        /// Adicionar Clinica
        /// </summary>
        /// <param name="requisicao"></param>
        /// <returns></returns>
        public AdicionarClinicaResposta AdicionarClinica(AdicionarClinicaRequisicao requisicao)
        {
            var resposta = new AdicionarClinicaResposta();
            try
            {
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var gerente = _gerenteRepositorio.ObterPor(requisicao.CodigoDoGerente);
                var representante = _representanteRepositorio.ObterPor(requisicao.CodigoDoRepresentante);
                var representanteRegional = _representanteRegionalRepositorio.ObterPor(requisicao.CodigoDoRepresentanteRegional);
                resposta.Clinica = _clinicaServico.AdicionarClinica(programa, responsavel, requisicao.Nome, requisicao.RazaoSocial, requisicao.Cnpj, requisicao.InscricaoEstadual,
                    requisicao.Endereco, requisicao.Cidade, requisicao.Uf, requisicao.Telefone, requisicao.Contato, requisicao.Observacoes, requisicao.Status, requisicao.Email,
                    requisicao.ValorInfusao, requisicao.Bairro);

                resposta.Clinica.IndicarNovosPacientes = requisicao.IndicaNovosPacientes;
                resposta.Clinica.Telefone2 = requisicao.Telefone2;
                resposta.Clinica.Telefone3 = requisicao.Telefone3;
                resposta.Clinica.Gerente = gerente;
                resposta.Clinica.Representante = representante;
                resposta.Clinica.RepresentanteRegional = representanteRegional;
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        /// <summary>
        /// Alterar Clinica
        /// </summary>
        /// <param name="requisicao"></param>
        /// <returns></returns>
        public AlterarClinicaReposta AlterarClinica(AlterarClinicaRequisicao requisicao)
        {
            var resposta = new AlterarClinicaReposta();
            try
            {
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var gerente = _gerenteRepositorio.ObterPor(requisicao.CodigoDoGerente);
                var representante = _representanteRepositorio.ObterPor(requisicao.CodigoDoRepresentante);
                var representanteRegional = _representanteRegionalRepositorio.ObterPor(requisicao.CodigoDoRepresentanteRegional);

                clinica.Responsavel = responsavel;
                clinica.Nome = requisicao.Nome;
                clinica.RazaoSocial = requisicao.RazaoSocial;
                clinica.Cnpj = requisicao.Cnpj;
                clinica.InscricaoEstadual = requisicao.InscricaoEstadual;
                clinica.Endereco = requisicao.Endereco;
                clinica.Cidade = requisicao.Cidade;
                clinica.Uf = requisicao.Uf;
                clinica.Telefone = requisicao.Telefone;
                clinica.Telefone2 = requisicao.Telefone2;
                clinica.Telefone3 = requisicao.Telefone3;
                clinica.Contato = requisicao.Contato;
                clinica.Gerente = gerente;
                clinica.Representante = representante;
                clinica.RepresentanteRegional = representanteRegional;
                clinica.Observacoes = requisicao.Observacoes;
                clinica.Status = requisicao.Status;
                clinica.Email = requisicao.Email;
                clinica.IndicarNovosPacientes = requisicao.IndicaNovosPacientes;
                clinica.ValorDeInfusao = requisicao.ValorDeInfusao;
                clinica.Bairro = requisicao.Bairro;

                _unitOfWork.Commit();
                resposta.Clinica = clinica;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        /// <summary>
        /// Excluir Clinica
        /// </summary>
        /// <param name="requisicao"></param>
        /// <returns></returns>
        public ExcluirClinicaResposta ExcluirClinica(ExcluirClinicaRequisicao requisicao)
        {
            var resposta = new ExcluirClinicaResposta();

            try
            {
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                if (clinica.Documentos != null)
                {
                    foreach (var documento in clinica.Documentos)
                    {
                        repositorioDeArquivos.RemoverArquivo(documento.Nome, documento.DataDeUpload);
                    }
                }

                _clinicaRepositorio.Remover(clinica);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }
        #endregion

        public AdicionarDocumentoEmUmaClinicaResposta AdicionarDocumentoEmUmaClinica(AdicionarDocumentoEmUmaClinicaRequisicao requisicao)
        {
            var resposta = new AdicionarDocumentoEmUmaClinicaResposta();
            try
            {
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var dataUpload = SystemTime.Now;

                var documento = new ClinicaDocumentos(responsavel, dataUpload, requisicao.TipoDocumento,
                                                      requisicao.Descricao, requisicao.Nome, requisicao.DataDeVencimento,
                                                      requisicao.StatusDocumento);
                documento.DataDeVencimento = requisicao.DataDeVencimento;
                clinica.AdicionarDocumento(documento);

                var repositorioDeArquivos = new RepositorioDeArquivos();
                repositorioDeArquivos.ArmazenarArquivo(requisicao.Documento, requisicao.Nome, dataUpload);

                resposta.Documento = documento;

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public AlterarDocumentoStatusResposta AlterarDocumentoStatus(AlterarDocumentoStatusRequisicao requisicao)
        {
            var resposta = new AlterarDocumentoStatusResposta();
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var documento = clinica.Documentos.FirstOrDefault(it => it.Codigo == requisicao.CodigoDoDocumento);

            documento.StatusDocumento = requisicao.Status == "Ativo" ? DocumentoStatus.Ativo : DocumentoStatus.Inativo;

            resposta.Documento = documento;
            resposta.Sucesso = true;

            _unitOfWork.Commit();

            return resposta;
        }

        public ObterDocumentoDaClinicaResposta ObterDocumentoDaClinica(ObterDocumentoDaClinicaRequisicao requisicao)
        {
            var resposta = new ObterDocumentoDaClinicaResposta();
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var documento = clinica.Documentos.FirstOrDefault(it => it.Codigo == requisicao.CodigoDoDocumento);
            if (documento != null)
            {
                var repositorioDeArquivos = new RepositorioDeArquivos();
                resposta.Arquivo = repositorioDeArquivos.ObterArquivo(documento.Nome, documento.DataDeUpload);
                resposta.Documento = documento;
                resposta.Sucesso = resposta.Arquivo != null;
            }
            return resposta;
        }

        public ExcluirDocumentoDaClinicaResposta ExcluirDocumentoDaClinica(ExcluirDocumentoDaClinicaRequisicao requisicao)
        {
            var resposta = new ExcluirDocumentoDaClinicaResposta();
            try
            {
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var documento = clinica.Documentos.SingleOrDefault(it => it.Codigo == requisicao.CodigoDoDocumento);
                clinica.RemoverDocumento(documento);
                if (documento != null)
                {
                    var repositorioDeArquivos = new RepositorioDeArquivos();
                    repositorioDeArquivos.RemoverArquivo(documento.Nome, documento.DataDeUpload);
                    resposta.CodigoDoDocumento = documento.Codigo;
                }
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AlterarStatusResposta AlterarStatus(AlterarStatusRequisicao requisicao)
        {
            var resposta = new AlterarStatusResposta();
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            resposta.Sucesso =
                _servicoDeEmail.EnviarEmail(
                    "Painel de Controle do Programa Essencial - Pedido de alteração de status",
                    "A clínica " + clinica.Nome + ", CNPJ " + clinica.Cnpj +
                    ", deseja alterar alterar sua situação de <b>'" + clinica.Status.GetStringValue() +
                    "'</b> para <b>'" + requisicao.NovoStatus.GetStringValue() + "'</b>.");
            return resposta;
        }

        public AlterarForcaDeVendaResposta AlterarForcaDeVenda(AlterarForcaDeVendaRequisicao requisicao)
        {
            var resposta = new AlterarForcaDeVendaResposta();
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var representante = _representanteRepositorio.ObterPor(requisicao.CodigoDoRepresentante);
            var representanteRegional = _representanteRegionalRepositorio.ObterPor(requisicao.CodigoDoRepresentanteRegional);
            var gerente = _gerenteRepositorio.ObterPor(requisicao.CodigoDoGerente);

            clinica.Representante = representante;
            clinica.RepresentanteRegional = representanteRegional;
            clinica.Gerente = gerente;
            _unitOfWork.Commit();
            resposta.Sucesso = true;
            return resposta;
        }

        public AtualizarDataDeVencimentoResposta AtualizarDataDeVencimento(AtualizarDataDeVencimentoRequisicao requisicao)
        {
            var resposta = new AtualizarDataDeVencimentoResposta();
            var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
            var documento = clinica.Documentos.SingleOrDefault(it => it.Codigo == requisicao.CodigoDoDocumento);
            documento.DataDeVencimento = requisicao.DataDeVencimento;
            _unitOfWork.Commit();
            resposta.Sucesso = true;
            resposta.DataVencimento = requisicao.DataDeVencimento;
            resposta.Documento = documento;
            return resposta;
        }
    }
}
