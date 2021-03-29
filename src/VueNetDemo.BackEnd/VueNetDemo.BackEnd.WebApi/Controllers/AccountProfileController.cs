using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using VueNetDemo.BackEnd.Implementation.Account;
using VueNetDemo.BackEnd.WebApi.Shared.Models;

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
        public async Task<Object> Get()
        {
            try
            {
                string id = User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;

                var result = await _accountService.GetAsync(id);

                if (result is null)
                    return NotFound();

                return result;

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