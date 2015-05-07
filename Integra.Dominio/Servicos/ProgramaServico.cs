using System.Collections.Generic;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class ProgramaServico
    {
        private readonly IProgramaRepositorio _programaRepositorio;

        public ProgramaServico(IProgramaRepositorio programaRepositorio)
        {
            _programaRepositorio = programaRepositorio;
        }

        public Programa AdicionarPrograma(string nome, string descricao, string identificador, int codigoAuxiliar)
        {
            var programa = new Programa()
                               {
                                   Nome = nome,
                                   Descricao = descricao,
                                   IdentPrograma = identificador,
                                   CodPrograma = codigoAuxiliar
                               };
            _programaRepositorio.Adicionar(programa);
            return programa;
        }
    }
}
