using System.Collections.Generic;
using System.IO;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarAnexoEmUmaAtaRequisicao
    {
        public int CodigoDaReuniao { get; set; }

        public int CodigoDaAta { get; set; }

        public Stream Arquivo { get; set; }

        public string NomeDoArquivo { get; set; }

        public string Descricao { get; set; }
    }
}