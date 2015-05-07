using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Equipe
{
    public class AdicionarMembrosNaEquipeRequisicao
    {
        public int CodigoDaEquipe { get; set; }

        public List<int> CodigosDosFuncionarios { get; set; }
    }
}