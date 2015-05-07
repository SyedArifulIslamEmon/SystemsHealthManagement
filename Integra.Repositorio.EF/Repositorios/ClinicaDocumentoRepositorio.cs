using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ClinicaDocumentoRepositorio : Repositorio<ClinicaDocumentos, int>, IClinicaDocumentoRepositorio
    {
        public ClinicaDocumentoRepositorio(IUnitOfWork uow)
            : base(uow){ }

        public override ClinicaDocumentos ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public new List<ClinicaDocumentos> ObterTodos()
        {
            //return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
            return GetObjectSet().ToList();
        }
    }
}
