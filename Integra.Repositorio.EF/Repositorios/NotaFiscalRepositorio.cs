using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class NotaFiscalRepositorio : Repositorio<NotaFiscal, int>, INotaFiscalRepositorio
    {
        public NotaFiscalRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override NotaFiscal ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public IList<NotaFiscal> ObterTodasDaClinicaNoMes(int mes, int ano, Programa programa)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano+1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            var retorno = GetObjectSet().Where(it => it.Data >= dataInicial && it.Data <= dataFinal && !it.Devolvida).ToList();
            return retorno.Where(it => it.Programa.CodPrograma == programa.CodPrograma).ToList();
        }

        public IList<NotaFiscal> ObterTodasNotasDevolvidasNoMes(int mes, int ano, Programa programa)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano + 1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            var retorno = GetObjectSet().Where(it => it.Data >= dataInicial && it.Data <= dataFinal && it.Devolvida).ToList();
            return retorno.Where(it => it.Programa.CodPrograma == programa.CodPrograma).ToList();
        }

        public IList<NotaFiscal> ObterTodasNoMes(int mes, int ano, Programa programa)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano + 1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            //return GetObjectSet().Where(it => it.Data >= dataInicial && it.Data <= dataFinal && !it.Devolvida && it.Estorno == null && it.Programa == programa).ToList();
            var retorno = GetObjectSet().Where(it => it.Data >= dataInicial && it.Data <= dataFinal && !it.Devolvida && it.Estorno == null).ToList();
            return retorno.Where(it => it.Programa.CodPrograma == programa.CodPrograma).ToList();
        }

        public IList<Infusao> ObterTodasInfusoesDaClinicaNoMes(int codigoDaClinica, int mes, int ano)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano + 1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            var infusoes = (from nota in GetObjectSet()
                            where nota.Clinica.Codigo == codigoDaClinica &&
                            nota.Data >= dataInicial && nota.Data <= dataFinal && !nota.Devolvida && nota.Estorno == null
                            select nota).SelectMany(it => it.Infusoes).ToList();

            var infusoes2 = (from nota in GetObjectSet()
                            where nota.Clinica.Codigo == codigoDaClinica &&
                            nota.Data >= dataInicial && nota.Data <= dataFinal
                            select nota).SelectMany(it => it.Infusoes).ToList();

            return infusoes;
        }
    }
}