using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.OwinAuth.WebApp.ViewModel
{
    public class LoginViewModel
    {
        public string ReturnUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}