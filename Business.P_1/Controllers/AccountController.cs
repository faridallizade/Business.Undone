using Business.P_1.Helpers;
using Business.P_1.Models;
using Business.P_1.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.DiaSymReader;
using System.Security.Cryptography.X509Certificates;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Business.P_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppUser> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<AppUser> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser _appUser = new AppUser
            {
                FirstName = registerVm.Name,
                LastName = registerVm.Surname,
                Email = registerVm.Email,
                UserName = registerVm.Name

            };
            var create = await _userManager.CreateAsync(_appUser,registerVm.Password);
            if (!create.Succeeded)
            {
                foreach (var item in create.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVm);
            }
            await _userManager.AddToRoleAsync(_appUser, UserRole.Admin.ToString());
            //return RedirectToAction(nameof(Login),"Account");
            return View();
        }
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login  (LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(loginVm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(loginVm);
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, loginVm.RememberMe, true);
            if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your Account is Lock Out");
                return View(loginVm);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Password or Email is Wrong");
                return View(loginVm);
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    foreach (UserRole item in Enum.GetValues(typeof(UserRole)))
        //    {
        //        if (await _roleManager.FindByNameAsync(item.ToString()) == null)
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole()
        //            {
        //                Name = item.ToString(),
        //            });
        //        }
        //    }

        //    return RedirectToAction(nameof(Index), "Home");
        //}
    }
}
