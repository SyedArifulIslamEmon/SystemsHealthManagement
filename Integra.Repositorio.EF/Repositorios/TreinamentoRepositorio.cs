using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class TreinamentoRepositorio : Repositorio<Treinamento, int>, ITreinamentoRepositorio
    {
        public TreinamentoRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Treinamento ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Treinamento> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }

        public Arquivo ObterAnexoDoTreinamento(int codigoDoTreinamento, int codigoDoAnexo)
        {
            var query = from treinamento in GetObjectSet()
                        where treinamento.Codigo == codigoDoTreinamento
                        from anexo in treinamento.Anexos
                        where anexo.Codigo == codigoDoAnexo
                        select anexo;

            return query.FirstOrDefault();
        }
    }
}
