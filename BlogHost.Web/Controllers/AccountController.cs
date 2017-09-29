using BlogHost.Domain.Entities;
using BlogHost.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogHost.Domain.Abstract;
using BlogHost.Web.Providers;

namespace BlogHost.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUserRepository Repository { get; }

        public AccountController(IUserRepository rep)
        {
            Repository = rep;
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                    //Проверяет учетные данные пользователя и управляет параметрами пользователей
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    
                    return RedirectToAction("List", "Post");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            var anyUser = Repository.GetAllUsers.Any(u => u.Email.Contains(model.Email));

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((CustomMembershipProvider)Membership.Provider)
                    .CreateUser(model.Email, model.Password, model.Username);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("List", "Post");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "Post");
        }
    }
}