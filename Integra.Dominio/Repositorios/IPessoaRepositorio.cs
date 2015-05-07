using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa, int>
    {
        Pessoa ObterPeloNomeDeUsuario(string nomeDoUsuario);
        List<Pessoa> ObterTodosQueNaoEstejaNaReuniao(Reuniao reuniao);
        List<Pessoa> ObterTodosQueNaoEstejaNoTreinamento(Treinamento treinamento);
        void RemoverFoto(Arquivo foto);
    }
}