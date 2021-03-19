using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VueNetDemo.FrontEnd.Contract.Account;
using VueNetDemo.FrontEnd.Shared.Models.Account;

namespace VueNetDemo.FrontEnd.WebUI.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<LoginTokenModel> Login([FromBody] LoginModel viewModel)
        {
            var result = await _accountService.Login(viewModel);

            return result;
        }
    }
}
