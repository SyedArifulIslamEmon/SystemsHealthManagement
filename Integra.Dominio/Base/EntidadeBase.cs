using System.Linq;
using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.Dominio.Base
{
    public abstract class EntidadeBase<TCodigo>
    {
        private readonly RegraException _regraDeNegocio;
        public virtual TCodigo Codigo { get; set; }

        protected EntidadeBase()
        {
            _regraDeNegocio = new RegraException();
        }

        public void AdicionarRegraQuebrada(RegraDeNegocioBase regraDeNegocio)
        {
            _regraDeNegocio.AdicionarErroPara(regraDeNegocio);
        }

        public void RegraQuebrada(RegraDeNegocioBase regraDeNegocio)
        {
            AdicionarRegraQuebrada(regraDeNegocio);
            NotificarSeHouverAlgumErro();
        }

        protected abstract void Validar();

        public void NotificarSeHouverAlgumErro()
        {
            if (_regraDeNegocio.Erros.Any())
                throw _regraDeNegocio;
        }
    }
}