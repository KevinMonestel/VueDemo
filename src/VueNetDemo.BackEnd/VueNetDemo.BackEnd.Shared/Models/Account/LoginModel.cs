using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Type { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool Successfull { get; set; }
        public string Message { get; set; }
    }
}
