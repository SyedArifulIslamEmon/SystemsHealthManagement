namespace Integra.Dominio.Servicos
{
    public class EquipeServico
    {
        public Equipe AdicionarMembroNaEquipe(Equipe equipe, Funcionario membro)
        {
            equipe.AdicionarMembro(membro);
            return equipe;
        }
    }
}