using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Programa;
using System.Linq;

namespace Integra.ServicosDeAplicacao
{
    public class ProgramaServicoDeAplicacao
    {
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProgramaServico _programaServico;

        public ProgramaServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _unitOfWork = unitOfWork;
            _programaServico = new ProgramaServico(_programaRepositorio);
        }

        public AdicionarProgramaResposta AdicionarPrograma(AdicionarProgramaRequisicao adicionarProgramaRequisicao)
        {
            var adicionarProgramaResposta = new AdicionarProgramaResposta();
            try
            {
                
                adicionarProgramaResposta.Programa = _programaServico.AdicionarPrograma(adicionarProgramaRequisicao.Nome, adicionarProgramaRequisicao.Descricao, adicionarProgramaRequisicao.Identificador, adicionarProgramaRequisicao.CodigoAuxiliar);
                _unitOfWork.Commit();
                adicionarProgramaResposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                adicionarProgramaResposta.Erros = regraException.Erros;
            }
            
            return adicionarProgramaResposta;
        }
    }
}
