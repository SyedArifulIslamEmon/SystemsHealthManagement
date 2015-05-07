using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class Solicitacao : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual SituacaoDaSolicitacao Situacao { get; set; }
        public virtual AberturaDeSolicitacao Abertura { get; set; }
        public virtual AnaliseDeSolicitacao Analise { get; set; }
        public virtual AprovacaoDeSolicitacao Aprovacao { get; set; }
        public virtual ProcessoDaSolicitacao Processo { get; set; }
        public virtual EntregaDaSolicitacao Entrega { get; set; }
        protected override void Validar()
        {

        }
    }

    public enum SituacaoDaSolicitacao
    {
        [StringValue("Em Análise")]
        Analise,
        [StringValue("Para Aprovação")]
        Aprovacao,
        [StringValue("Em Processo")]
        Processo,
        [StringValue("Entregue")]
        Entregue,
        [StringValue("Finalizado")]
        Finalizado,
        [StringValue("Cancelado")]
        Cancelado
    }
}