using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Integra.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Usu�rio")]
        [DataType(DataType.EmailAddress)]
        public string NomeDeUsuario { get; set; }

        [Required]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]        
        public string Senha { get; set; }

        [DisplayName("Relembrar")]
        public bool Relembrar { get; set; }

        public string ReturnUrl { get; set; }
    }
}