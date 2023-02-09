using System.ComponentModel.DataAnnotations;

namespace GEMEscolar.Infra.Models
{
    public class LoginAccountModel
    {
        [Required(ErrorMessage = "É necessário informar seu e-mail")]
        [Display(Name = "Login")]
        public string login { get; set; }
        [Required(ErrorMessage = "É necessário informar sua senha")]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
