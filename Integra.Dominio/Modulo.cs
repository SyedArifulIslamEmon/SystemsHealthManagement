using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using System.Linq;

namespace Integra.Dominio
{
    public class Modulo : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual List<Perfil> Perfils { get; set; }

        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public bool TemPermissao(Usuario usuario)
        {
            return Perfils.Any(perfil=>perfil.Codigo == usuario.Perfil.Codigo);
        }

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}