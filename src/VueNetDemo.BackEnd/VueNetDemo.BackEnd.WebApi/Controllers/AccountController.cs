using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VueNetDemo.BackEnd.WebApi.Models;

namespace VueNetDemo.BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserModel model)
        {
            model.Role = "Admin";

            var applicationUser = new ApplicationUser() {
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);

                await _userManager.AddToRoleAsync(applicationUser, model.Role);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var tokenModel = new LoginTokenModel();
            var user = await _userManager.FindByNameAsync(model.UserName);
            IdentityOptions _options = new IdentityOptions();
            List<Claim> claims = new List<Claim>();

            try
            {
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    claims.Add(new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()));
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

                    tokenModel.ExpiresIn = tokenDescriptor.Expires.GetValueOrDefault();
                    tokenModel.Token = token;
                    tokenModel.Type = "bearer";
                    tokenModel.Message = "User credentials are correct";
                    tokenModel.Successfull = true;
                }
                else
                {
                    tokenModel.Message = "User credentials are incorrect";
                    tokenModel.Successfull = false;
                }

                return Ok(tokenModel);
            }
            catch (Exception Ex)
            {
                return BadRequest();
            }
        }
    }
}