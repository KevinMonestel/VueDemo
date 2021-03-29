using System.Threading.Tasks;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;

namespace VueNetDemo.BackEnd.Implementation.Helpers
{
    public interface IUserTokenHelper
    {
        Task<string> GenerateAsync(LoginModel loginModelInfo);
    }
}