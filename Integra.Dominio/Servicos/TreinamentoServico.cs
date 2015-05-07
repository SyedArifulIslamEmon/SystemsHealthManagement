using System;
using System.Collections.Generic;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Dominio.Servicos
{
    public class TreinamentoServico
    {
        private readonly ITreinamentoRepositorio _treinamentoRepositorio;

        public TreinamentoServico(ITreinamentoRepositorio treinamentoRepositorio)
        {
            _treinamentoRepositorio = treinamentoRepositorio;
        }

        public Treinamento AdicionarTreinamento(Programa programa, DateTime dataRealizacao, Funcionario funcionario, string local,
            string titulo, string descricao)
        {
            var treinamento = new Treinamento(programa, dataRealizacao, funcionario, local, titulo, descricao);

            _treinamentoRepositorio.Adicionar(treinamento);
            return treinamento;
        }

        public Treinamento AlterarTreinamento(Treinamento treinamento, DateTime dataRealizacao, 
            Funcionario funcionario, string local, string titulo, string descricao)
        {
            treinamento.DataRealizacao = dataRealizacao;
            treinamento.Responsavel = funcionario;
            treinamento.Local = local;
            treinamento.Titulo = titulo;
            treinamento.Descricao = descricao;

            _treinamentoRepositorio.Atualizar(treinamento);
            return treinamento;
        }
    }
}
