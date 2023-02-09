using GEMEscolar.Core.Controllers;
using GEMEscolar.Helpers;
using GEMEscolar.Infra.Enumerators;
using GEMEscolar.Infra.Interface;
using GEMEscolar.Infra.Models;
using GEMEscolar.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GEMEscolar.Controllers
{
    public class AccountController : MainControllerApi
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string login, string password)
        {
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(login))
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, "Login ou senha não informados.");
                return View("Index");
            }

            var loginAccountModel = new LoginAccountModel()
            {
                login = login,
                password = password
            };


            var response = await _accountService.Login(loginAccountModel);
            if (!response.Success)
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, response.Message);
                return View("Index");
            }

            UserLogado = response.Object;
            HttpContext.Session.SetObjectAsJson("UserLogado", UserLogado);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult> CreateAccount(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                var errosMessages = ModelState.Values.ErrorsMessageModelSatate();
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, errosMessages.ToList().FirstOrDefault());
                return View("CreateAccount");
            }

            if(userModel.Password != userModel.ConfirmPassword)
            {
                ViewBag.Alert = AlertService.ShowAlert(AlertsTypes.Danger, "Sua senha não confere com a confirmação da mesma.");
                return View(userModel);
            }

            var response = await _accountService.CreateAccount(userModel);
            return View("Index");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}
