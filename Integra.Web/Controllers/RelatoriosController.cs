using Integra.Dominio;
using Integra.Repositorio.EF.Repositorios;
using Integra.Web.CustomMembership;
using Integra.Web.Helpers;
using Integra.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Integra.Web.Controllers
{
    [AuthorizeCustom(Modulo = "Relatorios")]
    public class RelatoriosController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }
        [HttpPost]
        public string Relatorio(string submit, string tipoFiltro, string parametro, string parametroFull)
        {
            //Verifica se há um ; de concatenação no final da string.
            if (parametro.EndsWith(","))
            {
                parametro = parametro.Substring(0, parametro.Length - 1);
                parametroFull = parametroFull.Substring(0, parametroFull.Length - 1);
            }
            else
            {
                parametro = "0";
            }
            //Verifica se o click é decorrente do botão salvar.
            if (submit == "Salvar")
            {
                //Seleciona o parametro correto para armazenar o valor.
                switch (tipoFiltro.ToUpper())
                {
                    case "P4": { FiltroRelatorioViewModel.ListarRelatorioParametros.P4 = parametro; break; }
                    case "P5": { FiltroRelatorioViewModel.ListarRelatorioParametros.P5 = parametro; break; }
                    case "P6": { FiltroRelatorioViewModel.ListarRelatorioParametros.P6 = parametro; break; }
                    case "P7": { FiltroRelatorioViewModel.ListarRelatorioParametros.P7 = parametro; break; }
                    case "P8": { FiltroRelatorioViewModel.ListarRelatorioParametros.P8 = parametro; break; }
                    case "P9": { FiltroRelatorioViewModel.ListarRelatorioParametros.P9 = parametro; break; }
                    case "P10": { FiltroRelatorioViewModel.ListarRelatorioParametros.P10 = parametro; break; }
                    case "P11": { FiltroRelatorioViewModel.ListarRelatorioParametros.P11 = parametro; break; }
                    case "P12": { FiltroRelatorioViewModel.ListarRelatorioParametros.P12 = parametro; break; }
                    case "P13": { FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro; break; }
                    case "P14": { FiltroRelatorioViewModel.ListarRelatorioParametros.P14 = parametro; break; }
                    case "P15": { FiltroRelatorioViewModel.ListarRelatorioParametros.P15 = parametro; break; }
                    case "P16": { FiltroRelatorioViewModel.ListarRelatorioParametros.P16 = parametro; break; }
                    case "P17": { FiltroRelatorioViewModel.ListarRelatorioParametros.P17 = parametro; break; }
                    case "P18": { FiltroRelatorioViewModel.ListarRelatorioParametros.P18 = parametro; break; }
                    case "P19": { FiltroRelatorioViewModel.ListarRelatorioParametros.P19 = parametro; break; }
                    case "P20": { FiltroRelatorioViewModel.ListarRelatorioParametros.P20 = parametro; break; }
                }
            }
            return parametroFull;
        }

        public ActionResult RelatorioRkCadastro()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public ActionResult RelatorioEvoPacienteCadastro()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public ActionResult DesempenhodeAcesso()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public ActionResult RelatorioEfetividadeAcesso()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public ActionResult Relatorio2()
        {
            return View();
        }

        public ActionResult Relatorio3()
        {
            return View();
        }

        public PartialViewResult DadosRelatorioParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.Parametros.Add(new SqlParameter("p20", FiltroRelatorioViewModel.ListarRelatorioParametros.P20));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioCadastroProcedure("spReportCadastroTratamento");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public PartialViewResult DadosRelatorioRkCadastroParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                ViewBag.Agrupamento = clsClass.RetornarAgrupamento(FiltroRelatorioViewModel.ListarRelatorioParametros.P14 == "0" ? "1" : FiltroRelatorioViewModel.ListarRelatorioParametros.P14);
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("agr", FiltroRelatorioViewModel.ListarRelatorioParametros.P14 == "0" ? "1" : FiltroRelatorioViewModel.ListarRelatorioParametros.P14));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioCadastroRkProcedure("spReportRankingCadastro");

                ViewBag.TotalCadastros = "Total de Cadastros: " + lstRelatorioCadastro.Sum(item => item.QtdeTratamento).ToString();

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioRankingCadastro>());
            }
        }

        public PartialViewResult DadosRelatorioEvoPacCadastroParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioEvoPacCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioEvoPacCadastroProcedure("spReportEvolucaoCadastro");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioEvoPacCadastro>());
            }
        }

        public PartialViewResult DadosRelatorioDesempenhoAcessoParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioDesempenhoAcesso.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioDesempenhoAcessoProcedure("spReportDesempenhoAcesso");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioDesempenhoAcesso>());
            }
        }

        public PartialViewResult DadosRelatorioEfetividadeAcessoParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioEfetividadeAcesso.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioEfetividadeAcessoProcedure("spReportEfetividadeAcessoMVC");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioEfetividadeAcesso>());
            }
        }

        public string DadosRelatorioEfetividadeAcessoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var item = "";
                var valor = "";
                clsClass.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioEfetividadeAcessoGrafico("spReportEfetividadeAcessoGraficoMVC");

                if (lstRelatorioCadastro.HasRows)
                {
                    while (lstRelatorioCadastro.Read())
                    {
                        item += lstRelatorioCadastro["descTipoFormaAcesso"] + ",";
                        valor += lstRelatorioCadastro["qtdeTratamentos"] + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    valor = valor.Substring(0, valor.Length - 1);
                }
                else
                {
                    item = "0";
                    valor = "0";
                }
                return item + "|" + valor;
            }
            catch
            {
                return "";
            }
        }
        public PartialViewResult FiltrosRelatorio(string pstrTipoCaixa)
        {
            var clsRelatorio = new RelatorioRepositorio(pstrTipoCaixa, RecuperaPrograma());
            var dadosParametro = RecuperaDadosParametro(pstrTipoCaixa);
            ViewBag.Titulo = clsRelatorio.Filtros(pstrTipoCaixa);
            ViewBag.TipoFiltro = pstrTipoCaixa;
            ViewBag.DadosParametro = dadosParametro;

            return PartialView(clsRelatorio.ExecutarFiltroProc());
        }

        public string arrumaPeriodo(string tipoPeriodo)
        {
            string periodo = null;
            switch (tipoPeriodo)
            {
                case "0":
                    periodo = new DateTime(DateTime.Now.Year, 1, 1).ToShortDateString() + "|" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString();
                    break;
                case "1":
                    periodo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(-12).ToShortDateString() + "|" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString();
                    break;
                case "2":
                    break;
                case "3":
                    var clsClass = new RelatorioRepositorio();
                    clsClass.Parametros.Add(new SqlParameter("CODPROGRAMA", RecuperaPrograma()));
                    SqlDataReader sqlDataReader = clsClass.ExecutarDataReaderProcedure("SPRETORNADATAINICIOTRATAMENTO");
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            periodo = Convert.ToDateTime(sqlDataReader["DATA"]).ToShortDateString() + "|" + new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToShortDateString();
                            break;
                        }
                    }
                    break;
            }
            return periodo;
        }

        public string RecuperaDadosParametro(string pstrTipoCaixa)
        {
            switch (pstrTipoCaixa.ToUpper())
            {
                case "P4": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P4; }
                case "P5": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P5; }
                case "P6": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P6; }
                case "P7": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P7; }
                case "P8": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P8; }
                case "P9": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P9; }
                case "P10": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P10; }
                case "P11": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P11; }
                case "P12": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P12; }
                case "P13": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P13; }
                case "P14": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P14; }
                case "P15": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P15; }
                case "P16": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P16; }
                case "P17": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P17; }
                case "P18": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P18; }
                case "P19": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P19; }
                case "P20": { return FiltroRelatorioViewModel.ListarRelatorioParametros.P20; }
                default:
                    return "";
            }
        }

        public string RemoverFiltro(string tipoFiltro)
        {
            string parametro = "0";
            //Seleciona o parametro correto para armazenar o valor.
            switch (tipoFiltro.ToUpper())
            {
                case "P4": { FiltroRelatorioViewModel.ListarRelatorioParametros.P4 = parametro; break; }
                case "P5": { FiltroRelatorioViewModel.ListarRelatorioParametros.P5 = parametro; break; }
                case "P6": { FiltroRelatorioViewModel.ListarRelatorioParametros.P6 = parametro; break; }
                case "P7": { FiltroRelatorioViewModel.ListarRelatorioParametros.P7 = parametro; break; }
                case "P8": { FiltroRelatorioViewModel.ListarRelatorioParametros.P8 = parametro; break; }
                case "P9": { FiltroRelatorioViewModel.ListarRelatorioParametros.P9 = parametro; break; }
                case "P10": { FiltroRelatorioViewModel.ListarRelatorioParametros.P10 = parametro; break; }
                case "P11": { FiltroRelatorioViewModel.ListarRelatorioParametros.P11 = parametro; break; }
                case "P12": { FiltroRelatorioViewModel.ListarRelatorioParametros.P12 = parametro; break; }
                case "P13": { FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro; break; }
                case "P14": { FiltroRelatorioViewModel.ListarRelatorioParametros.P14 = parametro; break; }
                case "P15": { FiltroRelatorioViewModel.ListarRelatorioParametros.P15 = parametro; break; }
                case "P17": { FiltroRelatorioViewModel.ListarRelatorioParametros.P17 = parametro; break; }
                case "P18": { FiltroRelatorioViewModel.ListarRelatorioParametros.P18 = parametro; break; }
                case "P19": { FiltroRelatorioViewModel.ListarRelatorioParametros.P19 = parametro; break; }
                case "P20": { FiltroRelatorioViewModel.ListarRelatorioParametros.P20 = parametro; break; }
                case "PT":
                    {
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P4 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P5 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P6 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P7 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P8 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P9 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P10 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P11 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P20 = parametro;

                        if (User.ToPessoa().Crm != null)
                        {
                            //Se é Gerente Apaga somente o Representante
                            if (User.ToPessoa().Crm.Tipo.FlagCrm.ToUpper() == "G")
                            {
                                FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro;
                            }
                        }
                        else
                        {
                            FiltroRelatorioViewModel.ListarRelatorioParametros.P12 = parametro;
                            FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro;
                        }





                        FiltroRelatorioViewModel.ListarRelatorioParametros.P14 = parametro;
                        FiltroRelatorioViewModel.ListarRelatorioParametros.P15 = parametro;
                        break;
                    }
            }
            return "";
        }

        /// <summary>
        /// Seta o Agrupamento no filtro.
        /// </summary>
        /// <param name="parametro"></param>
        public void MudarAgrupamento(string parametro)
        {
            FiltroRelatorioViewModel.ListarRelatorioParametros.P14 = parametro;
        }

        public ActionResult RelatorioPacientesInativados()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioPacientesInativadosParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioPacientesInativados.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioPacientesInativados = clsClass.RetornarRelatorioPacientesInativadosProcedure("spReportPacientesInativados");

                return PartialView(lstRelatorioPacientesInativados);
            }
            catch
            {
                return PartialView(new List<RelatorioPacientesInativados>());
            }
        }

        public FiltroRelatorioParametros InstanciaParametros()
        {
            return new FiltroRelatorioParametros
            {
                P1 = "0",
                P2 = "0",
                P3 = "0",
                P4 = "0",
                P5 = "0",
                P6 = "0",
                P7 = "0",
                P8 = "0",
                P9 = "0",
                P10 = "0",
                P11 = "0",
                P12 = "0",
                P13 = "0",
                P14 = "0",
                P15 = "0",
                P16 = "0",
                P17 = "0",
                P18 = "0",
                P19 = "0", 
                P20 = "0"
            };
        }


        public ActionResult RelatorioPacientesAtivos()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioPacientesAtivosParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioPacientesAtivos.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioPacientesAtivos = clsClass.RetornarRelatorioPacientesAtivosProcedure("spReportQtdeInfusoesPacienteAtivo");

                //ViewBag.qtdTotal = lstRelatorioPacientesAtivos.Sum(filtro => filtro.QtdeInfusoes);
                ViewBag.qtdTotal = lstRelatorioPacientesAtivos.Count - 1;

                return PartialView(lstRelatorioPacientesAtivos);
            }
            catch
            {
                return PartialView(new List<RelatorioPacientesAtivos>());
            }
        }

        public ActionResult RelatorioEvoPacienteDoenca()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioEvoPacienteDoencaParcialView(string dataInicio, string dataFim)
        {
            //var anterior = "";
            //var p1 = "";
            //var p2 = "";
            //var retorno = "";
            var dtInicio = Convert.ToDateTime(dataInicio);
            var dtFim = Convert.ToDateTime(dataFim);

            var item = string.Empty;
            var itens = string.Empty;
            string[] valores;
            var itemOrdem = string.Empty;
            var itemColumn = string.Empty;
            var ultimoItem = string.Empty;
            var valor = string.Empty;
            DataTable dt = new DataTable();

            var clsClass = new RelatorioRepositorio();
            clsClass.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
            clsClass.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
            clsClass.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
            clsClass.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
            clsClass.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
            clsClass.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
            clsClass.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
            clsClass.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
            clsClass.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
            clsClass.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
            clsClass.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
            clsClass.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
            clsClass.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
            var sqlDataReader = clsClass.RetornarRelatorioEvoPacienteDoencaGrafico("spReportEssencialPacientesPorDoenca");
            //Inastância um novo argumento de parametro.
            //if (sqlDr.HasRows)
            //{


            //    while (sqlDr.Read())
            //    {
            //        if (anterior == "")
            //        {
            //            anterior = sqlDr["DOENCA"].ToString();
            //        }
            //        //DOENCA DATA QTD
            //        if (sqlDr["DOENCA"].ToString() != anterior)
            //        {
            //            if (anterior.Length > 0)
            //            {
            //                valor = 0;
            //                retorno += anterior + ";" + p1.Remove(p1.Length - 1, 1) + ";" + p2.Remove(p2.Length - 1, 1) + "|";
            //            }
            //            anterior = sqlDr["DOENCA"].ToString().Trim();
            //            p1 = "'" + sqlDr["DATA"].ToString().Trim() + "',";
            //            valor = valor + Convert.ToInt16(sqlDr["QTD"].ToString().Trim());
            //            p2 = valor.ToString() + ",";
            //        }
            //        else
            //        {
            //            //anterior = sqlDr["DOENCA"].ToString().Trim();
            //            p1 += "'" + sqlDr["DATA"].ToString().Trim() + "',";
            //            valor = valor + Convert.ToInt16(sqlDr["QTD"].ToString().Trim());
            //            p2 += valor.ToString() + ",";
            //        }
            //    }
            //    if (anterior.Length > 0)
            //    {
            //        retorno += anterior + ";" + p1.Remove(p1.Length - 1, 1) + ";" + p2.Remove(p2.Length - 1, 1);
            //    }
            //}
            //return retorno;

            if (sqlDataReader.HasRows)
            {
                Dictionary<string, int> hash = new Dictionary<string, int>();
                Dictionary<int, int> controle = new Dictionary<int, int>();
                dt.Columns.Add("ordem");
                dt.Columns.Add("item");
                dt.Columns.Add("valor");

                while (sqlDataReader.Read())
                {
                    if (hash.ContainsKey(sqlDataReader["DOENCA"].ToString()) == false)
                    {
                        hash.Add(sqlDataReader["DOENCA"].ToString(), Convert.ToInt32(hash.Count));
                        item += sqlDataReader["DOENCA"].ToString() + ",";
                        itemColumn += "column" + ",";
                    }
                    dt.Rows.Add("'" + sqlDataReader["DATA"].ToString().TrimEnd().TrimStart() + "'", sqlDataReader["DOENCA"].ToString().TrimEnd().TrimStart(), sqlDataReader["QTD"].ToString());
                }
                item = item.Substring(0, item.Length - 1);
                itemColumn = itemColumn.Substring(0, itemColumn.Length - 1);
                valores = new string[hash.Count];

                for (int contador = 0; contador <= dt.Rows.Count - 1; contador++)
                {
                    if (dt.Rows[contador][0].ToString() != ultimoItem)
                    {
                        if (ultimoItem != "")
                        {
                            itemOrdem += ",";
                            for (int cont = 0; cont <= valores.Length - 1; cont++)
                            {
                                if (controle.ContainsKey(cont) == false)
                                {
                                    valores[cont] += "0,";
                                }
                            }
                            controle = new Dictionary<int, int>();
                        }
                        ultimoItem = dt.Rows[contador][0].ToString();
                        itemOrdem += dt.Rows[contador][0].ToString();
                        valores[Convert.ToInt32(hash[dt.Rows[contador][1].ToString()])] += dt.Rows[contador][2].ToString().Replace(',', '.') + ",";
                        controle.Add(Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]), Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]));
                    }
                    else
                    {
                        valores[Convert.ToInt32(hash[dt.Rows[contador][1].ToString()])] += dt.Rows[contador][2].ToString().Replace(',', '.') + ",";
                        controle.Add(Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]), Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]));
                    }
                }
                for (int cont = 0; cont <= valores.Length - 1; cont++)
                {
                    if (controle.ContainsKey(cont) == false)
                    {
                        valores[cont] += "0";
                    }
                    else
                    {
                        valores[cont] = valores[cont].Substring(0, valores[cont].Length - 1);
                    }
                }

                for (int count = 0; count <= valores.Length - 1; count++)
                {
                    valor += valores[count] + ";";
                }
                valor = valor.Substring(0, valor.Length - 1);

                for (int count = 0; count <= item.Split(',').Length - 1; count++)
                {
                    itens += itemOrdem + ";";
                }
                itens = itens.Substring(0, itens.Length - 1);
                itemOrdem = itens;

                return itemColumn + "|" + itemOrdem + "|" + item + "|" + valor;
            }
            else { return ""; }
        }

        public ActionResult RelatorioEvoCadastroSemana()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioEvoCadastroSemanaParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioEvoCadastroSemana.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioEvoCadastroSemana = clsClass.RetornarRelatorioEvoCadastroSemanaProcedure("spReportEssencialPacientesPorSemana");

                return PartialView(lstRelatorioEvoCadastroSemana);
            }
            catch
            {
                return PartialView(new List<RelatorioEvoCadastroSemana>());
            }
        }






        public ActionResult RelatorioInfusoesAplicacao()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioInfusoesAplicacaoParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioInfusoesAplicacao.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioInfusoesAplicacao = clsClass.RetornarRelatorioInfusoesAplicacaoProcedure("spReportInfusoesPorAplicacao");

                return PartialView(lstRelatorioInfusoesAplicacao);
            }
            catch
            {
                return PartialView(new List<RelatorioInfusoesAplicacao>());
            }
        }



        public ActionResult RelatorioListagemPacientes()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioListagemPacientesParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioListagemPacientes.Parametros.Add(new SqlParameter("agr", FiltroRelatorioViewModel.ListarRelatorioParametros.P14));
                var lstRelatorioListagemPacientes = clsClass.RetornarListagemPacientesProcedure("spReportListagemPacientesInicioTratamento");

                return PartialView(lstRelatorioListagemPacientes);
            }
            catch
            {
                return PartialView(new List<RelatorioListagemPacientes>());
            }
        }




        public ActionResult RelatorioQuantidadePacientesAtivos()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioQuantidadePacientesAtivosParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioQuantidadePacientesAtivos.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioQuantidadePacientesAtivos = clsClass.RetornarQuantidadePacientesAtivosProcedure("spReportEssencialContatoPorPaciente");

                return PartialView(lstRelatorioQuantidadePacientesAtivos);
            }
            catch
            {
                return PartialView(new List<RelatorioQuantidadePacientesAtivos>());
            }
        }

        public ActionResult RelatorioRkCadastro2()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioRkCadastro2Grafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var periodo = string.Empty;
                var periodoAux = string.Empty;
                var linha = string.Empty;
                var valor = string.Empty;
                int acumulado = 0;
                var blnStop = false;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("agr", FiltroRelatorioViewModel.ListarRelatorioParametros.P14 == "0" ? "1" : FiltroRelatorioViewModel.ListarRelatorioParametros.P14));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("spReportRankingCadastroGrafico");

                Dictionary<int, string> hashItem = new Dictionary<int, string>();
                Dictionary<int, string> hashPeriodo = new Dictionary<int, string>();
                int contItem = 0;
                int contPeriodo = 0;
                string itemAnterior = string.Empty;

                if (sqlDataReader.HasRows == true)
                {
                    while (sqlDataReader.Read())
                    {
                        if (blnStop == false)
                        {
                            //Armazena os valores.
                            if (itemAnterior == sqlDataReader["AGRUPAMENTO"].ToString().Trim())
                            {
                                itemAnterior = sqlDataReader["AGRUPAMENTO"].ToString().Trim();
                                acumulado = acumulado + Convert.ToInt32(sqlDataReader["QTDETRATAMENTOS"]);
                                valor += acumulado.ToString() + ",";
                            }
                            else
                            {
                                if (contItem == 0)
                                {
                                    itemAnterior = sqlDataReader["AGRUPAMENTO"].ToString().Trim();
                                    acumulado = acumulado + Convert.ToInt32(sqlDataReader["QTDETRATAMENTOS"]);
                                    valor += acumulado.ToString() + ",";
                                }
                                else
                                {
                                    if (contItem == 10)
                                    {
                                        blnStop = true;
                                    }
                                    else
                                    {
                                        if (valor.EndsWith(","))
                                        {
                                            valor = valor.Substring(0, valor.Length - 1);
                                        }
                                        itemAnterior = sqlDataReader["AGRUPAMENTO"].ToString().Trim();
                                        acumulado = 0;
                                        acumulado = acumulado + Convert.ToInt32(sqlDataReader["QTDETRATAMENTOS"]);
                                        valor += ";" + acumulado.ToString() + ",";
                                    }
                                }
                            }
                        }
                        if (contItem != 10)
                        {
                            //Armazena os Itens
                            if (hashItem.ContainsValue(sqlDataReader["AGRUPAMENTO"].ToString().Trim()) == false)
                            {
                                hashItem.Add(contItem, sqlDataReader["AGRUPAMENTO"].ToString().Trim());
                                contItem++;
                            }
                        }
                        //Armazena os Periodos
                        if (hashPeriodo.ContainsValue(sqlDataReader["DESCANOMES"].ToString().Trim()) == false)
                        {
                            hashPeriodo.Add(contPeriodo, sqlDataReader["DESCANOMES"].ToString().Trim());
                            contPeriodo++;
                        }
                    }
                    //Separa o Periodo.
                    for (contPeriodo = 0; contPeriodo <= hashPeriodo.Count - 1; contPeriodo++)
                    {
                        periodo += "'" + hashPeriodo[contPeriodo].ToString() + "',";
                    }
                    if (periodo.EndsWith(","))
                    {
                        periodo = periodo.Substring(0, periodo.Length - 1);
                    }

                    //Separa os items para string.
                    for (contItem = 0; contItem <= hashItem.Count - 1; contItem++)
                    {
                        item += hashItem[contItem].ToString() + ",";
                        linha += "line,";
                        periodoAux += periodo + ";";
                    }

                    if (item.EndsWith(","))
                    {
                        item = item.Substring(0, item.Length - 1);
                        linha = linha.Substring(0, linha.Length - 1);
                        periodoAux = periodoAux.Substring(0, periodoAux.Length - 1);
                        valor = valor.Substring(0, valor.Length - 1);
                    }

                }

                return linha + "|" + item + "|" + periodoAux + "|" + valor;
            }
            catch
            {
                return "";
            }
        }


        public ActionResult RelatorioVisaoGeralProjeto()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioVisaoGeralProjetoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var valor1 = string.Empty;
                var valor2 = string.Empty;
                var valor3 = string.Empty;
                var valor4 = string.Empty;
                var valor5 = string.Empty;
                int valorA1 = 0;
                int valorA2 = 0;
                int valorA3 = 0;
                int valorA4 = 0;
                int valorA5 = 0;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                //var lstRelatorioCadastro = clsClass.RetornarRelatorioCadastroRkProcedure("SPREPORTRANKINGCADASTROGRAFICO");
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("spVisaoGeralGrafico");

                if (sqlDataReader.HasRows == true)
                {
                    while (sqlDataReader.Read())
                    {
                        item += "'" + MascaraMesAno(sqlDataReader["DATA"].ToString()) + "',";

                        valorA1 = valorA1 + Convert.ToInt32(sqlDataReader["TOTAL"]);
                        valorA2 = valorA2 + Convert.ToInt32(sqlDataReader["ATIVOS"]);
                        valorA3 = valorA3 + Convert.ToInt32(sqlDataReader["INATIVOS"]);
                        valorA4 = valorA4 + Convert.ToInt32(sqlDataReader["MEDICOS"]);
                        valorA5 = valorA5 + Convert.ToInt32(sqlDataReader["EMTRATAMENTO"]);

                        valor1 += valorA1.ToString() + ",";
                        valor2 += valorA2.ToString() + ",";
                        valor3 += valorA3.ToString() + ",";
                        valor4 += valorA4.ToString() + ",";
                        valor5 += valorA5.ToString() + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    valor1 = valor1.Substring(0, valor1.Length - 1);
                    valor2 = valor2.Substring(0, valor2.Length - 1);
                    valor3 = valor3.Substring(0, valor3.Length - 1);
                    valor4 = valor4.Substring(0, valor4.Length - 1);
                    valor5 = valor5.Substring(0, valor5.Length - 1);
                }

                return item + "|" + valor1 + ";" + valor2 + ";" + valor3 + ";" + valor4 + ";" + valor5;
            }
            catch
            {
                return "";
            }
        }

        public string MascaraMesAno(string pstrPeriodo)
        {
            if (pstrPeriodo.Contains("/"))
            {
                var posANO = pstrPeriodo.Split('/')[0];
                var posMES = pstrPeriodo.Split('/')[1];
                switch (pstrPeriodo.Split('/')[1])
                {
                    case "01":
                        {
                            return "Jan/" + posANO;
                        }
                    case "02":
                        {
                            return "Fev/" + posANO;
                        }
                    case "03":
                        {
                            return "Mar/" + posANO;
                        }
                    case "04":
                        {
                            return "Abr/" + posANO;
                        }
                    case "05":
                        {
                            return "Mai/" + posANO;
                        }
                    case "06":
                        {
                            return "Jun/" + posANO;
                        }
                    case "07":
                        {
                            return "Jul/" + posANO;
                        }
                    case "08":
                        {
                            return "Ago/" + posANO;
                        }
                    case "09":
                        {
                            return "Set/" + posANO;
                        }
                    case "10":
                        {
                            return "Out/" + posANO;
                        }
                    case "11":
                        {
                            return "Nov/" + posANO;
                        }
                    case "12":
                        {
                            return "Dez/" + posANO;
                        }

                    default: return "SEM DATA";
                }
            }
            else
            {
                return "SEM DATA";
            }
        }

        public ActionResult RelatorioDadosDemograficos()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioDadosDemograficosGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var valor = string.Empty;
                var idade = string.Empty;
                var sexo = string.Empty;
                var origem = string.Empty;
                var origem_Publico = string.Empty;
                var Origem_Privado = string.Empty;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("spDadosDemograficos");

                if (sqlDataReader.HasRows)
                {

                    while (sqlDataReader.Read())
                    {
                        idade = sqlDataReader["IDADE_INICIO"] + "," + sqlDataReader["IDADE_ATUAL"];
                        sexo = sqlDataReader["FEMININO"] + "," + sqlDataReader["MASCULINO"];
                        origem = sqlDataReader["ORIGEM_PRIVADO"] + "," + sqlDataReader["ORIGEM_PUBLICO"] + "," + sqlDataReader["ORIGEM_NAOSOUBEINFORMAR"];
                        origem_Publico = sqlDataReader["PUBLICO_NAOSOUBEINFORMAR"] + "," + sqlDataReader["PUBLICO_HOSPITAL"] + "," + sqlDataReader["PUBLICO_CLINICA"] + "," + sqlDataReader["PUBLICO_CONSULTORIO"];
                        Origem_Privado = sqlDataReader["PRIVADO_NAOSOUBEINFORMAR"] + "," + sqlDataReader["PRIVADO_HOSPITAL"] + "," + sqlDataReader["PRIVADO_CLINICA"] + "," + sqlDataReader["PRIVADO_CONSULTORIO"];
                    }
                    return idade + "|" + sexo + "|" + origem + "|" + Origem_Privado + "|" + origem_Publico;
                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }

        public ActionResult RelatorioRelacaoPacienteMedico()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioRelacaoPacienteMedicoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;

                double pacienteAux = 0.00;
                var paciente = string.Empty;

                double medicoAux = 0.00;
                var medico = string.Empty;

                var media = string.Empty;
                //double mediaC = 0.00;

                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("spRelacaoPacienteMedico");

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        item += "'" + MascaraMesAno(sqlDataReader["DATA"].ToString()) + "',";
                        pacienteAux = pacienteAux + Convert.ToDouble(sqlDataReader["PACIENTE"]);
                        paciente += pacienteAux.ToString().Replace(',', '.') + ",";

                        medicoAux = medicoAux + Convert.ToDouble(sqlDataReader["MEDICO"]);
                        medico += medicoAux.ToString().Replace(',', '.') + ",";

                        //mediaC = mediaC + Convert.ToDouble(sqlDataReader["MEDIA"]);
                        //media += mediaC.ToString().Replace(',', '.') + ",";

                        //media += Convert.ToDouble(sqlDataReader["MEDIA"]).ToString().Replace(',', '.') + ",";

                        media += Convert.ToDouble(Math.Round(pacienteAux / medicoAux, 2)).ToString().Replace(',', '.') + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    paciente = paciente.Substring(0, paciente.Length - 1);
                    medico = medico.Substring(0, medico.Length - 1);
                    media = media.Substring(0, media.Length - 1);
                    return item + "|" + paciente + "|" + medico + "|" + media;

                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }




        public ActionResult RelatorioSourceOfBusiness()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioSourceOfBusinessGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var valor = string.Empty;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("sp_ReportSourceOfBusiness");

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader["Medicamento"].ToString() == "")
                        {
                            item += "Sem informação,";
                        }
                        else
                        {
                            item += sqlDataReader["Medicamento"] + ",";
                        }
                        valor += sqlDataReader["qtdeTratamentos"] + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    valor = valor.Substring(0, valor.Length - 1);

                    return item + "|" + valor;
                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }

        public ActionResult RelatorioMedicamentoLinhaTratamento()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioMedicamentoLinhaTratamentoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var itens = string.Empty;
                string[] valores;
                var itemOrdem = string.Empty;
                var itemColumn = string.Empty;
                var ultimoItem = string.Empty;
                var valor = string.Empty;
                DataTable dt = new DataTable();
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("sp_Report_JUNTOSELIVRES_MEDICAMENTOPORLINHATRATAMENTO");
                if (sqlDataReader.HasRows)
                {
                    Dictionary<string, int> hash = new Dictionary<string, int>();
                    Dictionary<int, int> controle = new Dictionary<int, int>();
                    dt.Columns.Add("ordem");
                    dt.Columns.Add("item");
                    dt.Columns.Add("valor");

                    while (sqlDataReader.Read())
                    {
                        if (hash.ContainsKey(sqlDataReader["MEDICAMENTO_UTILIZADO"].ToString()) == false)
                        {
                            hash.Add(sqlDataReader["MEDICAMENTO_UTILIZADO"].ToString(), Convert.ToInt32(hash.Count));
                            item += sqlDataReader["MEDICAMENTO_UTILIZADO"].ToString() + ",";
                            itemColumn += "column" + ",";
                        }
                        dt.Rows.Add(sqlDataReader["ORDEM"].ToString(), sqlDataReader["MEDICAMENTO_UTILIZADO"].ToString(), sqlDataReader["RESULTADO"].ToString());
                    }
                    item = item.Substring(0, item.Length - 1);
                    itemColumn = itemColumn.Substring(0, itemColumn.Length - 1);
                    valores = new string[hash.Count];

                    for (int contador = 0; contador <= dt.Rows.Count - 1; contador++)
                    {
                        if (dt.Rows[contador][0].ToString() != ultimoItem)
                        {
                            if (ultimoItem != "")
                            {
                                itemOrdem += ",";
                                for (int cont = 0; cont <= valores.Length - 1; cont++)
                                {
                                    if (controle.ContainsKey(cont) == false)
                                    {
                                        valores[cont] += "0,";
                                    }
                                }
                                controle = new Dictionary<int, int>();
                            }
                            ultimoItem = dt.Rows[contador][0].ToString();
                            itemOrdem += dt.Rows[contador][0].ToString();
                            valores[Convert.ToInt32(hash[dt.Rows[contador][1].ToString()])] += dt.Rows[contador][2].ToString().Replace(',', '.') + ",";
                            controle.Add(Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]), Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]));
                        }
                        else
                        {
                            valores[Convert.ToInt32(hash[dt.Rows[contador][1].ToString()])] += dt.Rows[contador][2].ToString().Replace(',', '.') + ",";
                            controle.Add(Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]), Convert.ToInt32(hash[dt.Rows[contador][1].ToString()]));
                        }
                    }
                    for (int cont = 0; cont <= valores.Length - 1; cont++)
                    {
                        if (controle.ContainsKey(cont) == false)
                        {
                            valores[cont] += "0";
                        }
                        else
                        {
                            valores[cont] = valores[cont].Substring(0, valores[cont].Length - 1);
                        }
                    }

                    for (int count = 0; count <= valores.Length - 1; count++)
                    {
                        valor += valores[count] + ";";
                    }
                    valor = valor.Substring(0, valor.Length - 1);

                    for (int count = 0; count <= item.Split(',').Length - 1; count++)
                    {
                        itens += itemOrdem + ";";
                    }
                    itens = itens.Substring(0, itens.Length - 1);
                    itemOrdem = itens;

                    return itemColumn + "|" + itemOrdem + "|" + item + "|" + valor;
                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }





        public ActionResult RelatorioGilenyaLinhaTratamento()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioGilenyaLinhaTratamentoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                SqlDataReader sqlDataReader;
                var item = string.Empty;
                var valor = string.Empty;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("sp_ReportGyleniaLinhaTratamento");

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader["Linha"].ToString() == "")
                        {
                            item += "Sem informação,";
                        }
                        else
                        {
                            item += sqlDataReader["Linha"] + "a linha,";
                        }
                        valor += sqlDataReader["qtdeTratamentos"] + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    valor = valor.Substring(0, valor.Length - 1);

                    return item + "|" + valor;
                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }

        public ActionResult RelatorioHistoricoAcesso()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioHistoricoAcessoParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioCadastroProcedure("spReportCadastroTratamento");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public ActionResult RelatorioAcompanhamentoTratamento()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public string RelatorioAcompanhamentoTratamentoGrafico(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var item = string.Empty;
                var valor = string.Empty;
                SqlDataReader sqlDataReader;
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRankingCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.MclsDaoRelatorioRankingCadastro.ExecutarDataReaderProcedure("sp_ReportAcompanhamentoTratamento");

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader["FaseAtual"].ToString() == "")
                        {
                            item += "Sem informação,";
                        }
                        else
                        {
                            item += sqlDataReader["FaseAtual"] + ",";
                        }
                        valor += sqlDataReader["n"] + ",";
                    }
                    item = item.Substring(0, item.Length - 1);
                    valor = valor.Substring(0, valor.Length - 1);

                    return item + "|" + valor;
                }
                else { return ""; }

            }
            catch
            {
                return "";
            }
        }

        public ActionResult RelatorioOrigemCadastro()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioOrigemCadastroParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;
                //var maior = 0;
                SqlDataReader sqlDataReader;
                clsClass.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                sqlDataReader = clsClass.ExecutarDataReaderProcedure("spReportOrigemAcesso");

                var dt = new DataTable();
                dt.Load(sqlDataReader);
                List<DataRow> dr = dt.AsEnumerable().ToList();

                return PartialView(dr);
            }
            catch
            {
                return PartialView(); ;
            }
        }

        public ActionResult RelatorioEspecialidadeMedica()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }
        public PartialViewResult RelatorioEspecialidadeMedicaParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;
                //var maior = 0;
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioEspecialidadeMedica.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioEspecialidadeMedicaProcedure("spReportEspecialidadeMedica");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioEspecialidadeMedica>());
            }
        }

        public string RecuperaPrograma()
        {
            return Session.ProgramaAtivo().IdentPrograma.ToString(CultureInfo.InvariantCulture);
        }
        public string RecuperaCodPrograma()
        {
            return Session.ProgramaAtivo().CodPrograma.ToString(CultureInfo.InvariantCulture);
        }

        public ActionResult RelatorioAmostrasZoteonPo()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioAmostrasZoteonPoParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p16", FiltroRelatorioViewModel.ListarRelatorioParametros.P16));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p17", FiltroRelatorioViewModel.ListarRelatorioParametros.P17));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteon.Parametros.Add(new SqlParameter("p18", FiltroRelatorioViewModel.ListarRelatorioParametros.P18));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioentregaAmostrasZoteonProcedure("spReportEntregasZoteonPo");

                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p16", FiltroRelatorioViewModel.ListarRelatorioParametros.P16));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p17", FiltroRelatorioViewModel.ListarRelatorioParametros.P17));
                clsClass.MclsDaoRelatorioentregaAmostrasZoteonTotal.Parametros.Add(new SqlParameter("p18", FiltroRelatorioViewModel.ListarRelatorioParametros.P18));
                ViewBag.Total = clsClass.RetornarRelatorioentregaAmostrasZoteonTotalProcedure("spReportEntregasZoteonPo_Totalizador");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioentregaAmostrasZoteon>());
            }
        }


        public void SetParametroCrm(string tipoFiltro, string tipoCrm, string parametro)
        {
            if (FiltroRelatorioViewModel.ListarRelatorioParametros != null)
            {
                var clsDados = new RelatorioRepositorio();
                clsDados.MclsDaoFiltroRelatorio.Parametros.Add(new SqlParameter("TipoConsulta", tipoCrm));
                clsDados.MclsDaoFiltroRelatorio.Parametros.Add(new SqlParameter("ValorGuid", parametro));


                var lstDados = clsDados.MclsDaoFiltroRelatorio.ExecutarListaProcedure("spConverteGerenteOuRepresentante");

                if (lstDados.Count > 0)
                {
                    parametro = lstDados.ToList()[0].CodigoFiltro;
                    switch (tipoFiltro.ToUpper())
                    {
                        case "P12": { FiltroRelatorioViewModel.ListarRelatorioParametros.P12 = parametro; break; }
                        case "P13": { FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro; break; }
                    }
                }
                else
                {
                    parametro = "00999";
                    switch (tipoFiltro.ToUpper())
                    {
                        case "P12": { FiltroRelatorioViewModel.ListarRelatorioParametros.P12 = parametro; break; }
                        case "P13": { FiltroRelatorioViewModel.ListarRelatorioParametros.P13 = parametro; break; }
                    }
                }
            }

        }

        public ActionResult RelatorioOrigemVerEViver()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioOrigemVerEViverParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;
                //var maior = 0;
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioOrigemCadastro.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioOrigemCadastroProcedure("spReportOrigemCadastro");
                foreach (var item in lstRelatorioCadastro)
                {
                    item.Data = FormtaTitulo(item.Data);
                }
                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioEspecialidadeMedica>());
            }
        }

        public ActionResult RelatorioRitalinaPorFase()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioRitalinaPorFaseParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;
                int totalc = 0;
                int totalado = 0;
                int totalad = 0;
                //var maior = 0;
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioRitalinaporFase.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RetornarRelatorioRitalinaporFaseProcedure("spReportRitalinaPorFase");
                foreach (var item in lstRelatorioCadastro)
                {
                    totalc += item.Crianca;
                    totalado += item.Adolescente;
                    totalad += item.Adulto;
                    item.Total = item.Crianca + item.Adolescente + item.Adulto;
                }
                if (lstRelatorioCadastro.Count > 0)
                {
                    var total = clsClass.RetornarTotalRelatorioRitalinaporFaseModel();
                    total.Ordem = lstRelatorioCadastro.Count() + 1;
                    total.Crianca = totalc;
                    total.Crianca_Percentual = 100;
                    total.Adolescente = totalado;
                    total.Adolescente_Percentual = 100;
                    total.Adulto = totalad;
                    total.Adulto_Percentual = 100;
                    total.Total = totalc + totalado + totalad;
                    total.Medicamento = "Total";
                    lstRelatorioCadastro.Add(total);
                    foreach (var item in lstRelatorioCadastro)
                    {
                        if (totalc > 0)
                            item.Crianca_Percentual = Math.Round((item.Crianca / double.Parse(totalc.ToString())) * 100, 2);
                        else
                            item.Crianca_Percentual = 0;
                        if (totalado > 0)
                            item.Adolescente_Percentual = Math.Round((item.Adolescente / double.Parse(totalado.ToString())) * 100, 2);
                        else
                            item.Adolescente_Percentual = 0;
                        if (totalad > 0)
                            item.Adulto_Percentual = Math.Round((item.Adulto / double.Parse(totalad.ToString())) * 100, 2);
                        else
                            item.Adulto_Percentual = 0;
                    }
                }

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioEspecialidadeMedica>());
            }
        }

        public string FormtaTitulo(string texto)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }

        public ActionResult RelatorioNivelAdesaoMyFortic()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult RelatorioNivelAdesaoMyForticParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;
                int totala = 0;
                int totalm = 0;
                int totalb = 0;
                int totalt = 0;
                clsClass.MclsDaoRelatorioNivelAdesaoMyFortic.Parametros.Add(new SqlParameter("p2", dtInicio.Year + "-" + dtInicio.Month + "-" + dtInicio.Day));
                clsClass.MclsDaoRelatorioNivelAdesaoMyFortic.Parametros.Add(new SqlParameter("p3", dtFim.Year + "-" + dtFim.Month + "-" + dtFim.Day));
                clsClass.MclsDaoRelatorioNivelAdesaoMyFortic.Parametros.Add(new SqlParameter("p19", FiltroRelatorioViewModel.ListarRelatorioParametros.P19));
                var lstRelatorioCadastro = clsClass.RelatorioNivelAdesaoMyForticProcedure("[201.77.209.53\\INTEGRA_PRD].MYFORTIC.[DBO].SP_REPORT_ADESAO");

                foreach (var item in lstRelatorioCadastro)
                {
                    item.Total = item.Alta + item.Media + item.Baixa;
                    totala += item.Alta;
                    totalm += item.Media;
                    totalb += item.Baixa;
                    totalt += item.Total;
                    item.Perc_Alta = Math.Round((item.Alta / double.Parse(item.Total.ToString())) * 100, 2);
                    item.Perc_Media = Math.Round((item.Media / double.Parse(item.Total.ToString())) * 100, 2);
                    item.Perc_Baixa = Math.Round((item.Baixa / double.Parse(item.Total.ToString())) * 100, 2);
                }

                var total = clsClass.RetornarTotalRelatorioNivelAdesaoMyFortic();
                total.Ordem = lstRelatorioCadastro.Count + 1;
                total.Nome = "Total";
                total.Alta = totala;
                total.Total = totalt;
                total.Perc_Alta = 100;
                total.Media = totalm;
                total.Perc_Media = 100;
                total.Baixa = totalb;
                total.Perc_Baixa = 100;
                lstRelatorioCadastro.Add(total);
                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioNiveldeAdesao>());
            }
        }

        public ActionResult ReltorioCadastrosMyFortic()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult ReltorioCadastrosMyForticParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;

                clsClass.MclsDaoRelatorioCadastrosMyFortic.Parametros.Add(new SqlParameter("p2", dtInicio.Year + "-" + dtInicio.Month + "-" + dtInicio.Day));
                clsClass.MclsDaoRelatorioCadastrosMyFortic.Parametros.Add(new SqlParameter("p3", dtFim.Year + "-" + dtFim.Month + "-" + dtFim.Day));
                clsClass.MclsDaoRelatorioCadastrosMyFortic.Parametros.Add(new SqlParameter("p19", FiltroRelatorioViewModel.ListarRelatorioParametros.P19));
                var lstRelatorioCadastro = clsClass.RelatorioCadastrosMyForticProcedure("[201.77.209.53\\INTEGRA_PRD].MYFORTIC.[DBO].SP_REPORT_CADASTROS");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioNiveldeAdesao>());
            }
        }

        public ActionResult ReltorioEvolucaoMyFortic()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult ReltorioEvolucaoMyForticParcialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();
                var dados = String.Empty;

                clsClass.MclsDaoRelatorioEvolucaoMyFortic.Parametros.Add(new SqlParameter("p2", dtInicio.Year + "-" + dtInicio.Month + "-" + dtInicio.Day));
                clsClass.MclsDaoRelatorioEvolucaoMyFortic.Parametros.Add(new SqlParameter("p3", dtFim.Year + "-" + dtFim.Month + "-" + dtFim.Day));
                clsClass.MclsDaoRelatorioEvolucaoMyFortic.Parametros.Add(new SqlParameter("p19", FiltroRelatorioViewModel.ListarRelatorioParametros.P19));
                ViewBag.Selecionado = FiltroRelatorioViewModel.ListarRelatorioParametros.P19.Equals("0") ? "Todos" : FiltroRelatorioViewModel.ListarRelatorioParametros.P19;
                var lstRelatorioCadastro = clsClass.ReltorioEvolucaoMyForticProcedure("[201.77.209.53\\INTEGRA_PRD].MYFORTIC.[DBO].SP_REPORT_EVOLUCAO");
                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<RelatorioNiveldeAdesao>());
            }
        }

        public ActionResult RelatorioDiagnosticoTratamento()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioDiagnosticoTratamentoPartiaView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioDiagnosticoTratamento.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RelatorioDiagnosticoTratamentoProcedure("spReportDiagnosticoTratamento");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public ActionResult RelatorioCuidardorProMemoria()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioCuidardorProMemoriaPartialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioCuidardorProMemoria.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                var lstRelatorioCadastro = clsClass.RelatorioCuidardorProMemoriaProcedure("spReportCuidadoresProMemoria");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public ActionResult RelatorioOmnitropeGeral()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioOmnitropeGeralPartialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioOmnitropeGeral.Parametros.Add(new SqlParameter("p20", FiltroRelatorioViewModel.ListarRelatorioParametros.P20));
                var lstRelatorioCadastro = clsClass.RelatorioRelatorioOmnitropeGeralProcedure("spReportOmnitrope_Geral");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public ActionResult RelatorioOmnitropeFicha() {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioOmnitropeFichaPartialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioOmnitropeFicha.Parametros.Add(new SqlParameter("p20", FiltroRelatorioViewModel.ListarRelatorioParametros.P20));
                var lstRelatorioCadastro = clsClass.RelatorioRelatorioOmnitropeFichaProcedure("spReportOmnitrope_Ficha");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }

        public ActionResult RelatorioOmnitropeVisita()
        {
            //Inastância um novo argumento de parametro.
            FiltroRelatorioViewModel.ListarRelatorioParametros = InstanciaParametros();
            return View();
        }

        public PartialViewResult DadosRelatorioOmnitropeVisitaPartialView(string dataInicio, string dataFim)
        {
            try
            {
                var dtInicio = Convert.ToDateTime(dataInicio);
                var dtFim = Convert.ToDateTime(dataFim);
                var clsClass = new RelatorioRepositorio();

                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p1", RecuperaCodPrograma()));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p2", dtInicio.Day + "-" + dtInicio.Month + "-" + dtInicio.Year));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p3", dtFim.Day + "-" + dtFim.Month + "-" + dtFim.Year));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p4", FiltroRelatorioViewModel.ListarRelatorioParametros.P4));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p5", FiltroRelatorioViewModel.ListarRelatorioParametros.P5));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p6", FiltroRelatorioViewModel.ListarRelatorioParametros.P6));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p7", FiltroRelatorioViewModel.ListarRelatorioParametros.P7));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p8", FiltroRelatorioViewModel.ListarRelatorioParametros.P8));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p9", FiltroRelatorioViewModel.ListarRelatorioParametros.P9));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p10", FiltroRelatorioViewModel.ListarRelatorioParametros.P10));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p11", FiltroRelatorioViewModel.ListarRelatorioParametros.P11));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p12", FiltroRelatorioViewModel.ListarRelatorioParametros.P12));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p13", FiltroRelatorioViewModel.ListarRelatorioParametros.P13));
                clsClass.MclsDaoRelatorioOmnitropeVisita.Parametros.Add(new SqlParameter("p20", FiltroRelatorioViewModel.ListarRelatorioParametros.P20));
                var lstRelatorioCadastro = clsClass.RelatorioRelatorioOmnitropeVisitaProcedure("spReportOmnitrope_Visita");

                return PartialView(lstRelatorioCadastro);
            }
            catch
            {
                return PartialView(new List<Relatorio>());
            }
        }
    }
}