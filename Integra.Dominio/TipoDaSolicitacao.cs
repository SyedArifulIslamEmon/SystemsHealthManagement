using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{
    public class TipoDaSolicitacao : EntidadeBase<int>, IRaizDeAgregacao
    {
        public string Descricao { get; set; }
        public int SLA { get; set; }
        protected override void Validar()
        {
        }
    }
}