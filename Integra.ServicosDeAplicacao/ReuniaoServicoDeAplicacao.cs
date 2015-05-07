using Integra.Dominio;
using Integra.Dominio.Base;
using Integra.Dominio.Base.RegraDeNegocio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Dominio.Servicos;
using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Reuniao;
using System.Linq;

namespace Integra.ServicosDeAplicacao
{
    public class ReuniaoServicoDeAplicacao
    {
        private readonly ReuniaoServico _reuniaoServico;
        private readonly IProgramaRepositorio _programaRepositorio;
        private readonly IReuniaoRepositorio _reuniaoRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ReuniaoServicoDeAplicacao(IProgramaRepositorio programaRepositorio, IReuniaoRepositorio reuniaoRepositorio,
            IFuncionarioRepositorio funcionarioRepositorio, IPessoaRepositorio pessoaRepositorio, IUnitOfWork unitOfWork)
        {
            _programaRepositorio = programaRepositorio;
            _reuniaoRepositorio = reuniaoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _unitOfWork = unitOfWork;
            _reuniaoServico = new ReuniaoServico(_reuniaoRepositorio);
        }

        public AdicionarReuniaoResposta AdicionarReuniao(AdicionarReuniaoRequisicao adicionarReuniaoRequisicao)
        {
            var resposta = new AdicionarReuniaoResposta();
            try
            {
                var responsavel = _funcionarioRepositorio.ObterPor(adicionarReuniaoRequisicao.CodigoDoResponsavel);
                var programa = _programaRepositorio.ObterPor(adicionarReuniaoRequisicao.CodigoDoPrograma);

                resposta.Reuniao = _reuniaoServico.AdicionarReuniao(programa, responsavel, adicionarReuniaoRequisicao.Local,
                                    adicionarReuniaoRequisicao.Assunto, adicionarReuniaoRequisicao.Realizacao, adicionarReuniaoRequisicao.Status);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AdicionarParticipantesNaReuniaoResposta AdicionarParticipantesNaReuniao(AdicionarParticipantesNaReuniaoRequisicao requisicao)
        {
            var resposta = new AdicionarParticipantesNaReuniaoResposta();
            try
            {
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                reuniao.Participantes.Clear();
                foreach (var codigosDosParticipante in requisicao.CodigosDosParticipantes)
                {
                    var participante = _pessoaRepositorio.ObterPor(codigosDosParticipante);
                    reuniao.AdicionarParticipante(participante);
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

        public AdicionarAnexoEmUmaReuniaoResposta AdicionarAnexoEmUmaReuniao(AdicionarAnexoEmUmareuniaoRequisicao requisicao)
        {
            var resposta = new AdicionarAnexoEmUmaReuniaoResposta();
            try
            {
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                var dataUpload = SystemTime.Now;

                var anexo = new Arquivo(requisicao.Descricao, requisicao.Nome, dataUpload);
                reuniao.AdicionarAnexo(anexo);

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

        public ObterAnexoDaReuniaoResposta ObterAnexoDaReuniao(ObterAnexoDaReuniaoRequisicao requisicao)
        {
            var resposta = new ObterAnexoDaReuniaoResposta();
            var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
            var anexo = reuniao.Anexos.FirstOrDefault(it => it.Codigo == requisicao.CodigoDoAnexo);
            if (anexo != null)
            {
                var repositorioDeArquivos = new RepositorioDeArquivos();
                resposta.Arquivo = repositorioDeArquivos.ObterArquivo(anexo.Nome, anexo.DataDeUpload);
                resposta.Anexo = anexo;
                resposta.Sucesso = resposta.Arquivo != null;
            }
            return resposta;
        }

        public AdicionarAtaEmUmaReuniaoResposta AdicionarAtaEmUmaReuniao(AdicionarAtaEmUmaReuniaoRequisicao requisicao)
        {
            var resposta = new AdicionarAtaEmUmaReuniaoResposta();

            var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
            var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
            try
            {
                var ata = new Ata(responsavel)
                              {
                                  Assunto = requisicao.Assunto,
                                  FinalDoPrazo = requisicao.FinalDoPrazo,
                                  InicioDoPrazo = requisicao.InicioDoPrazo,
                                  Anotacoes = requisicao.Anotacoes,
                                  Status = requisicao.Status,
                              };

                reuniao.AdicionarAta(ata);
                resposta.Ata = ata;
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirReuniaoResposta ExcluirReuniao(ExcluirReuniaoRequisicao requisicao)
        {
            var resposta = new ExcluirReuniaoResposta();

            try
            {
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                foreach (var anexo in reuniao.Anexos)
                {
                    repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);
                }


                foreach (var ata in reuniao.Atas)
                {
                    foreach (var anexo in ata.Anexos)
                    {
                        repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);
                    }
                }

                _reuniaoRepositorio.Remover(reuniao);
                _unitOfWork.Commit();
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AdicionarAnexoEmUmaAtaResposta AdicionarAnexoEmUmaAta(AdicionarAnexoEmUmaAtaRequisicao requisicao)
        {
            var resposta = new AdicionarAnexoEmUmaAtaResposta();
            try
            {
                var ata = _reuniaoRepositorio.ObterAtaDaReuniao(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                var dataDeUpload = SystemTime.Now;
                repositorioDeArquivos.ArmazenarArquivo(requisicao.Arquivo, requisicao.NomeDoArquivo, dataDeUpload);

                var anexo = new Arquivo(requisicao.Descricao, requisicao.NomeDoArquivo, dataDeUpload);
                ata.Anexos.Add(anexo);
                _unitOfWork.Commit();
                resposta.Anexo = anexo;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public ObterAnexoDeUmaAtaResposta ObterAnexoDeUmaAta(ObterAnexoDeUmaAtaRequisicao requisicao)
        {
            var resposta = new ObterAnexoDeUmaAtaResposta();
            try
            {
                var anexo = _reuniaoRepositorio.ObterAnexoDeUmaAta(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta, requisicao.CodigoDoAnexo);
                var repositorioDeArquivos = new RepositorioDeArquivos();
                resposta.Anexo = anexo;
                resposta.Arquivo = repositorioDeArquivos.ObterArquivo(anexo.Nome, anexo.DataDeUpload);
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public ExcluirAnexoDeUmaAtaResposta ExcluirAnexoDeUmaAta(ExcluirAnexoDeUmaAtaRequisicao requisicao)
        {
            var resposta = new ExcluirAnexoDeUmaAtaResposta();
            try
            {
                var ata = _reuniaoRepositorio.ObterAtaDaReuniao(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta);
                var anexo = _reuniaoRepositorio.ObterAnexoDeUmaAta(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta, requisicao.CodigoDoAnexo);
                ata.Anexos.Remove(anexo);
                _unitOfWork.Commit();
                var repositorioDeArquivos = new RepositorioDeArquivos();
                resposta.Anexo = anexo;
                repositorioDeArquivos.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);

                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }

            return resposta;
        }

        public AlterarReuniaoReposta AlterarReuniao(AlterarReuniaoRequisicao requisicao)
        {
            var resposta = new AlterarReuniaoReposta();
            try
            {
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                reuniao.Status = requisicao.Status;
                reuniao.Realizacao = requisicao.Realizacao;
                reuniao.Responsavel = responsavel;
                reuniao.Assunto = requisicao.Assunto;
                reuniao.Local = requisicao.Local;
                _unitOfWork.Commit();
                resposta.Reuniao = reuniao;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public ExcluirAnexoDaReuniaoResposta ExcluirAnexoDaReuniao(ExcluirAnexoDaReuniaoRequisicao requisicao)
        {
            var resposta = new ExcluirAnexoDaReuniaoResposta();
            try
            {
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                var arquivo = reuniao.Anexos.SingleOrDefault(it => it.Codigo == requisicao.CodigoDoAnexo);
                reuniao.RemoverAnexo(arquivo);
                if (arquivo != null)
                {
                    var repositorioDeArquivos = new RepositorioDeArquivos();
                    repositorioDeArquivos.RemoverArquivo(arquivo.Nome, arquivo.DataDeUpload);
                    resposta.CodigoDoAnexo = arquivo.Codigo;
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

        public ExcluirAtaDaReuniaoResposta ExcluirAtaDaReuniao(ExcluirAtaDaReuniaoRequisicao requisicao)
        {
            var resposta = new ExcluirAtaDaReuniaoResposta();
            try
            {
                var reuniao = _reuniaoRepositorio.ObterPor(requisicao.CodigoDaReuniao);
                var ata = _reuniaoRepositorio.ObterAtaDaReuniao(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta);
                reuniao.RemoverAta(ata);
                var repositorioDeArquivo = new RepositorioDeArquivos();
                foreach (var anexo in ata.Anexos)
                {
                    repositorioDeArquivo.RemoverArquivo(anexo.Nome, anexo.DataDeUpload);
                }
                _unitOfWork.Commit();
                resposta.CodigoDaAta = ata.Codigo;
                resposta.Sucesso = true;
            }
            catch (RegraException regraException)
            {
                resposta.Erros = regraException.Erros;
            }
            return resposta;
        }

        public AlterarAtaEmUmaReuniaoResposta AlterarAtaEmUmaReuniao(AlterarAtaEmUmaReuniaoRequisicao requisicao)
        {
            var resposta = new AlterarAtaEmUmaReuniaoResposta();
            try
            {
                var ata = _reuniaoRepositorio.ObterAtaDaReuniao(requisicao.CodigoDaReuniao, requisicao.CodigoDaAta);
                var responsavel = _funcionarioRepositorio.ObterPor(requisicao.CodigoDoResponsavel);
                ata.Anotacoes = requisicao.Anotacoes;
                ata.Assunto = requisicao.Assunto;
                ata.FinalDoPrazo = requisicao.FinalDoPrazo;
                ata.InicioDoPrazo = requisicao.InicioDoPrazo;
                ata.Responsavel = responsavel;
                ata.Status = requisicao.Status;
                _unitOfWork.Commit();
                resposta.Ata = ata;
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