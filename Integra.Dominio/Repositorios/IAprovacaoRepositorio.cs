using System.Collections.Generic;
using Integra.Dominio.Base.Repositorio;

namespace Integra.Dominio.Repositorios
{
    public interface IAprovacaoRepositorio : IRepositorio<Aprovacao, int>
    {
        IList<Aprovacao> ObterAprovacoesDoTipo(TipoDaAprovacao tipo);
    }
}