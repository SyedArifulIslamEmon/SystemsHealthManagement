using System.Collections.Generic;
using Integra.Dominio.Repositorios;

namespace Integra.Dominio.Servicos
{
    public class PerfilServico
    {
        private readonly IPerfilRepositorio _perfilRepositorio;

        public PerfilServico(IPerfilRepositorio perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }

        public Perfil AdicionarPerfil(string nome, Grupo grupo, List<Modulo> modulosPermitidos)
        {
            var perfil = new Perfil(grupo) { Nome = nome };
            foreach (var moduloPermitido in modulosPermitidos)
            {
                perfil.PermitirModulo(moduloPermitido);
            }
            _perfilRepositorio.Adicionar(perfil);
            return perfil;
        }
    }
}