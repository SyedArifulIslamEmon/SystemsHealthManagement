using Integra.Infra;
using Integra.ServicosDeAplicacao.Mensagens.Ovidoria;

namespace Integra.ServicosDeAplicacao
{
    public class OuvidoriaServicoDeAplicacao
    {
        private readonly ServicoDeEmail _servicoDeEmail;

        public OuvidoriaServicoDeAplicacao(ServicoDeEmail servicoDeEmail)
        {
            _servicoDeEmail = servicoDeEmail;
        }

        public AdicionarOuvidoriaResposta AdicionarOuvidoria(AdicionarOuvidoriaRequisicao requisicao)
        {
            var resposta = new AdicionarOuvidoriaResposta
                               {
                                   Sucesso = _servicoDeEmail.EnviarEmail(requisicao.Assunto, requisicao.Mensagem)
                               };
            return resposta;
        }
    }
}