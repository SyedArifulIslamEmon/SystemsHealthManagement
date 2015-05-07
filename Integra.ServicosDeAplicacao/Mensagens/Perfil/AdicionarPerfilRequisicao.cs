using System.Collections.Generic;

namespace Integra.ServicosDeAplicacao.Mensagens.Perfil
{
    public class AdicionarPerfilRequisicao
    {
        public int CodigoDoGrupo { get; set; }

        public List<int> CodigosDosModulosPermitidos { get; set; }

        public string Nome { get; set; }
    }
}