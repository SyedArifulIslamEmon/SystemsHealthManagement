using System;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class InfusaoServico
    {
        private readonly IInfusaoRepositorio _infusaoRepositorio;

        public InfusaoServico(IInfusaoRepositorio infusaoRepositorio)
        {
            _infusaoRepositorio = infusaoRepositorio;
        }

        public Infusao AdicionarInfusao(Clinica clinica, string localizador, string cpf, DateTime dataInfusao, DateTime dataCadastro, StatusDaInfusao statusDaInfusao, Funcionario responsavel, Programa programa)
        {
            var infusao = new Infusao(clinica, localizador, cpf, dataInfusao, dataCadastro, statusDaInfusao, responsavel, programa);
            _infusaoRepositorio.Adicionar(infusao);
            return infusao;
        }
    }
}