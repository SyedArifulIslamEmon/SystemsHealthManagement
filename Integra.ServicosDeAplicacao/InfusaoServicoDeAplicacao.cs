using System;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.ServicosDeAplicacao.Mensagens.Infusao;

namespace Integra.ServicosDeAplicacao
{
    public class InfusaoServicoDeAplicacao
    {
        private readonly InfusaoServico _infusaoServico;
        private readonly IInfusaoRepositorio _infusaoRepositorio;
        private readonly IClinicaRepositorio _clinicaRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public InfusaoServicoDeAplicacao() { }

        public InfusaoServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IInfusaoRepositorio infusaoRepositorio, IClinicaRepositorio clinicaRepositorio, IFuncionarioRepositorio funcionarioRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _infusaoRepositorio = infusaoRepositorio;
            _clinicaRepositorio = clinicaRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _unitOfWork = unitOfWork;

            _infusaoServico = new InfusaoServico(_infusaoRepositorio);
        }

        public AdicionarInfusaoResposta AdicionarInfusao(AdicionarInfusaoRequisicao requisicao)
        {
            var resposta = new AdicionarInfusaoResposta();
            try
            {
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);

                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);

                resposta.Infusao = _infusaoServico.AdicionarInfusao(clinica, requisicao.Localizador, requisicao.Cpf,
                                                                    requisicao.DataInfusao, requisicao.DataCadastro,
                                                                    requisicao.StatusDaInfusao, responsavel, programa);

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public CancelarInfusaoResposta CancelarInfusao(CancelarInfusaoRequisicao requisicao)
        {
            var resposta = new CancelarInfusaoResposta();
            try
            {
                var clinica = _clinicaRepositorio.ObterPor(requisicao.CodigoDaClinica);
                var infusao = _infusaoRepositorio.ObterPorLocalizacao(clinica, requisicao.Localizador, requisicao.Cpf);

                infusao.StatusDaInfusao = requisicao.StatusDaInfusao;

                _infusaoRepositorio.Atualizar(infusao);

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
