using System;
using System.Text.RegularExpressions;
using Integra.Dominio.Base;
using Integra.Dominio.Base.UoW;
using Integra.Dominio.RegrasDeNegocio.Usuario;

namespace Integra.Dominio
{
    public class Usuario : EntidadeBase<int>, IRaizDeAgregacao
    {
        public virtual DateTime PenultimoAcesso { get; private set; }
        public virtual string NomeDeUsuario { get;  set; }
        public virtual string Senha { get;  set; }
        public virtual Perfil Perfil { get;  set; }
        public virtual DateTime UltimoAcesso { get; private set; }
        public virtual DateTime DataDeCriacao { get; private set; }

        protected Usuario()
        {

        }

        public Usuario(string nomeDeUsuario, string senha, Perfil perfil)
        {
            NomeDeUsuario = nomeDeUsuario;
            Senha = senha;
            Perfil = perfil;
            DataDeCriacao = SystemTime.Now;
            UltimoAcesso = SystemTime.Now;
            PenultimoAcesso = SystemTime.Now;
            Validar();
        }

        protected override sealed void Validar()
        {
            if (Perfil == null)
                AdicionarRegraQuebrada(RegrasDeNegocioUsuario.DevePertencerAUmPerfil);

            if (string.IsNullOrWhiteSpace(NomeDeUsuario))
            {
                AdicionarRegraQuebrada(RegrasDeNegocioUsuario.NomeDeUsuarioDeveSerUmEmailValido);
            }
            else
            {
                var regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                if (!regex.IsMatch(NomeDeUsuario))
                    AdicionarRegraQuebrada(RegrasDeNegocioUsuario.NomeDeUsuarioDeveSerUmEmailValido);
            }
            if (string.IsNullOrWhiteSpace(Senha))
                AdicionarRegraQuebrada(RegrasDeNegocioUsuario.DeveConterUmaSenhaValida);

            NotificarSeHouverAlgumErro();
        }

       public void AlterarSenha(string novasenha)
        {
            Senha = novasenha;
            Validar();
        }

        public bool PertenceAoGrupo(Grupo grupo)
        {
            return grupo != null && Perfil.Grupo.Codigo == grupo.Codigo;
        }

        public void RegristarAcesso()
        {
            PenultimoAcesso = UltimoAcesso;
            UltimoAcesso = SystemTime.Now;
        }
    }
}