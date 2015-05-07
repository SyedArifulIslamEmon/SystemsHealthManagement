using System;
using System.Collections.Generic;
using Integra.Dominio;

namespace Integra.ServicosDeAplicacao.Mensagens.Reuniao
{
    public class AdicionarReuniaoRequisicao
    {
        public int CodigoDoResponsavel { get; set; }
        public int CodigoDoPrograma { get; set; }
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Realizacao { get; set; }
        public StatusDaReunicao Status { get; set; }
    }
}