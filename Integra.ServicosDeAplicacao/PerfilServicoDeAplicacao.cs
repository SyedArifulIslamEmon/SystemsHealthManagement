using Integra.Dominio;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Perfil;
using System.Linq;

namespace Integra.ServicosDeAplicacao
{
    public class PerfilServicoDeAplicacao
    {
        private readonly IPerfilRepositorio _perfilRepositorio;
        private readonly IGrupoRepositorio _grupoRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuloRepositorio _moduloRepositorio;
        private readonly PerfilServico _perfilServico;

        public PerfilServicoDeAplicacao(IPerfilRepositorio perfilRepositorio, IGrupoRepositorio grupoRepositorio,
            IUnitOfWork unitOfWork, IModuloRepositorio moduloRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
            _grupoRepositorio = grupoRepositorio;
            _unitOfWork = unitOfWork;
            _moduloRepositorio = moduloRepositorio;
            _perfilServico = new PerfilServico(_perfilRepositorio);
        }

        public AdicionarPerfilResposta AdicionarPerfil(AdicionarPerfilRequisicao adicionarPerfilRequisicao)
        {
            var adicionarPerfilResposta = new AdicionarPerfilResposta();
            try
            {
                var grupo = _grupoRepositorio.ObterPor(adicionarPerfilRequisicao.CodigoDoGrupo);
                var modulosPermitidos = adicionarPerfilRequisicao.CodigosDosModulosPermitidos
                    .Select(codigoDoModulo => _moduloRepositorio.ObterPor(codigoDoModulo)).ToList();
                adicionarPerfilResposta.Perfil = _perfilServico.AdicionarPerfil(adicionarPerfilRequisicao.Nome, grupo, modulosPermitidos);
                _unitOfWork.Commit();
                adicionarPerfilResposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                adicionarPerfilResposta.Erros = regraException.Erros;
            }

            return adicionarPerfilResposta;
        }

        public EditarPerfilResposta AlterarPerfil(Perfil perfil)
        {
            var editarPerfilResposta = new EditarPerfilResposta();
            _unitOfWork.Commit();
            editarPerfilResposta.Sucesso = true;
            return editarPerfilResposta;
        }

    }
}