using DDona.OwinAuth.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDona.OwinAuth.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index(string ReturnUrl)
        {
            return View("Index", new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
    }
}