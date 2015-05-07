using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.ServicosContratados;

namespace Integra.ServicosDeAplicacao
{
    public class ServicosContratadosServicoDeAplicacao
    {
        private readonly ServicosContratadosServico _servicosContratadosServico;
        private readonly IServicosContratadosRepositorio _servicosContratadosRepositorio;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ServicosContratadosServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IServicosContratadosRepositorio servicosContratadosRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _servicosContratadosRepositorio = servicosContratadosRepositorio;
            _unitOfWork = unitOfWork;
            _servicosContratadosServico = new ServicosContratadosServico(_servicosContratadosRepositorio);
        }

        public AdicionarServicosContratadosResposta AdicionarServicosContratados(AdicionarServicosContratadosRequisicao requisicao)
        {
            var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
            var resposta = new AdicionarServicosContratadosResposta();
            try
            {
                resposta.ServicosContratados = _servicosContratadosServico.AdicionarServico(programa, requisicao.Nome, requisicao.Descricao, requisicao.Quantidade, requisicao.Observacoes, requisicao.DataContratacao, SystemTime.Now);

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AlterarServicosContratadosResposta AlterarServicosContratados(AlterarServicosContratadosRequisicao requisicao)
        {
            var servicosContatados = _servicosContratadosRepositorio.ObterPor(requisicao.CodigoSevicoContratado);
            var resposta = new AlterarServicosContratadosResposta();
            try
            {
                resposta.ServicosContratados = _servicosContratadosServico.AlterarServico(servicosContatados, requisicao.Nome, requisicao.Descricao, requisicao.Quantidade,
                    requisicao.Observacoes, requisicao.DataContratacao);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirServicosContratadosResposta ExcluirServicosContratados(ExcluirServicosContratadosRequisicao requisicao)
        {
            var resposta = new ExcluirServicosContratadosResposta();

            try
            {
                var servicosContratados = _servicosContratadosRepositorio.ObterPor(requisicao.CodigoServicoContratado);
                _servicosContratadosRepositorio.Remover(servicosContratados);
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
