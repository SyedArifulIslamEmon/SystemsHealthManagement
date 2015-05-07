using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Grupo;

namespace Integra.Dominio
{
    public class Grupo : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual string Descricao { get; private set; }
        public virtual string Nome { get; set; }

        protected Grupo() { }

        public Grupo(string descricao)
        {
            Descricao = descricao;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descricao))
                AdicionarRegraQuebrada(RegrasDeNegocioGrupo.DeveConterUmaDescricaoValida);
            NotificarSeHouverAlgumErro();
        }

        public enum Grupos
        {
            [StringValue("Íntegra")]
            Integra,
            [StringValue("Cliente")]
            Cliente
        }
    }
}