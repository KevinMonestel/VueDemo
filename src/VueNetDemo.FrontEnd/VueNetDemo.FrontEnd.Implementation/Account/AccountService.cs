using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VueNetDemo.FrontEnd.Contract.Account;
using VueNetDemo.FrontEnd.Shared.Models.Account;
using VueNetDemo.FrontEnd.Shared.Models.Configurations;

namespace VueNetDemo.FrontEnd.Implementation.Account
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationSettings _applicationSettings;

        public AccountService(
            IConfiguration configuration,
            ApplicationSettings applicationSettings
            )
        {
            _configuration = configuration;
            _applicationSettings = applicationSettings;
        }

        public async Task<LoginTokenModel> Login(LoginModel viewModel)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync($"{_applicationSettings.APIUri}account/login", viewModel))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        LoginTokenModel loginToken = JsonConvert.DeserializeObject<LoginTokenModel>(apiResponse);

                        if (loginToken.Successfull)
                        {
                            var tokenString = loginToken.Token;

                            var userClaims = new JwtSecurityToken(jwtEncodedString: tokenString).Claims.ToList();

                            loginToken.Claims = userClaims;
                        }

                        return loginToken;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
