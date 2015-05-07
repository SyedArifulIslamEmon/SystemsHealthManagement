using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Perfil;

namespace Integra.Dominio
{
    public class Perfil : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual List<Modulo> ModulosPermitidos { get; private set; }
        public virtual string Nome { get; set; }
        public virtual Grupo Grupo { get; private set; }

        protected Perfil()
        {
            
        }

        public Perfil(Grupo grupo)
        {
            Grupo = grupo;
            ModulosPermitidos = new List<Modulo>();
            Validar();
        }

        public bool ModuloEhPermitido(Modulo modulo)
        {
            return ModulosPermitidos.Contains(modulo);
        }

        protected override sealed void Validar()
        {
            if (Grupo == null)
                AdicionarRegraQuebrada(RegrasDeNegocioPerfil.DeveConterUmGrupo);
            NotificarSeHouverAlgumErro();
        }

        public void PermitirModulo(Modulo modulo)
        {
            ModulosPermitidos.Add(modulo);
        }
    }
}