using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface IInfusaoRepositorio : IRepositorio<Infusao, int>
    {
        List<Infusao> ObterTodos(Clinica clinica);
        Infusao ObterPorLocalizacao(Clinica clinica, string localizador, string cpf);
        List<Infusao> ObterTodasNaoVinculadas(Clinica clinica);
        List<Infusao> ObterTodasNoMes(int mes, int ano, Programa programa);
        List<Infusao> ObterTodasInfusoesDaClinicaNoMes(int codigoDaClinica, int mes, int ano);
    }
}