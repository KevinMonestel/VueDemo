using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VueNetDemo.BackEnd.WebApi.Shared.Models.Account
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginTokenModel
    {
        public string Token { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
