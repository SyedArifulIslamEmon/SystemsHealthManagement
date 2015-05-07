using System.Collections.Generic;
using Integra.Dominio.RegrasDeNegocio.Pessoa;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class FuncionarioServico
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IGrupoRepositorio _grupoRepositorio;

        public FuncionarioServico(IFuncionarioRepositorio funcionarioRepositorio, IGrupoRepositorio grupoRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _grupoRepositorio = grupoRepositorio;
        }

        public Funcionario AdicionarUmNovoFuncionario(string nome, string telefone, Usuario usuario, Departamento departamento, 
            Cargo cargo, List<Programa> programa, string descricao)
        {
            var grupo = _grupoRepositorio.ObterGrupoIntegra();
            var funcionario = new Funcionario(usuario, nome, telefone, departamento, cargo, programa) { Descricao = descricao };
            if (!usuario.PertenceAoGrupo(grupo))
                funcionario.RegraQuebrada(RegrasDeNegocioPessoa.DevePertencerAoGrupoIntegraParaTerUmDepartamento);

            _funcionarioRepositorio.Adicionar(funcionario);

            return funcionario;
        }
    }
}