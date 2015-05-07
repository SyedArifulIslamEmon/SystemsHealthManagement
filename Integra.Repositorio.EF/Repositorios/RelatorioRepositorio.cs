using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Integra.Dominio;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{

    public class RelatorioRepositorio : DaoBase<Relatorio>
    {
        internal string MstrProcedure = "";
        public DaoBase<FiltroRelatorio> MclsDaoFiltroRelatorio = new DaoBase<FiltroRelatorio>();
        public DaoBase<RelatorioRankingCadastro> MclsDaoRelatorioRankingCadastro = new DaoBase<RelatorioRankingCadastro>();
        public DaoBase<RelatorioEvoPacCadastro> MclsDaoRelatorioEvoPacCadastro = new DaoBase<RelatorioEvoPacCadastro>();
        public DaoBase<RelatorioDesempenhoAcesso> MclsDaoRelatorioDesempenhoAcesso = new DaoBase<RelatorioDesempenhoAcesso>();
        public DaoBase<RelatorioEfetividadeAcesso> MclsDaoRelatorioEfetividadeAcesso = new DaoBase<RelatorioEfetividadeAcesso>();
        public DaoBase<RelatorioPacientesInativados> MclsDaoRelatorioPacientesInativados = new DaoBase<RelatorioPacientesInativados>();
        public DaoBase<RelatorioPacientesAtivos> MclsDaoRelatorioPacientesAtivos = new DaoBase<RelatorioPacientesAtivos>();
        public DaoBase<RelatorioEvoCadastroSemana> MclsDaoRelatorioEvoCadastroSemana = new DaoBase<RelatorioEvoCadastroSemana>();
        public DaoBase<RelatorioInfusoesAplicacao> MclsDaoRelatorioInfusoesAplicacao = new DaoBase<RelatorioInfusoesAplicacao>();
        public DaoBase<RelatorioListagemPacientes> MclsDaoRelatorioListagemPacientes = new DaoBase<RelatorioListagemPacientes>();
        public DaoBase<RelatorioQuantidadePacientesAtivos> MclsDaoRelatorioQuantidadePacientesAtivos = new DaoBase<RelatorioQuantidadePacientesAtivos>();
        public DaoBase<RelatorioEspecialidadeMedica> MclsDaoRelatorioEspecialidadeMedica = new DaoBase<RelatorioEspecialidadeMedica>();
        public DaoBase<RelatorioentregaAmostrasZoteon> MclsDaoRelatorioentregaAmostrasZoteon = new DaoBase<RelatorioentregaAmostrasZoteon>();
        public DaoBase<RelatorioentregaAmostrasZoteonTotal> MclsDaoRelatorioentregaAmostrasZoteonTotal = new DaoBase<RelatorioentregaAmostrasZoteonTotal>();
        public DaoBase<RelatorioOrigemCadastro> MclsDaoRelatorioOrigemCadastro = new DaoBase<RelatorioOrigemCadastro>();
        public DaoBase<RelatorioRitalinaporFase> MclsDaoRelatorioRitalinaporFase = new DaoBase<RelatorioRitalinaporFase>();
        public DaoBase<RelatorioNiveldeAdesao> MclsDaoRelatorioNivelAdesaoMyFortic = new DaoBase<RelatorioNiveldeAdesao>();
        public DaoBase<RelatorioCadastrosMyFortic> MclsDaoRelatorioCadastrosMyFortic = new DaoBase<RelatorioCadastrosMyFortic>();
        public DaoBase<RelatorioEvolucaoMyFortic> MclsDaoRelatorioEvolucaoMyFortic = new DaoBase<RelatorioEvolucaoMyFortic>();
        public DaoBase<RelatorioDiagnosticoTratamento> MclsDaoRelatorioDiagnosticoTratamento = new DaoBase<RelatorioDiagnosticoTratamento>();
        public DaoBase<RelatorioCuidadorProMemoria> MclsDaoRelatorioCuidardorProMemoria = new DaoBase<RelatorioCuidadorProMemoria>();
        public DaoBase<RelatorioOmnitropeGeral> MclsDaoRelatorioOmnitropeGeral = new DaoBase<RelatorioOmnitropeGeral>();
        public DaoBase<RelatorioOmnitropeFicha> MclsDaoRelatorioOmnitropeFicha = new DaoBase<RelatorioOmnitropeFicha>();
        public DaoBase<RelatorioOmnitropeVisita> MclsDaoRelatorioOmnitropeVisita = new DaoBase<RelatorioOmnitropeVisita>();

        public RelatorioRepositorio()
        {
        }

        /// <summary>
        /// Ao instanciar a classe RelatorioRepositorio passando o parametro de 
        /// </summary>
        /// <param name="pstrParametro">Tipo de caixa P1 ~ P18</param>
        /// <param name="pstrRecuperaPrograma">Cod do programa (GUID)</param>
        public RelatorioRepositorio(string pstrParametro, string pstrRecuperaPrograma)
        {
            var strProcConfig = RecuperarFiltroProcedure(pstrParametro);
            SetProcedure = strProcConfig[0]; //Nome da procedure.
            if (strProcConfig[1] != "") { MclsDaoFiltroRelatorio.Parametros.Add(new SqlParameter(strProcConfig[1], pstrRecuperaPrograma)); } //Parametro 1 da procedure PROGRAMA.
            if (strProcConfig[2] != "") { MclsDaoFiltroRelatorio.Parametros.Add(new SqlParameter(strProcConfig[2], DBNull.Value)); } //Parametro 2 da procedure.
        }

        public string SetProcedure
        {
            get { return MstrProcedure; }
            set { MstrProcedure = value; }
        }

        public DaoBase<FiltroRelatorio> SetDaoRelatorio
        {
            get { return MclsDaoFiltroRelatorio; }
            set { MclsDaoFiltroRelatorio = value; }
        }


        public List<Relatorio> RetornarRelatorioCadastro()
        {
            return ExecutarLista();
        }
        public List<Relatorio> RetornarRelatorioCadastroProcedure(string pstrProcedure)
        {
            return ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioRankingCadastro> RetornarRelatorioCadastroRkProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioRankingCadastro.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioEvoPacCadastro> RetornarRelatorioEvoPacCadastroProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioEvoPacCadastro.ExecutarListaProcedure(pstrProcedure);
        }
        public List<RelatorioDesempenhoAcesso> RetornarRelatorioDesempenhoAcessoProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioDesempenhoAcesso.ExecutarListaProcedure(pstrProcedure);
        }
        public List<RelatorioEfetividadeAcesso> RetornarRelatorioEfetividadeAcessoProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioEfetividadeAcesso.ExecutarListaProcedure(pstrProcedure);
        }
        public List<RelatorioPacientesInativados> RetornarRelatorioPacientesInativadosProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioPacientesInativados.ExecutarListaProcedure(pstrProcedure);
        }
        public List<RelatorioPacientesAtivos> RetornarRelatorioPacientesAtivosProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioPacientesAtivos.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioEvoCadastroSemana> RetornarRelatorioEvoCadastroSemanaProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioEvoCadastroSemana.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioInfusoesAplicacao> RetornarRelatorioInfusoesAplicacaoProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioInfusoesAplicacao.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioListagemPacientes> RetornarListagemPacientesProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioListagemPacientes.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioQuantidadePacientesAtivos> RetornarQuantidadePacientesAtivosProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioQuantidadePacientesAtivos.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioEspecialidadeMedica> RetornarRelatorioEspecialidadeMedicaProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioEspecialidadeMedica.ExecutarListaProcedure(pstrProcedure);
        }

        public SqlDataReader RetornarRelatorioEfetividadeAcessoGrafico(string pstrProcedure)
        {
            return ExecutarDataReaderProcedure(pstrProcedure);
        }

        public SqlDataReader RetornarRelatorioEvoPacienteDoencaGrafico(string pstrProcedure)
        {
            return ExecutarDataReaderProcedure(pstrProcedure);
        }

        public List<FiltroRelatorio> ExecutarFiltroProc()
        {
            if (SetProcedure != "")
            {
                return MclsDaoFiltroRelatorio.ExecutarListaProcedure(MstrProcedure);
            }
            return new List<FiltroRelatorio>();
        }

        public string Filtros(string pstrParametro)
        {
            switch (pstrParametro.ToUpper())
            {
                case "P1":
                    return "Tipo de Período";
                case "P2":
                    return "Data Inicial";
                case "P3":
                    return "Data Final";
                case "P4":
                    return "Medicamento";
                case "P5":
                    return "Doença";
                case "P6":
                    return "Situação";
                case "P7":
                    return "Fase";
                case "P8":
                    return "Estado";
                case "P9":
                    return "Cidade";
                case "P10":
                    return "Especialidade";
                case "P11":
                    return "Médico";
                case "P12":
                    return "Gerente Consultor";
                case "P13":
                    return "Consultor";
                case "P14AGRUPAR":
                    return "Agrupar";
                case "P14GERENTE_PROMOTOR":
                    return "Gerente Promotor";
                case "P15":
                    return "Promotor";
                case "P16":
                    return "Centro de Referência";
                case "P17":
                    return "Status 1a. amostra";
                case "P18":
                    return "Status 2a. amostra";
                case "P19":
                    return "Instituição";
                case "P20":
                    return "Tipo de Paciente";
                default:
                    return "";
            }
        }

        public string[] RecuperarFiltroProcedure(string pstrParametro)
        {
            var strProcConfig = new string[3];
            switch (pstrParametro.ToUpper())
            {
                case "P1":
                    strProcConfig[0] = "Tipo de Período";
                    return strProcConfig;
                case "P2":
                    strProcConfig[0] = "Data Inicial";
                    return strProcConfig;
                case "P3":
                    strProcConfig[0] = "Data Final";
                    return strProcConfig;
                case "P4":
                    strProcConfig[0] = "spFiltroMedicamentoByName";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "medicamento";
                    return strProcConfig;
                case "P5":
                    strProcConfig[0] = "spFiltroDoencaByName";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "doenca";
                    return strProcConfig;
                case "P6":
                    strProcConfig[0] = "spFiltroSituacaoByName";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "situacao";
                    return strProcConfig;
                case "P7":
                    strProcConfig[0] = "spFiltroFaseByName";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "fase";
                    return strProcConfig;
                case "P8":
                    strProcConfig[0] = "spFiltroEstadoByName";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "estado";
                    return strProcConfig;
                case "P9":
                    strProcConfig[0] = "spFiltroCidadeByName";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "cidade";
                    return strProcConfig;
                case "P10":
                    strProcConfig[0] = "spFiltroEspecialidadeByName";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "especialidade";
                    return strProcConfig;
                case "P11":
                    strProcConfig[0] = "spFiltroMedicoByNameMVC";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "medico";
                    return strProcConfig;
                case "P12":
                    strProcConfig[0] = "spFiltroGerenteByProgram";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P13":
                    strProcConfig[0] = "spFiltroRepresentanteByProgram";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P14AGRUPAR":
                    strProcConfig[0] = "Agrupar";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "medicamento";
                    return strProcConfig;
                case "P14GERENTE_PROMOTOR":
                    strProcConfig[0] = "spFiltroGerente2ByProgram";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P15":
                    strProcConfig[0] = "spFiltroRepresentante2ByProgram";
                    strProcConfig[1] = "programa";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P16":
                    strProcConfig[0] = "spFiltroCentro";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P17":
                    strProcConfig[0] = "spFiltroStatusPrimeiraAmostra";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P18":
                    strProcConfig[0] = "spFiltroStatusSegundaAmostra";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P19":
                    strProcConfig[0] = "[201.77.209.53\\INTEGRA_PRD].MYFORTIC.[DBO].SP_LISTAR_INSTITUICAO";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "";
                    return strProcConfig;
                case "P20":
                    strProcConfig[0] = "spFiltroTipo";
                    strProcConfig[1] = "";
                    strProcConfig[2] = "";
                    return strProcConfig;
                default:
                    strProcConfig[0] = "";
                    return strProcConfig;
            }
        }

        //public string RecuperaPrograma()
        //{
        //    return ConfigurationManager.AppSettings["Programa"];
        //}
        //public string RecuperaCodPrograma()
        //{
        //    return ConfigurationManager.AppSettings["CodPrograma"];
        //}

        public string RetornarAgrupamento(string idAgrupar)
        {
            switch (idAgrupar)
            {
                case "1":
                    return "Representante";
                case "2":
                    return "Gerente";
                case "3":
                    return "Médico";
                case "4":
                    return "Cidade";
                case "5":
                    return "Estado";
                case "6":
                    return "Medicamento";
                case "7":
                    return "Doença";
            }
            return "";
        }

        public List<RelatorioentregaAmostrasZoteon> RetornarRelatorioentregaAmostrasZoteonProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioentregaAmostrasZoteon.ExecutarListaProcedure(pstrProcedure);
        }

        public RelatorioentregaAmostrasZoteonTotal RetornarRelatorioentregaAmostrasZoteonTotalProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioentregaAmostrasZoteonTotal.ExecutarListaProcedure(pstrProcedure).FirstOrDefault();
        }

        public List<RelatorioOrigemCadastro> RetornarRelatorioOrigemCadastroProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioOrigemCadastro.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioRitalinaporFase> RetornarRelatorioRitalinaporFaseProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioRitalinaporFase.ExecutarListaProcedure(pstrProcedure);
        }

        public RelatorioRitalinaporFase RetornarTotalRelatorioRitalinaporFaseModel()
        {
            return new RelatorioRitalinaporFase();
        }

        public List<RelatorioNiveldeAdesao> RelatorioNivelAdesaoMyForticProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioNivelAdesaoMyFortic.ExecutarListaProcedure(pstrProcedure);
        }

        public RelatorioNiveldeAdesao RetornarTotalRelatorioNivelAdesaoMyFortic()
        {
            return new RelatorioNiveldeAdesao();
        }

        public List<RelatorioCadastrosMyFortic> RelatorioCadastrosMyForticProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioCadastrosMyFortic.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioEvolucaoMyFortic> ReltorioEvolucaoMyForticProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioEvolucaoMyFortic.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioDiagnosticoTratamento> RelatorioDiagnosticoTratamentoProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioDiagnosticoTratamento.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioCuidadorProMemoria> RelatorioCuidardorProMemoriaProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioCuidardorProMemoria.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioOmnitropeGeral> RelatorioRelatorioOmnitropeGeralProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioOmnitropeGeral.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioOmnitropeFicha> RelatorioRelatorioOmnitropeFichaProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioOmnitropeFicha.ExecutarListaProcedure(pstrProcedure);
        }

        public List<RelatorioOmnitropeVisita> RelatorioRelatorioOmnitropeVisitaProcedure(string pstrProcedure)
        {
            return MclsDaoRelatorioOmnitropeVisita.ExecutarListaProcedure(pstrProcedure);        
        }

    }
}
