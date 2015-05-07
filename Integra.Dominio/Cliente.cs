using System.Collections.Generic;
using Integra.Dominio.RegrasDeNegocio.Pessoa;

namespace Integra.Dominio
{
    public class Cliente : Pessoa
    {
        //public virtual CRM Crm { get; set; }

        protected Cliente()
        {

        }
        public Cliente(Usuario usuario, string nome, string telefone, List<Programa> programa)
            : base(usuario, nome, telefone, programa)
        {
            Validar();
        }

        protected override sealed void Validar()
        {
            base.Validar();
        }

        public void InformarCrm(CRM crm)
        {
            if(crm == null)
                RegraQuebrada(RegrasDeNegocioPessoa.NaoPodeInformarUmCrmVazio);
            Crm = crm;
        }
    }
}