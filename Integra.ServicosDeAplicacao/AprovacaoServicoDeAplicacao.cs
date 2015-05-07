using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Aprovacao;

namespace Integra.ServicosDeAplicacao
{
    public class AprovacaoServicoDeAplicacao
    {
        private readonly IGrupoRepositorio _grupoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IAprovacaoRepositorio _aprovacaoRepositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProgramaRepositorio _programaRepositorio;

        public AprovacaoServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IGrupoRepositorio grupoRepositorio, IPessoaRepositorio pessoaRepositorio,
            IAprovacaoRepositorio aprovacaoRepositorio, IUnitOfWork unitOfWork)
        {
            _grupoRepositorio = grupoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _aprovacaoRepositorio = aprovacaoRepositorio;
            _programaRepositorio = programaRepositorio;
            _unitOfWork = unitOfWork;
        }

        public AdicionarAprovacaoResposta AdicionarAprovacao(AdicionarAprovacaoRequisicao requisicao)
        {
            var resposta = new AdicionarAprovacaoResposta();
            var repositorioDeArquivos = new RepositorioDeArquivos();
            var dataDeUpload = SystemTime.Now;
            try
            {
                var grupo = _grupoRepositorio.ObterPor(requisicao.CodigoDoGrupoResponsavel);
                var programa = _programaRepositorio.ObterPor(requisicao.CodigoDoPrograma);
                var anexo = new Arquivo(requisicao.Descricao, requisicao.NomeDoAnexo, dataDeUpload);
                var aprovacao = new Aprovacao
                                    {
                                        Anexo = anexo,
                                        Status = StatusDaAprovacao.Pendente,
                                        Tipo = requisicao.Tipo,
                                        GrupoResponsavel = grupo,
                                        Titulo = requisicao.Titulo,
                                        Programa = programa
                                    };

                _aprovacaoRepositorio.Adicionar(aprovacao);

                repositorioDeArquivos.ArmazenarArquivo(requisicao.Arquivo, requisicao.NomeDoAnexo, dataDeUpload);

                _unitOfWork.Commit();
                resposta.Aprovacao = aprovacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                repositorioDeArquivos.RemoverArquivo(requisicao.NomeDoAnexo, dataDeUpload);
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }


        public IList<Aprovacao> ObterAprovacoesDoTipo(TipoDaAprovacao tipo)
        {
            return _aprovacaoRepositorio.ObterAprovacoesDoTipo(tipo);
        }

        public AprovarDocumentoReposta AprovarDocumento(AprovarDocumentoRequisicao requisicao)
        {
            var resposta = new AprovarDocumentoReposta();
            try
            {
                var aprovacao = _aprovacaoRepositorio.ObterPor(requisicao.CodigoDaAprovacao);
                var responsavel = _pessoaRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                if (requisicao.Aprovar)
                    aprovacao.AprovadoPor(responsavel);
                else
                    aprovacao.ReprovadoPor(responsavel);
                _unitOfWork.Commit();
                resposta.Aprovacao = aprovacao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public ObterArquivoDaAprovacaoResposta ObterArquiviDaAprovacao(ObterArquivoDaAprovacaoRequisicao requisicao)
        {
            var resposta = new ObterArquivoDaAprovacaoResposta();
            try
            {
                var aprovacao = _aprovacaoRepositorio.ObterPor(requisicao.CodigoDaAprovacao);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                resposta.Anexo = aprovacao.Anexo;
                resposta.Arquivo = repositorioDeArquivos.ObterArquivo(aprovacao.Anexo.Nome, aprovacao.Anexo.DataDeUpload);
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public ExcluirAprovacaoResposta ExcluirAprovacao(ExcluirAprovacaoRequisicao requisicao)
        {
            var resposta = new ExcluirAprovacaoResposta();
            try
            {
                var aprovacao = _aprovacaoRepositorio.ObterPor(requisicao.CodigoDaAprovacao);
                var anexo = aprovacao.Anexo;
                _aprovacaoRepositorio.Remover(aprovacao);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);
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