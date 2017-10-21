using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Digital_X_Ray.Models;
using System.Collections.Generic;

namespace Digital_X_Ray.Controllers
{

    public class AccountController : Controller
    {

        private DXREntities _databaseManager = new DXREntities();

        public AccountController()
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (this.Request.IsAuthenticated)
                {
                    return this.RedirectToLocal(returnUrl);
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(sp_login_Result model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginInfo = this._databaseManager.sp_login(model.chrLOGUSR, model.chrCODVEN).ToList();

                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        var loginDetails = loginInfo.First();
                        this.SignInUser(loginDetails.chrNOMVEN, loginDetails.chrCODVEN, false);

                        return this.RedirectToLocal(returnUrl);
                    }else
                    {
                        ModelState.AddModelError(string.Empty,"Usuario o contraseña incorrecta.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return this.View(model);

        }


        public ActionResult LogOff()
        {
            try
            {
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;

                authenticationManager.SignOut();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this.RedirectToAction("Login", "Account");
        }

        private void SignInUser(string username, string indicador, bool isPersistant)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, indicador));
                var claimIdenties = new ClaimsIdentity(claims,DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistant}, claimIdenties);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return this.RedirectToAction("Index", "Home");
        }

    }
}