using System;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Aprovacao : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Pessoa ResponsavelPelaAprovacao { get; set; }
        public virtual string Titulo { get; set; }
        public virtual Grupo GrupoResponsavel { get; set; }
        public virtual StatusDaAprovacao Status { get; set; }
        public virtual DateTime? DataDaAprovacao { get; set; }
        public virtual Arquivo Anexo { get; set; }
        public virtual TipoDaAprovacao Tipo { get; set; }
        public virtual Programa Programa { get; set; }

        protected override void Validar()
        {
            NotificarSeHouverAlgumErro();
        }

        public void ReprovadoPor(Pessoa responsavel)
        {
            Status = StatusDaAprovacao.Reprovado;
            ResponsavelPelaAprovacao = responsavel;
            DataDaAprovacao = SystemTime.Now;
        }

        public void AprovadoPor(Pessoa responsavel)
        {
            Status = StatusDaAprovacao.Aprovado;
            ResponsavelPelaAprovacao = responsavel;
            DataDaAprovacao = SystemTime.Now;
        }
    }

    public enum TipoDaAprovacao
    {
        [StringValue("Escopo")]
        Escopo,
        [StringValue("Mudança")]
        Mudanca,
        [StringValue("Script")]
        Script,
        [StringValue("Material")]
        Material,
        [StringValue("Interno")]
        Interno
    }

    public enum StatusDaAprovacao
    {
        [StringValue("Pendente")]
        Pendente,
        [StringValue("Aprovado")]
        Aprovado,
        [StringValue("Reprovado")]
        Reprovado
    }
}