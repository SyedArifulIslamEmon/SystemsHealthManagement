using System.Collections.Generic;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class ClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente AdicionarUmNovoCliente(string nome, string telefone, bool inativo, Usuario usuario, List<Programa> programa)
        {
            var cliente = new Cliente(usuario, nome, telefone, programa);
            if (inativo)
                cliente.Inativar();
            _clienteRepositorio.Adicionar(cliente);
            return cliente;
        }
    }
}