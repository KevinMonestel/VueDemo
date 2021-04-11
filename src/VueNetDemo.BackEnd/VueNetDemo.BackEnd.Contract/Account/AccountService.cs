using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VueNetDemo.BackEnd.Implementation.Account;
using VueNetDemo.BackEnd.Implementation.Helpers;
using VueNetDemo.BackEnd.WebApi.Shared.Models;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Configurations;

namespace VueNetDemo.BackEnd.Contract.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(
            UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterAsync(ApplicationUserModel model)
        {
            try
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(applicationUser, model.Password);

                await _userManager.AddToRoleAsync(applicationUser, model.Role);

                return result;
            }

            catch (Exception)
            {
                return null;
            }
        }

        public async Task<LoginResult> LoginAsync(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is null)
                {
                    user = await _userManager.FindByEmailAsync(model.UserName);
                }

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return LoginResult.Successful;
                }

                return LoginResult.IncorrectCredentials;
            }
            catch (Exception)
            {
                return LoginResult.Failed;
            }
        }

        public async Task<ApplicationUser> GetAsync(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            try
            {
                var roles = await _userManager.GetRolesAsync(user);

                return roles;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
