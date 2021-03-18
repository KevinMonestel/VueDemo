using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueNetDemo.FrontEnd.Shared.Models.Account
{
    public class LoginTokenModel
    {
        public string Type { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
        public bool Successfull { get; set; }
        public string Message { get; set; }
    }
}
