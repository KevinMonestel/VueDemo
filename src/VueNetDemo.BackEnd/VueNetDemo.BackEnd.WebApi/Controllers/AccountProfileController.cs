using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VueNetDemo.BackEnd.Implementation.Account;
using VueNetDemo.BackEnd.WebApi.Shared.Models;
using VueNetDemo.BackEnd.WebApi.Shared.Models.Account;

namespace VueNetDemo.BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountProfileController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountProfileController(
            IAccountService accountService
            )
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                string id = User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var result = await _accountService.GetAsync(id);

                if (result is null)
                    return NotFound();

                var roles = await _accountService.GetRolesAsync(result);

                var model = new ApplicationUserModel
                {
                    Email = result.Email,
                    UserName = result.UserName,
                    Password = string.Empty,
                    Role = roles.FirstOrDefault()
                };

                return Ok(new { user = model });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string OnlyAdminMethod()
        {
            return "Web method for Admin";
        }
    }
}