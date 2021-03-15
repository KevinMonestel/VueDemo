using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VueNetDemo.BackEnd.WebApi.Models;

namespace VueNetDemo.BackEnd.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileController(
            UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<Object> Get() {
            string userId = User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;
            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                 user.Email,
                 user.UserName
            };
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public string OnlyAdminMethod()
        {
            return "Web method for Admin";
        }
    }
}