using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Fatura;

namespace Integra.ServicosDeAplicacao
{
    public class FaturaServicoDeAplicacao
    {
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IFaturaRepositorio _faturaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FaturaServico _faturaServico;

        public FaturaServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IFaturaRepositorio faturaRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _faturaRepositorio = faturaRepositorio;
            _unitOfWork = unitOfWork;
            _faturaServico = new FaturaServico(_faturaRepositorio);
        }

        public AdicionarFaturaResposta AdicionarFatura(AdicionarFaturaRequisicao requisicao)
        {
            var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
            var resposta = new AdicionarFaturaResposta();
            try
            {
                resposta.Fatura = _faturaServico.AdicionarFatura(programa, requisicao.Descricao, requisicao.Tipo, requisicao.Status, requisicao.TipoDoDocumento,
                    requisicao.Valor, requisicao.NumeroDoDocumento, requisicao.Data);

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AlterarFaturaResposta AlterarFatura(AlterarFaturaRequisicao requisicao)
        {
            var fatura = _faturaRepositorio.ObterPor(requisicao.CodigoDaFatura);
            var resposta = new AlterarFaturaResposta();
            try
            {
                resposta.Fatura = _faturaServico.AlterarFatura(fatura, requisicao.Descricao, requisicao.Tipo, requisicao.TipoDoDocumento,
                    requisicao.Data, requisicao.NumeroDoDocumento, requisicao.Status, requisicao.Valor);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirFaturaResposta ExcluirFatura(ExcluirFaturaRequisicao requisicao)
        {
            var resposta = new ExcluirFaturaResposta();

            try
            {
                var fatura = _faturaRepositorio.ObterPor(requisicao.CodigoDaFatura);
                _faturaRepositorio.Remover(fatura);
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