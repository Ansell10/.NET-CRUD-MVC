using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPNET_CRUD_MVC.Models;
using ASPNET_CRUD_MVC.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET_CRUD_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl = null)
        {
            UserModel userDb = _repository.Login(loginModel);
            if (userDb != null)
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                    new Claim(ClaimTypes.Name, userDb.UserName),
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "Identity.Login");
                ClaimsPrincipal mainUser = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(mainUser, new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.Now.AddHours(1),
                });

                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                return RedirectToPage("/Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

