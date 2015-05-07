namespace Integra.Dominio.Base.RegraDeNegocio
{
    public class RegraDeNegocioBase
    {
        public string Mensagem { get; set; }

        public RegraDeNegocioBase(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}