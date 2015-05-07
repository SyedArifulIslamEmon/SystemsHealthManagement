using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface INotaFiscalRepositorio : IRepositorio<NotaFiscal, int>
    {
        IList<NotaFiscal> ObterTodasNoMes(int mes, int ano, Programa programa);
        IList<NotaFiscal> ObterTodasDaClinicaNoMes(int mes, int ano, Programa programa);
        IList<NotaFiscal> ObterTodasNotasDevolvidasNoMes(int mes, int ano, Programa programa);
        IList<Infusao> ObterTodasInfusoesDaClinicaNoMes(int codigoDaClinica, int mes, int ano);
    }
}