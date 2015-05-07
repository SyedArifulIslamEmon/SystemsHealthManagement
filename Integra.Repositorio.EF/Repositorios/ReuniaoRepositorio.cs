using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class ReuniaoRepositorio : Repositorio<Reuniao, int>, IReuniaoRepositorio
    {
        public ReuniaoRepositorio(IUnitOfWork uow)
            : base(uow){ }

        public override Reuniao ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public List<Reuniao> ObterTodos(Programa programa)
        {
            return GetObjectSet().Where(it => it.Programa.Codigo == programa.Codigo).ToList();
        }

        public Ata ObterAtaDaReuniao(int codigoDaReuniao, int codigoDaAta)
        {
            var query = from reuniao in GetObjectSet()
                        where reuniao.Codigo == codigoDaReuniao
                        from ata in reuniao.Atas
                        where ata.Codigo == codigoDaAta
                        select ata;

            return query.SingleOrDefault();
        }

        public Arquivo ObterAnexoDeUmaAta(int codigoDaReuniao, int codigoDaAta, int codigoDoAnexo)
        {
            var query = from reuniao in GetObjectSet()
                        from ata in reuniao.Atas
                        from anexo in ata.Anexos
                        where reuniao.Codigo == codigoDaReuniao && ata.Codigo == codigoDaAta && anexo.Codigo == codigoDoAnexo
                        select anexo;

            return query.SingleOrDefault();
        }
    }
}