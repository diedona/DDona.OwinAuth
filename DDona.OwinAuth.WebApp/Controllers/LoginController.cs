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

        [AllowAnonymous]
        public ActionResult Login(LoginViewModel Model)
        {
            if(
                (Model.Password.Equals("123123") && Model.Username.Equals("diedona")) ||
                (Model.Password.Equals("123456") && Model.Username.Equals("donah"))
            )
            {
                return decidirUrl(Model.ReturnUrl);
            }
            else
            {
                return View("Index", Model);
            }
        }

        private ActionResult decidirUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
    }
}