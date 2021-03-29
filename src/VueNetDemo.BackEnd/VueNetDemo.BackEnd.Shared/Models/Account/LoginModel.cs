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

    public enum LoginResult
    {
        Successful,
        IncorrectCredentials,
        Failed,
        locked
    }
}
