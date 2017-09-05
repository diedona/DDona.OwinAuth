using DDona.OwinAuth.WebApp.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
        [HttpPost]
        public ActionResult Login(LoginViewModel Model)
        {
            if(
                (Model.Password.Equals("123123") && Model.Username.Equals("diedona")) ||
                (Model.Password.Equals("123456") && Model.Username.Equals("donah"))
            )
            {
                configurarCookie(Model);
                return decidirUrl(Model.ReturnUrl);
            }
            else
            {
                return View("Index", Model);
            }
        }

        public ActionResult Logout()
        {
            var ctx = HttpContext.GetOwinContext().Authentication;
            ctx.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index");
        }

        private ActionResult decidirUrl(string returnUrl)
        {
            if(string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        private void configurarCookie(LoginViewModel model)
        {
            var claims = new List<Claim>();

            // create *required* claims
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Username));

            if(model.Username.Equals("donah"))
            {
                claims.Add(new Claim(ClaimTypes.Name, "Diego Doná"));
                claims.Add(new Claim("Permissoes", "1,3"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Name, "Diogo Doná"));
                claims.Add(new Claim("Permissoes", "1"));
            }

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            var ctx = HttpContext.GetOwinContext().Authentication;

            // add to user here!
            ctx.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = false,
                ExpiresUtc = DateTime.UtcNow.AddSeconds(30)
            }, identity);
        }
    }
}