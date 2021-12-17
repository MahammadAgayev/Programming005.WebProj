using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using Programming005.WebProj.Models.Accounts;

namespace Programming005.WebProj.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(IDatabase db, UserManager<Account> userManager, SignInManager<Account> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = _userManager.FindByNameAsync(model.Username).Result;

            if (user == null)
            {
                ModelState.AddModelError("LoginData", "Username or password wrong");
                return View(model);
            }

            //var passwordCorrect = _userManager.CheckPasswordAsync(user, model.Password).Result;

            //if(passwordCorrect)
            //{
            //    var singinResult = _signInManager.SignInAsync(user, model.RememberMe);
            //}

            var signInResult = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;

            if (signInResult.Succeeded == false)
            {
                ModelState.AddModelError("LoginData", "Username or password wrong");
                return View(model);
            }

            return Redirect(this.CreateLocalUrl(returnUrl));
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var account = new Account
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Username = model.Username
            };

            var result = _userManager.CreateAsync(account, model.Password).Result;

            if (result.Succeeded)
            {
                _ = _userManager.AddToRoleAsync(account, "Customer").Result;
            }
            else
            {
                ModelState.AddModelError("RegisterData", "Register failed");
                return View(model);
            }


            return Redirect(this.CreateLocalUrl(returnUrl));
        }

        private string CreateLocalUrl(string retunrUrl)
        {
            if (Url.IsLocalUrl(retunrUrl))
            {
                return retunrUrl;
            }

            return "/";
        }
    }
}
