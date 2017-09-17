using CISS411.Models.DomainModels;
using CISS411.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CISS411.Controllers.Web
{
    public class AccountController : Controller
    {
        private SignInManager<Member> _signInManager;

        public AccountController(SignInManager<Member> signIn)
        {
            _signInManager = signIn;        
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(
                    vm.Email, vm.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Landing");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorrect"); // This is for C# validation
                }

            }
            return View();
        }


        [Authorize]
        public IActionResult Landing()
        {

            return View();
        }
    }
}
