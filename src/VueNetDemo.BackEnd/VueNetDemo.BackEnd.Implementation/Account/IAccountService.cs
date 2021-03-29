using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using VueNetDemo.BackEnd.WebApi.Shared.Models;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;

namespace VueNetDemo.BackEnd.Implementation.Account
{
    public interface IAccountService
    {
        Task<LoginResult> LoginAsync(LoginModel model);

        Task<IdentityResult> RegisterAsync(ApplicationUserModel model);

        Task<ApplicationUser> GetAsync(string id);
    }
}