using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class PessoaConfiguracao : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguracao()
        {
            HasKey(it => it.Codigo);
            Map<Funcionario>(it => it.Requires("TipoDaPessoa").HasValue<byte>(0));
            Map<Cliente>(it => it.Requires("TipoDaPessoa").HasValue<byte>(1));
            HasMany(it => it.ProgramasPermitidos).WithMany();
        }
    }
}