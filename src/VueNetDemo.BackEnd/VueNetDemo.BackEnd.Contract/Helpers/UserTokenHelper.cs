using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VueNetDemo.BackEnd.Implementation.Helpers;
using VueNetDemo.BackEnd.WebApi.Shared.Models;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Configurations;

namespace VueNetDemo.BackEnd.Contract.Helpers
{
    public class UserTokenHelper : IUserTokenHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationSettings _appSettings;

        public UserTokenHelper(
             UserManager<ApplicationUser> userManager,
            IOptions<ApplicationSettings> appSettings
            )
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<string> GenerateAsync(LoginModel loginModelInfo)
        {
            List<Claim> claims = new List<Claim>();
            IdentityOptions _options = new IdentityOptions();

            var user = await _userManager.FindByNameAsync(loginModelInfo.UserName);

            if (user is null)
                user = await _userManager.FindByEmailAsync(loginModelInfo.UserName);

            var roles = await _userManager.GetRolesAsync(user);

            try
            {
                claims.Add(new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id));
                claims.Add(new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName));
                claims.Add(new Claim(_options.ClaimsIdentity.EmailClaimType, user.Email));

                foreach (var role in roles)
                {
                    claims.Add(new Claim(_options.ClaimsIdentity.RoleClaimType, role));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return token;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
