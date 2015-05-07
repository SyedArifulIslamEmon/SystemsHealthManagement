using System.Collections.Generic;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;

namespace Integra.Dominio
{

    public class Pessoa : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual Usuario Usuario { get;  set; }
        public virtual string Nome { get;  set; }
        public virtual string Telefone { get;  set; }
        public virtual bool Inativo { get;  set; }
        public virtual List<Programa> ProgramasPermitidos { get; set; }
        public virtual Arquivo Foto { get;  set; }
        public virtual CRM Crm { get ; set; }

        protected Pessoa()
        {

        }

        public Pessoa(Usuario usuario, string nome, string telefone, List<Programa> programa)
        {
            Usuario = usuario;
            Nome = nome;
            Telefone = telefone;
            ProgramasPermitidos = programa;
            Inativo = false;
        }

        protected override void Validar()
        {
            NotificarSeHouverAlgumErro();
        }

        public void Inativar()
        {
            Inativo = true;
        }
    }
}