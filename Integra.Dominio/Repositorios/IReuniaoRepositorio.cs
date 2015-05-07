using Integra.Dominio.Base.Repositorio;
using System.Collections.Generic;

namespace Integra.Dominio.Repositorios
{
    public interface IReuniaoRepositorio : IRepositorio<Reuniao, int>
    {
        List<Reuniao> ObterTodos(Programa programa);
        Ata ObterAtaDaReuniao(int codigoDaReuniao, int codigoDaAta);
        Arquivo ObterAnexoDeUmaAta(int codigoDaReuniao, int codigoDaAta, int codigoDoAnexo);
    }
}