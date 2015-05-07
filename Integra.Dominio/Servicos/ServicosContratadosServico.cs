using System;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class ServicosContratadosServico
    {
        private readonly IServicosContratadosRepositorio _servicosContratadosRepositorio;

        public ServicosContratadosServico(IServicosContratadosRepositorio servicosContratadosRepositorio)
        {
            _servicosContratadosRepositorio = servicosContratadosRepositorio;
        }

        public ServicosContratados AdicionarServico(Programa programa, string nome, string descricao, int quantidade, string observacoes, DateTime dataContratacao, DateTime dataDeCriacao)
        {
            var servico = new ServicosContratados(programa)
            {
                Nome = nome,
                Descricao = descricao,
                Quantidade = quantidade,
                Observacoes = observacoes,
                DataContratacao = dataContratacao,
                DataDeCriacao = dataDeCriacao
            };

            _servicosContratadosRepositorio.Adicionar(servico);
            return servico;
        }

        public ServicosContratados AlterarServico(ServicosContratados servico, string nome, string descricao, int quantidade, string observacoes, DateTime dataContratacao)
        {
            servico.Nome = nome;
            servico.Descricao = descricao;
            servico.Quantidade = quantidade;
            servico.Observacoes = observacoes;
            servico.DataContratacao = dataContratacao;
            _servicosContratadosRepositorio.Atualizar(servico);
            return servico;
        }
    }
}
