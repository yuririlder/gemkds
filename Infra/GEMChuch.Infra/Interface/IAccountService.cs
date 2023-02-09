using GEMEscolar.Infra.Models;
using GEMEscolar.Core.Entities;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IAccountService
    {
        Task<ValidationResult<Users>> Login(LoginAccountModel loginAccountModel);
        Task<ValidationResult> CreateAccount(UserModel userModel);
    }
}
