using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Solicitacao;

namespace Integra.ServicosDeAplicacao
{
    public class SolicitacaoServicoDeAplicacao
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly ISolicitacaoRepositorio _solicitacaoRepositorio;
        private readonly ITipoDaSolicitacaoRepositorio _tipoDaSolicitacaoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SolicitacaoServico _solicitacaoServico;
        private readonly IProgramaRepositorio _programaRepositorio;

        public SolicitacaoServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IClienteRepositorio clienteRepositorio, IFuncionarioRepositorio funcionarioRepositorio,
            ISolicitacaoRepositorio solicitacaoRepositorio, ITipoDaSolicitacaoRepositorio tipoDaSolicitacaoRepositorio, 
            IPessoaRepositorio pessoaRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _clienteRepositorio = clienteRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _solicitacaoRepositorio = solicitacaoRepositorio;
            _tipoDaSolicitacaoRepositorio = tipoDaSolicitacaoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _unitOfWork = unitOfWork;
            _solicitacaoServico = new SolicitacaoServico();
        }

        public ObterUmProtocoloResposta ObterUmProtocolo(ObterUmProtocoloRequisicao requisicao)
        {
            var resposta = new ObterUmProtocoloResposta();
            try
            {
                resposta.Protocolo = _solicitacaoServico.GerarUmProtocolo();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AbrirUmaSolicitacaoResposta AbrirUmaSolicitacao(AbrirUmaSolicitacaoRequisicao requisicao)
        {
            var resposta = new AbrirUmaSolicitacaoResposta();
            try
            {
                var tipoDaSolicitacao = _tipoDaSolicitacaoRepositorio.ObterPor(requisicao.CodigoDoTipoDaSolicitacao);
                var responsavel = _pessoaRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                var solicitacao = _solicitacaoServico.RealizarAbertura(tipoDaSolicitacao, responsavel, requisicao.Protocolo, requisicao.Descricao, programa);
                _solicitacaoRepositorio.Adicionar(solicitacao);
                _unitOfWork.Commit();
                resposta.Solicitacao = solicitacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public RealizarAnalizeDeUmaSolicitacaoResposta RealizarAnalizeDeUmaSolicitacao(RealizarAnalizeDeUmaSolicitacaoRequisicao requisicao)
        {
            var resposta = new RealizarAnalizeDeUmaSolicitacaoResposta();

            try
            {
                var solicitacao = _solicitacaoRepositorio.ObterPor(requisicao.CodigoDaSolicitacao);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                solicitacao = _solicitacaoServico.RealizarAnalise(solicitacao, responsavel, requisicao.ClientePrecisaAprovar,
                                                     requisicao.Atividade, requisicao.Custo, requisicao.DiasParaEntrega, requisicao.Analise, programa);
                _unitOfWork.Commit();
                resposta.Solicitacao = solicitacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public RealizarAprovacaoDeUmaSolicitacaoResposta RealizarAprovacaoDeUmaSolicitacao(RealizarAprovacaoDeUmaSolicitacaoRequisicao requisicao)
        {
            var resposta = new RealizarAprovacaoDeUmaSolicitacaoResposta();
            try
            {
                var solicitacao = _solicitacaoRepositorio.ObterPor(requisicao.CodigoDaSolicitacao);
                var responsavel = _clienteRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                solicitacao = _solicitacaoServico.RealizarAprovacao(solicitacao, responsavel, requisicao.Aprovado,
                                                       requisicao.Observacoes, programa);
                _unitOfWork.Commit();
                resposta.Solicitacao = solicitacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public RealizarProcessoDeUmaSolicitacaoResposta RealizarProcessoDeUmaSolicitacao(RealizarProcessoDeUmaSolicitacaoRequisicao requisicao)
        {
            var resposta = new RealizarProcessoDeUmaSolicitacaoResposta();
            try
            {
                var solicitacao = _solicitacaoRepositorio.ObterPor(requisicao.CodigoDaSolicitacao);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                solicitacao = _solicitacaoServico.RealizarProcesso(solicitacao, responsavel, requisicao.Solucao, requisicao.Observacoes, programa);
                _unitOfWork.Commit();
                resposta.Solicitacao = solicitacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public RealizarEntregaDeUmaSolicitacaoResposta RealizarEntregaDeUmaSolicitacao(RealizarEntregaDeUmaSolicitacaoRequisicao requisicao)
        {
            var resposta = new RealizarEntregaDeUmaSolicitacaoResposta();
            try
            {
                var solicitacao = _solicitacaoRepositorio.ObterPor(requisicao.CodigoDaSolicitacao);
                var responsavel = _clienteRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                solicitacao = _solicitacaoServico.RealizarEntrega(solicitacao, responsavel, requisicao.Aceita, requisicao.Observacoes, programa);
                _unitOfWork.Commit();
                resposta.Solicitacao = solicitacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirSolicitacaoResposta ExcluirSolicitacao(ExcluirSolicitacaoRequisicao requisicao)
        {
            var resposta = new ExcluirSolicitacaoResposta();

            try
            {
                var solicitacao = _solicitacaoRepositorio.ObterPor(requisicao.CodigoDaSolicitacao);
                _solicitacaoRepositorio.Remover(solicitacao);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }
    }
}