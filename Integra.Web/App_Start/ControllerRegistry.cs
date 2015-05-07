using System.Web.Configuration;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using Integra.Infra;
using Integra.Repositorio.EF;
using Integra.Repositorio.EF.Repositorios;

namespace Integra.Web.App_Start
{
    public class ControllerRegistry : StructureMap.Configuration.DSL.Registry
    {
        public ControllerRegistry()
        {
            ForSingletonOf<IUnitOfWork>().Use<EfUnitOfWork>();

            //// Repositorios 
            ForSingletonOf<IUsuarioRepositorio>().Use<UsuarioRepositorio>();
            ForSingletonOf<IModuloRepositorio>().Use<ModuloRepositorio>();
            ForSingletonOf<IPerfilRepositorio>().Use<PerfilRepositorio>();
            ForSingletonOf<ITipoDeCrmRepositorio>().Use<TipoDeCrmRepositorio>();
            ForSingletonOf<IGrupoRepositorio>().Use<GrupoRepositorio>();
            ForSingletonOf<ICargoRepositorio>().Use<CargoRepositorio>();
            ForSingletonOf<IDepartamentoRepositorio>().Use<DepartamentoRepositorio>();
            ForSingletonOf<IFuncionarioRepositorio>().Use<FuncionarioRepositorio>();
            ForSingletonOf<IPessoaRepositorio>().Use<PessoaRepositorio>();
            ForSingletonOf<IClienteRepositorio>().Use<ClienteRepositorio>();
            ForSingletonOf<IProgramaRepositorio>().Use<ProgramaRepositorio>();
            ForSingletonOf<IFaturaRepositorio>().Use<FaturaRepositorio>();
            ForSingletonOf<IEquipeRepositorio>().Use<EquipeRepositorio>();
            ForSingletonOf<IReuniaoRepositorio>().Use<ReuniaoRepositorio>();
            ForSingletonOf<IServicosContratadosRepositorio>().Use<ServicosContratadosRepositorio>();
            ForSingletonOf<ITreinamentoRepositorio>().Use<TreinamentoRepositorio>();
            ForSingletonOf<IAprovacaoRepositorio>().Use<AprovacaoRepositorio>();
            ForSingletonOf<ITratamentoRepositorio>().Use<TratamentoRepositorio>();
            ForSingletonOf<ISolicitacaoRepositorio>().Use<SolicitacaoRepositorio>();
            ForSingletonOf<ITipoDaSolicitacaoRepositorio>().Use<TipoDaSolicitacaoRepositorio>();
            ForSingletonOf<IClinicaRepositorio>().Use<ClinicaRepositorio>();
            ForSingletonOf<IRepresentanteRepositorio>().Use<RepresentanteRepositorio>();
            ForSingletonOf<IRepresentanteRegionalRepositorio>().Use<RepresentanteRegionalRepositorio>();
            ForSingletonOf<IGerenteRepositorio>().Use<GerenteRepositorio>();
            ForSingletonOf<IInfusaoRepositorio>().Use<InfusaoRepositorio>();
            ForSingletonOf<INotaFiscalRepositorio>().Use<NotaFiscalRepositorio>();
            ForSingletonOf<IClinicaDocumentoRepositorio>().Use<ClinicaDocumentoRepositorio>();
            

            ForSingletonOf<ServicoDeEmail>().Use(it => new ServicoDeEmail(WebConfigurationManager.AppSettings["SmtpTo"]));
        }
    }
}