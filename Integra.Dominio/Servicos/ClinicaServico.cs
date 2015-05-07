using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class ClinicaServico
    {
        private readonly IClinicaRepositorio _clinicaRepositorio;

        public ClinicaServico(IClinicaRepositorio clinicaRepositorio)
        {
            _clinicaRepositorio = clinicaRepositorio;
        }

        public Clinica AdicionarClinica(Programa programa, Funcionario responsavel, string nome, string razaoSocial, string cnpj,
            string inscricaoEstadual, string endereco, string cidade, string uf, string telefone, string contato, string observacoes, 
            StatusDaClinica status, string email, decimal valorInfusao, string bairro)
        {
            var clinica = new Clinica(programa, responsavel, nome, razaoSocial, cnpj, inscricaoEstadual, endereco, cidade, uf, telefone, contato
                , observacoes, status, email, valorInfusao, bairro);

            _clinicaRepositorio.Adicionar(clinica);

            return clinica;
        }
    }
}