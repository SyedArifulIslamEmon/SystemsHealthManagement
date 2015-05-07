using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ClinicaRepositorio : Repositorio<Clinica, int>, IClinicaRepositorio
    {
        public ClinicaRepositorio(IUnitOfWork uow)
            : base(uow){ }

        public override Clinica ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Clinica> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }

        public ClinicaDocumentos ObterDocumentoDeUmaClinica(int codigoDaClinica, int codigoDoDocumento)
        {
            var query = from clinica in GetObjectSet()
                        from documentos in clinica.Documentos
                        where clinica.Codigo == codigoDaClinica && documentos.Codigo == codigoDoDocumento
                        select documentos;

            return query.SingleOrDefault();
        }
    }
}
