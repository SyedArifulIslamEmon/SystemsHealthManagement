using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Treinamento;

namespace Integra.ServicosDeAplicacao
{
    public class TreinamentoServicoDeAplicacao
    {
        private readonly TreinamentoServico _treinamentoServico;
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TreinamentoServicoDeAplicacao(
            ITreinamentoRepositorio treinamentoRepositorio,
            IProgramaRepositorio programaRepositorio,
            IFuncionarioRepositorio funcionarioRepositorio,
            IPessoaRepositorio pessoaRepositorio,
            IUnitOfWork unitOfWork)
        {
            _treinamentoRepositorio = treinamentoRepositorio;
            _programaRepositorio = programaRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _unitOfWork = unitOfWork;
            _treinamentoServico = new TreinamentoServico(_treinamentoRepositorio);
        }

        public AdicionarTreinamentoResposta AdicionarTreinamento(AdicionarTreinamentoRequisicao requisicao)
        {
            var resposta = new AdicionarTreinamentoResposta();
            try
            {
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);

                resposta.Treinamento = _treinamentoServico.AdicionarTreinamento(programa, requisicao.DataRealizacao,
                    responsavel, requisicao.Local, requisicao.Titulo, requisicao.Descricao);

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AdicionarParticipantesNoTreinamentoResposta AdicionarParticipantesNoTreinamento(AdicionarParticipantesNoTreinamentoRequisicao requisicao)
        {
            var resposta = new AdicionarParticipantesNoTreinamentoResposta();
            try
            {
                var treinamento = _treinamentoRepositorio.ObterPor(requisicao.CodigoDoTreinamento);
                treinamento.Participantes.Clear();

                foreach (var codigosDosParticipante in requisicao.CodigosDosParticipantes)
                {
                    var participante = _pessoaRepositorio.ObterPor(codigosDosParticipante);
                    treinamento.AdicionarParticipante(participante);
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

        public AdicionarAnexoEmTreinamentoResposta AdicionarAnexoEmTreinamento(AdicionarAnexoEmTreinamentoRequisicao requisicao)
        {
            var resposta = new AdicionarAnexoEmTreinamentoResposta();
            try
            {
                var treinamento = _treinamentoRepositorio.ObterPor(requisicao.CodigoDoTreinamento);
                var dataUpload = SystemTime.Now;
                var anexo = new Arquivo(requisicao.Descricao, requisicao.Nome, dataUpload);
                treinamento.AdicionarAnexo(anexo);

                var repositorioDeArquivos = new RepositorioDeArquivos();
                repositorioDeArquivos.ArmazenarArquivo(requisicao.Arquivo, requisicao.Nome, dataUpload);
                resposta.Anexo = anexo;

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public ObterAnexoDoTreinamentoResposta ObterAnexoDoTreinamento(ObterAnexoDoTreinamentoRequisicao requisicao)
        {
            var resposta = new ObterAnexoDoTreinamentoResposta();
            var anexo = _treinamentoRepositorio.ObterAnexoDoTreinamento(requisicao.CodigoDoTreinamento, requisicao.CodigoDoAnexo);
            var repositorioDeArquivos = new RepositorioDeArquivos();
            resposta.Arquivo = repositorioDeArquivos.ObterArquivo(anexo.Nome, anexo.DataDeUpload);
            resposta.Anexo = anexo;
            resposta.Sucesso = true;
            return resposta;
        }

        public AlterarTreinamentoResposta AlterarTreinamento(AlterarTreinamentoRequisicao requisicao)
        {
            var resposta = new AlterarTreinamentoResposta();
            try
            {
                var treinamento = _treinamentoRepositorio.ObterPor(requisicao.CodigoDoTreinamento);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);

                resposta.Treinamento = _treinamentoServico.AlterarTreinamento(treinamento, requisicao.DataRealizacao,
                                                                              responsavel, requisicao.Local,
                                                                              requisicao.Titulo, requisicao.Descricao);

                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirTreinamentoResposta ExcluirTreinamento(ExcluirTreinamentoRequisicao requisicao)
        {
            var resposta = new ExcluirTreinamentoResposta();

            try
            {
                var treinamento = _treinamentoRepositorio.ObterPor(requisicao.CodigoDoTreinamento);
                var repositorioDeArquivos = new RepositorioDeArquivos();

                foreach (var anexo in treinamento.Anexos)
                {
                    repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);
                }
                
                _treinamentoRepositorio.Remover(treinamento);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirAnexoDoTreinamentoResposta ExcluirAnexoDoTreinamento(ExcluirAnexoDoTreinamentoRequisicao requisicao)
        {
            var resposta = new ExcluirAnexoDoTreinamentoResposta();

            try
            {
                var treinamento = _treinamentoRepositorio.ObterPor(requisicao.CodigoDoTreinamento);
                var anexo = _treinamentoRepositorio.ObterAnexoDoTreinamento(requisicao.CodigoDoTreinamento, requisicao.CodigoDoAnexo);
                treinamento.RemoverAnexo(anexo);

                var repositorioDeArquivos = new RepositorioDeArquivos();
                repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);

                resposta.CodigoDoAnexo = anexo.Codigo;
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
