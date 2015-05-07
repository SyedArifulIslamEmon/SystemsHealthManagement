using System.Data.Entity.ModelConfiguration;
using Integra.Dominio;

namespace Integra.Repositorio.EF.Configuracoes
{
    public class ReuniaoConfiguracao : EntityTypeConfiguration<Reuniao>
    {
        public ReuniaoConfiguracao()
        {
            HasKey(it => it.Codigo);
            HasMany(it => it.Participantes).WithMany();
            HasMany(it => it.Anexos).WithMany();
            HasRequired(it => it.Programa);
            HasRequired(it => it.Responsavel);
            Property(it => it.Criacao).IsRequired();
            Property(it => it.Local).IsRequired();
            Property(it => it.Assunto).IsRequired();
            Property(it => it.Realizacao).IsRequired();
            Property(it => it.Status).IsRequired();
        }
    }
}