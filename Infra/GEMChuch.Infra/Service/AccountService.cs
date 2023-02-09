using AutoMapper;
using GEMEscolar.Core.Entities;
using GEMEscolar.Core.Interface;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Helpers;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AccountService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<ValidationResult<Users>> Login([FromBody] LoginAccountModel loginAccountModel)
        {
            if(!loginAccountModel.login.IsEMail())
                return new ValidationResult<Users>()
                {
                    ResultType = ResultType.Invalid,
                    Success = false,
                    Message = "Informe algum e-mail valido."
                };

            var response = _userRepository.Queryable(x => x.EMail == loginAccountModel.login && x.Password == loginAccountModel.password).FirstOrDefault();

            if (response == null)
                return new ValidationResult<Users>()
                {
                    ResultType = ResultType.Invalid,
                    Success = false,
                    Message =  "Login ou senha incorretos."
                };

            return new ValidationResult<Users>()
            {
                ResultType = ResultType.Success,
                Success = true,
                Object = response
            };
        }
        public async Task<ValidationResult> CreateAccount(UserModel userModel)
        {
            var user = _mapper.Map<Users>(userModel);
            _userRepository.Add(user);

            return new ValidationResult()
            {
                ResultType = ResultType.Success,
                Success = true,
                Message = $"Sua conta foi criada com sucesso, você agora pode entrar utilizando seu e-Mail: {userModel.EMail} e Senha."
            };

        }
    }
}
