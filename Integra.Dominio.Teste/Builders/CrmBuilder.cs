namespace Integra.Dominio.Teste.Builders
{
    public class CrmBuilder
    {
        private CrmBuilder()
        {

        }
        public static CrmBuilder DadoUmCRM()
        {
            return new CrmBuilder();
        }

        public CRM Build()
        {
            return new CRM("numeroDoCrm", new TipoDeCrm("UmaDescricao", ""),"");
        }
    }
}