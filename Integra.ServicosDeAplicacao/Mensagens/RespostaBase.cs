using System.Collections.Generic;
using Integra.Dominio.Base.RegraDeNegocio;

namespace Integra.ServicosDeAplicacao.Mensagens
{
    public class RespostaBase
    {
        public RespostaBase()
        {
            Erros = new List<RegraDeNegocioBase>();
            Sucesso = false;
        }

        public bool Sucesso { get; set; }

        public List<RegraDeNegocioBase> Erros { get; set; }
    }
}