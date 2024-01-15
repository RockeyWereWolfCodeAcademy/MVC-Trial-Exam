using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Trial_Exam.Contexts;
using MVC_Trial_Exam.Models;
using MVC_Trial_Exam.ViewModels;

namespace MVC_Trial_Exam.Controllers
{
    public class AuthController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly BusinessDbContext _context;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, BusinessDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Registration(RegisterVM vm)
        {
            var result = await _userManager.CreateAsync(new AppUser { UserName = vm.UserName, Email = vm.Email }, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            var user = await _userManager.FindByEmailAsync(vm.UsernameOrEmail) ?? await _userManager.FindByNameAsync(vm.UsernameOrEmail);
            if (user == null) ModelState.AddModelError("", "Username/Email or password is wrong. Check your credentiials!");
            var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username/Email or password is wrong. Check your credentiials!");
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction(actionName: nameof(HomeController.Index), controllerName: nameof(HomeController));
        }
    }
}
