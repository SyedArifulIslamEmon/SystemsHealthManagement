using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface IClinicaDocumentoRepositorio : IRepositorio<ClinicaDocumentos, int>
    {
        new List<ClinicaDocumentos> ObterTodos();
    }
}
