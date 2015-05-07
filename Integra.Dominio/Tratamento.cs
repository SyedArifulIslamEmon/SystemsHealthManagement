using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Tratamento;
using System;

namespace Integra.Dominio
{
    public class Tratamento : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Programa Programa { get; set; }
        public virtual DateTime? DataSolicitacao { get; set; }
        public virtual string Ifx { get; set; }
        public virtual string Medico { get; set; }
        public virtual string Representante { get; set; }
        public virtual string MotivoSolicitacao { get; set; }
        public virtual StatusDoTratamento Status { get; set; }
        public virtual DateTime? DataStatus { get; set; }
        public virtual string Observacoes { get; set; }
        public virtual Pessoa Responsavel { get; set; }
        public virtual Grupo GrupoResponsavel { get; set; }
        public virtual string Indetificador { get; set; }

        protected override sealed void Validar()
        {
            if (Programa == null)
                AdicionarRegraQuebrada(RegrasDeNegocioTratamento.DeveTerUmPrograma);
            NotificarSeHouverAlgumErro();
        }

        public void ReprovadoPor(Pessoa responsavel, string observacoes)
        {
            Status = StatusDoTratamento.Negado;
            Responsavel = responsavel;
            DataStatus = SystemTime.Now;
            Observacoes = observacoes;
        }

        public void AprovadoPor(Pessoa responsavel, string observacoes)
        {
            Status = StatusDoTratamento.Autorizado;
            Responsavel = responsavel;
            DataStatus = SystemTime.Now;
            Observacoes = observacoes;
        }
    }

    public enum StatusDoTratamento
    {
        [StringValue("Aberto")]
        Aberto = 1,
        [StringValue("Autorizado")]
        Autorizado = 2,
        [StringValue("Negado")]
        Negado = 3
    }
}
