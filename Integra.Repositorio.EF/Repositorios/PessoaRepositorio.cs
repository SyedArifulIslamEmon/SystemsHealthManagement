using System.Collections.Generic;
using Integra.Dominio;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.Repositorios;
using System.Linq;

namespace Integra.Repositorio.EF.Repositorios
{
    public class PessoaRepositorio : Repositorio<Pessoa, int>, IPessoaRepositorio
    {
        public PessoaRepositorio(IUnitOfWork uow)
            : base(uow)
        {
        }

        public override Pessoa ObterPor(int codigo)
        {
            return GetObjectSet().SingleOrDefault(it => it.Codigo == codigo);
        }

        public Pessoa ObterPeloNomeDeUsuario(string nomeDoUsuario)
        {
            return
                GetObjectSet().FirstOrDefault(it => it.Usuario.NomeDeUsuario.ToUpper().Equals(nomeDoUsuario.ToUpper()));
        }

        public List<Pessoa> ObterTodosQueNaoEstejaNaReuniao(Reuniao reuniao)
        {
            return ObterTodos().Where(it => !reuniao.Participantes.Exists(e => e.Codigo == it.Codigo)).ToList();
        }

        public List<Pessoa> ObterTodosQueNaoEstejaNoTreinamento(Treinamento treinamento)
        {
            return ObterTodos().Where(it => !treinamento.Participantes.Exists(e => e.Codigo == it.Codigo)).ToList();
        }

        public List<Pessoa> ObterTodos(Programa programa)
        {
            var query = from pessoa in GetObjectSet()
                        from prog in pessoa.ProgramasPermitidos
                        where prog.Codigo == programa.Codigo
                        select pessoa;
            return query.ToList();
        }

        public void RemoverFoto(Arquivo foto)
        {
            DataContextFactory.GetDataContext().Set(foto.GetType()).Remove(foto);
        }
    }
}