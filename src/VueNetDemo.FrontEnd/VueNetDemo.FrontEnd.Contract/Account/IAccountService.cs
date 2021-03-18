using System.Threading.Tasks;
using VueNetDemo.FrontEnd.Shared.Models.Account;

namespace VueNetDemo.FrontEnd.Contract.Account
{
    public interface IAccountService
    {
        Task<LoginTokenModel> Login(LoginModel viewModel);
    }
}
