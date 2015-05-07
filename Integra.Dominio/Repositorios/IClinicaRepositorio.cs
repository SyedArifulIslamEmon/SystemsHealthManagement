using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface IClinicaRepositorio : IRepositorio<Clinica, int>
    {
        List<Clinica> ObterTodos(Programa programa);
        ClinicaDocumentos ObterDocumentoDeUmaClinica(int codigoDaClinica, int codigoDoDocumento);
    }
}