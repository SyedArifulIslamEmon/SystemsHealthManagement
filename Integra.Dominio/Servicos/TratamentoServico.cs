using System;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class TratamentoServico
    {
        private readonly ITratamentoRepositorio _tratamentoRepositorio;

        public TratamentoServico(ITratamentoRepositorio tratamentoRepositorio)
        {
            _tratamentoRepositorio = tratamentoRepositorio;
        }

        public Tratamento AdicionarTratamento(
            Programa programa, 
            DateTime dataSolicitacao, 
            string ifx,
            string medico, 
            string representante,
            string motivoSolicitacao)
        {
            var tratamento = new Tratamento()
            {
                Programa = programa,
                DataSolicitacao = dataSolicitacao,
                Ifx = ifx,
                Medico = medico,
                Representante = representante,
                MotivoSolicitacao = motivoSolicitacao
            };

            _tratamentoRepositorio.Adicionar(tratamento);
            return tratamento;
        }

        public Tratamento AlterarTratamento(Tratamento tratamento, 
            string ifx,
            string medico,
            string representante,
            string motivoSolicitacao)
        {
            tratamento.Ifx = ifx;
            tratamento.Medico = medico;
            tratamento.Representante = representante;
            tratamento.MotivoSolicitacao = motivoSolicitacao;

            _tratamentoRepositorio.Atualizar(tratamento);
            return tratamento;
        }
    }
}
