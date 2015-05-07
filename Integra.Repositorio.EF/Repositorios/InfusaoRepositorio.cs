using System;
using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class InfusaoRepositorio : Repositorio<Infusao, int>, IInfusaoRepositorio
    {
        public InfusaoRepositorio(IUnitOfWork uow)
            : base(uow){ }

        public override Infusao ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        //Infusao ObterPor(Clinica clinica, string localizador, string cpf);
        public Infusao ObterPorLocalizacao(Clinica clinica, string localizador, string cpf)
        {
            return GetObjectSet().SingleOrDefault(it => it.Clinica.Codigo == clinica.Codigo && it.Localizador == localizador && it.Cpf == cpf);
        }

        public List<Infusao> ObterTodasNaoVinculadas(Clinica clinica)
        {
            return (from infusoes in GetObjectSet()
                     where infusoes.Clinica.Codigo == clinica.Codigo
                           && infusoes.StatusDaInfusao == StatusDaInfusao.Pendente
                         select infusoes).ToList();
        }


        public List<Infusao> ObterTodos(Clinica clinica)
        {
            return GetObjectSet().Where(it => it.Clinica.Codigo == clinica.Codigo).ToList();
        }

        public List<Infusao> ObterTodasNoMes(int mes, int ano, Programa programa)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano + 1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            //return GetObjectSet().Where(it => it.Data >= dataInicial && it.Data <= dataFinal && !it.Devolvida && it.Estorno == null && it.Programa == programa).ToList();
            var retorno = GetObjectSet().Where(it => it.DataInfusao >= dataInicial && it.DataInfusao <= dataFinal && it.StatusDaInfusao != StatusDaInfusao.Cancelado).ToList();
            return retorno.Where(it => it.Programa.CodPrograma == programa.CodPrograma).ToList();
        }

        public List<Infusao> ObterTodasInfusoesDaClinicaNoMes(int codigoDaClinica, int mes, int ano)
        {
            var dataInicial = new DateTime(ano, mes == 13 ? 1 : mes, 1);
            var dataFinal = mes == 13 ? new DateTime(ano + 1, 1, 1).AddSeconds(-1) : dataInicial.AddMonths(1).AddSeconds(-1);
            return GetObjectSet().Where(it => it.DataInfusao >= dataInicial && it.DataInfusao <= dataFinal && it.Clinica.Codigo == codigoDaClinica && it.StatusDaInfusao != StatusDaInfusao.Cancelado).ToList();
        }
    }
}
