using Integra.Dominio;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.ServicosDeAplicacao.Mensagens.Tratamento;

namespace Integra.ServicosDeAplicacao
{
    public class TratamentoServicoDeAplicacao
    {
        private readonly ITratamentoRepositorio _tratamentoRepositorio;
        private readonly IGrupoRepositorio _grupoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TratamentoServicoDeAplicacao(
            ITratamentoRepositorio tratamentoRepositorio, 
            IProgramaRepositorio programaRepositorio,
            IUnitOfWork unitOfWork, 
            IPessoaRepositorio pessoaRepositorio, 
            IGrupoRepositorio grupoRepositorio)
        {
            _tratamentoRepositorio = tratamentoRepositorio;
            _programaRepositorio = programaRepositorio;
            _unitOfWork = unitOfWork;
            _pessoaRepositorio = pessoaRepositorio;
            _grupoRepositorio = grupoRepositorio;
        }

        public AdicionarTratamentoResposta AdicionarTratamento(AdicionarTratamentoRequisicao requisicao)
        {
            var resposta = new AdicionarTratamentoResposta();
            try
            {
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                var grupo = _grupoRepositorio.ObterPor(requisicao.CodigoDoGrupoResponsavel);
                var tratamento = new Tratamento
                {
                    Programa = programa,
                    DataSolicitacao = requisicao.DataSolicitacao,
                    Ifx = requisicao.Ifx,
                    Medico = requisicao.Medico,
                    Representante = requisicao.Representante,
                    MotivoSolicitacao = requisicao.MotivoSolicitacao,
                    Status = StatusDoTratamento.Aberto,
                    GrupoResponsavel = grupo
                };

                _tratamentoRepositorio.Adicionar(tratamento);

                _unitOfWork.Commit();
                resposta.Tratamento = tratamento;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirTratamentoResposta ExcluirTratamento(ExcluirTratamentoRequisicao requisicao)
        {
            var resposta = new ExcluirTratamentoResposta();

            try
            {
                var tratamento = _tratamentoRepositorio.ObterPor(requisicao.CodigoDoTratamento);

                _tratamentoRepositorio.Remover(tratamento);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AprovarTratamentoReposta AprovarTratamento(AprovarTratamentoRequisicao requisicao)
        {
            var resposta = new AprovarTratamentoReposta();
            try
            {
                var tratamento = _tratamentoRepositorio.ObterPor(requisicao.CodigoDoTratamento);
                var responsavel = _pessoaRepositorio.ObterPor(requisicao.CodigoDoResponsavel);

                if (requisicao.Aprovar)
                    tratamento.AprovadoPor(responsavel, requisicao.Observacoes);
                else
                    tratamento.ReprovadoPor(responsavel, requisicao.Observacoes);

                _unitOfWork.Commit();
                resposta.Tratamento = tratamento;
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
