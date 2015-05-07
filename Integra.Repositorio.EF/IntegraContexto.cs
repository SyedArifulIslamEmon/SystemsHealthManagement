using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;
using Integra.Repositorio.EF.Configuracoes;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Integra.Repositorio.EF
{
    public class IntegraContexto : DbContext
    {
        public IntegraContexto()
            : base("IntegraConnectionString")
        {
        }

        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<TipoDeCrm> TiposDeCrm { get; set; }
        public DbSet<CRM> Crms { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<ServicosContratados> ServicosContratados { get; set; }
        public DbSet<Treinamento> Treinamento { get; set; }
        public DbSet<Ata> Atas { get; set; }
        public DbSet<Aprovacao> Aprovacoes { get; set; }
        public DbSet<Tratamento> Tratamento { get; set; }
        public DbSet<TipoDaSolicitacao> TiposDasSolicitacoes { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<ClinicaDocumentos> ClinicaDocumentos { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<RepresentanteRegional> RepresentantesRegionais { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Infusao> Infusoes { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Estorno> Estornos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IntegraContexto, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ArquivoConfiguracao());
            modelBuilder.Configurations.Add(new ModuloConfiguracao());
            modelBuilder.Configurations.Add(new PerfilConfiguracao());
            modelBuilder.Configurations.Add(new UsuarioConfiguracao());
            modelBuilder.Configurations.Add(new GrupoConfiguracao());
            modelBuilder.Configurations.Add(new TipoDeCrmConfiguracao());
            modelBuilder.Configurations.Add(new CrmConfiguracao());
            modelBuilder.Configurations.Add(new CargoConfiguracao());
            modelBuilder.Configurations.Add(new DepartamentoConfiguracao());
            modelBuilder.Configurations.Add(new PessoaConfiguracao());
            modelBuilder.Configurations.Add(new ProgramaConfiguracao());
            modelBuilder.Configurations.Add(new FaturaConfiguracao());
            modelBuilder.Configurations.Add(new EquipeConfiguracao());
            modelBuilder.Configurations.Add(new ReuniaoConfiguracao());
            modelBuilder.Configurations.Add(new ServicosContratadosConfiguracao());
            modelBuilder.Configurations.Add(new TreinamentoConfiguracao());
            modelBuilder.Configurations.Add(new AtasConfiguracao());
            modelBuilder.Configurations.Add(new AprovacaoConfiguracao());
            modelBuilder.Configurations.Add(new TratamentoConfiguracao());
            modelBuilder.Configurations.Add(new TipoDaSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new SolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new AberturaDeSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new AnaliseDeSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new AprovacaoDeSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new ProcessoDaSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new EntregaDaSolicitacaoConfiguracao());
            modelBuilder.Configurations.Add(new ClinicaConfiguracao());
            modelBuilder.Configurations.Add(new ClinicaDocumentosConfiguracao());
            modelBuilder.Configurations.Add(new RepresentanteConfiguracao());
            modelBuilder.Configurations.Add(new RepresentanteRegionalConfiguracao());
            modelBuilder.Configurations.Add(new GerenteConfiguracao());
            modelBuilder.Configurations.Add(new InfusaoConfiguracao());
            modelBuilder.Configurations.Add(new NotasFiscaisConfiguracao());
            modelBuilder.Configurations.Add(new PagamentoConfiguracao());
            modelBuilder.Configurations.Add(new EstornoConfiguracao());
        }
    }

    public class EstornoConfiguracao : EntityTypeConfiguration<Estorno>
    {
        public EstornoConfiguracao()
        {
            HasKey(it => it.Codigo);
        }
    }
}