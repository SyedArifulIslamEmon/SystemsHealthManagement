using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Equipe;

namespace Integra.ServicosDeAplicacao
{
    public class EquipeServicoDeAplicacao
    {
        private readonly IEquipeRepositorio _equipeRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EquipeServico _equipeServico;
        private readonly IProgramaRepositorio _programaRepositorio;

        public EquipeServicoDeAplicacao(IEquipeRepositorio equipeRepositorio, IProgramaRepositorio programaRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IUnitOfWork unitOfWork)
        {
            _equipeRepositorio = equipeRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _programaRepositorio = programaRepositorio;
            _equipeServico = new EquipeServico();
            _unitOfWork = unitOfWork;
        }


        public AdicionarMembrosNaEquipeResposta AdicionarMembrosNaEquipe(AdicionarMembrosNaEquipeRequisicao requisicao)
        {
            var resposta = new AdicionarMembrosNaEquipeResposta();
            try
            {
                var equipe = _equipeRepositorio.ObterPor(requisicao.CodigoDaEquipe);
                equipe.MenbrosDaEquipe.Clear();
                foreach (var codigo in requisicao.CodigosDosFuncionarios)
                {
                    var funcionario = _funcionarioRepositorio.ObterPor(codigo);
                    _equipeServico.AdicionarMembroNaEquipe(equipe, funcionario);
                }
                _unitOfWork.Commit();
                resposta.Equipe = equipe;
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