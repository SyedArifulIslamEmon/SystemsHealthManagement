using System.Collections.Generic;
using Integra.Dominio.RegrasDeNegocio.Pessoa;

namespace Integra.Dominio
{
    public class Funcionario : Pessoa
    {
        public virtual Departamento Departamento { get;  set; }
        public virtual Cargo Cargo { get;  set; }
        public virtual string Descricao { get;  set; }

        protected Funcionario() { }

        public Funcionario(Usuario usuario, string nome, string telefone, Departamento departamento, Cargo cargo, List<Programa> programa)
            : base(usuario, nome, telefone, programa)
        {
            Departamento = departamento;
            Cargo = cargo;
            Validar();
        }

        protected override sealed void Validar()
        {
            base.Validar();
            if (ProgramasPermitidos == null)
                AdicionarRegraQuebrada(RegrasDeNegocioPessoa.DeveTerUmPrograma);
            if (Departamento == null)
                AdicionarRegraQuebrada(RegrasDeNegocioPessoa.DoGrupoDeveConterUmDepartamento);
            if (Cargo == null)
                AdicionarRegraQuebrada(RegrasDeNegocioPessoa.DeveTerUmCargo);
            NotificarSeHouverAlgumErro();
        }

        public void AdicionarDescricao(string novaDescricao)
        {
            Descricao = novaDescricao;
        }
    }
}