using Integra.Dominio.Base;
using Integra.Dominio.RegrasDeNegocio.Solicitacao;

namespace Integra.Dominio.Servicos
{
    public class SolicitacaoServico
    {
        public string GerarUmProtocolo()
        {
            return SystemTime.Now.ToString("ddMMyyyyHHmmssffff");
        }

        public Solicitacao RealizarAbertura(TipoDaSolicitacao tipoDaSolicitacao, Pessoa responsavel, string protocolo, string descricao, Programa programa)
        {
            var solicitacao = new Solicitacao { Situacao = SituacaoDaSolicitacao.Analise };
            var abertura = new AberturaDeSolicitacao
                               {
                                   DataDaAbertura = SystemTime.Now,
                                   Protocolo = protocolo,
                                   Responsavel = responsavel,
                                   Solicitacao = descricao,
                                   Tipo = tipoDaSolicitacao,
                                   Programa = programa
                               };
            solicitacao.Abertura = abertura;
            return solicitacao;
        }

        public Solicitacao RealizarAnalise(Solicitacao solicitacao, Funcionario responsavel, bool clientePrecisaAprovar, string atividade, decimal custo, int diasParaEntrega, string analiseRealizada, Programa programa)
        {
            if (solicitacao.Situacao == SituacaoDaSolicitacao.Analise)
            {
                if (responsavel == null)
                    solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.SomenteUmFuncionaroPodeAnalisar);
                var analise = new AnaliseDeSolicitacao
                                  {
                                      Atividade = atividade,
                                      Custo = custo,
                                      Analise = analiseRealizada,
                                      DataDaAnalise = SystemTime.Now,
                                      DiasParaEntrega = diasParaEntrega,
                                      Responsavel = responsavel,
                                      Programa = programa
                                  };
                solicitacao.Situacao = clientePrecisaAprovar
                                           ? SituacaoDaSolicitacao.Aprovacao
                                           : SituacaoDaSolicitacao.Processo;
                solicitacao.Analise = analise;
                return solicitacao;
            }
            solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.DeveEstarComSituacaoEmAnalise);
            return solicitacao;
        }

        public Solicitacao RealizarAprovacao(Solicitacao solicitacao, Cliente responsavel, bool aprovado, string observacoes, Programa programa)
        {
            if (solicitacao.Situacao == SituacaoDaSolicitacao.Aprovacao)
            {
                if (responsavel == null)
                    solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.SomenteUmClientePodeAprovar);
                var aprovacao = new AprovacaoDeSolicitacao
                                    {
                                        Aprovado = aprovado,
                                        DataDeAprovacao = SystemTime.Now,
                                        Observacoes = observacoes,
                                        Responsavel = responsavel,
                                        Programa = programa
                                    };
                solicitacao.Aprovacao = aprovacao;
                solicitacao.Situacao = aprovado ? SituacaoDaSolicitacao.Processo : SituacaoDaSolicitacao.Cancelado;
                return solicitacao;
            }
            solicitacao.AdicionarRegraQuebrada(RegrasDeNegocioSolicitacao.DeveEstarComSituacaoParaAprovacao);
            return solicitacao;
        }

        public Solicitacao RealizarProcesso(Solicitacao solicitacao, Funcionario responsavel, string solucao, string observacoes, Programa programa)
        {
            if (solicitacao.Situacao == SituacaoDaSolicitacao.Processo)
            {
                if (responsavel == null)
                    solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.SomenteFuncionarioPodeDarProcesso);
                var processo = new ProcessoDaSolicitacao
                                   {
                                       DataDoProcesso = SystemTime.Now,
                                       Observacoes = observacoes,
                                       Solucao = solucao,
                                       Responsavel = responsavel,
                                       Programa = programa
                                   };
                solicitacao.Processo = processo;
                solicitacao.Situacao = SituacaoDaSolicitacao.Entregue;
                return solicitacao;
            }
            solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.DeveEstarComSituacaoEmProcesso);
            return solicitacao;
        }

        public Solicitacao RealizarEntrega(Solicitacao solicitacao, Cliente responsavel, bool aceita, string observacoes, Programa programa)
        {
            if (solicitacao.Situacao == SituacaoDaSolicitacao.Entregue)
            {
                if (responsavel == null)
                    solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.SomenteClientePodeAceitarEntrega);

                var entrega = new EntregaDaSolicitacao
                                  {
                                      Aceita = aceita,
                                      DataDoAceite = SystemTime.Now,
                                      Observacoes = observacoes,
                                      Responsavel = responsavel,
                                      Programa = programa
                                  };
                solicitacao.Entrega = entrega;
                solicitacao.Situacao = entrega.Aceita
                                           ? SituacaoDaSolicitacao.Finalizado
                                           : SituacaoDaSolicitacao.Cancelado;
                return solicitacao;
            }
            solicitacao.RegraQuebrada(RegrasDeNegocioSolicitacao.DeveEstarComSituacaoEntrege);
            return solicitacao;
        }
    }
}