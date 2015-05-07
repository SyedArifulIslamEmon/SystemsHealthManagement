using System.Collections.Generic;
using Integra.Dominio.Teste.Helpers;

namespace Integra.Dominio.Teste.Builders
{
    public class FuncionarioBuilder
    {
        private Usuario _usuario;
        private Departamento _departamento;
        private Cargo _cargo;
        private List<Programa> _programa;
        private int _codigo;

        private FuncionarioBuilder()
        {
            _usuario = UsuarioBuilder.DadoUmUsuario().Build();
            _departamento = DepartamentoBuilder.DadoUmDepartamento().Build();
            _cargo = CargoBuilder.DadoUmCargo().Build();
            _programa = ProgramaBuilder.DadoUmPrograma().Build();
        }

        public static FuncionarioBuilder DadoUmFuncionario()
        {
            return new FuncionarioBuilder();
        }

        public Funcionario Build()
        {
            var funcionario = new Funcionario(_usuario, "Um NOme", "12311132312", _departamento, _cargo, _programa);
            funcionario.Setar(it => it.Codigo, _codigo);
            return funcionario;
        }

        public FuncionarioBuilder ComOCogio(int codigo)
        {
            _codigo = codigo;
            return this;
        }
    }
}