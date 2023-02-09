using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GEMEscolar.Infra.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "É obrigatório informar seu nome completo")]
        [Description("Nome Completo")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É obrigatório informar seu E-Mail")]
        [Description("E-Mail")] 
        public string EMail { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "A senhas não conferem.")]
        public string ConfirmPassword { get; set; }
        public string Active { get; set; }
    }
}
