using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VueNetDemo.BackEnd.Implementation.Account;
using VueNetDemo.BackEnd.Implementation.Helpers;
using VueNetDemo.BackEnd.WebApi.Shared.Models;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Configurations;

namespace VueNetDemo.BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserTokenHelper _userTokenHelper;

        public AccountController(
            IAccountService accountService,
            IUserTokenHelper userTokenHelper
            )
        {
            _accountService = accountService;
            _userTokenHelper = userTokenHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserModel model)
        {
            try
            {
                var result = await _accountService.RegisterAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _accountService.LoginAsync(model);

                if (result is LoginResult.IncorrectCredentials)
                    return Unauthorized(new { error = "User credentials are incorrect" });

                if (result is LoginResult.locked)
                    return Unauthorized(new { error = "User are locked" });

                var token = await _userTokenHelper.GenerateAsync(model);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Refresh()
        {
            try
            {
                string id = User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;
                LoginModel model = new LoginModel();

                var result = await _accountService.GetAsync(id);

                model.UserName = result.UserName;

                var refreshToken = await _userTokenHelper.GenerateAsync(model);

                return Ok(new { refreshToken });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}