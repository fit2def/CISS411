using CISS411.Models.DomainModels;
using CISS411.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CISS411.Controllers.Web
{
    public class AccountController : Controller
    {
        private SignInManager<Member> _signInManager;
        private UserManager<Member> _userManager;

        public AccountController(SignInManager<Member> signIn, UserManager<Member> manager)
        {
            _signInManager = signIn;
            _userManager = manager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel vm)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(
                vm.Email, vm.Password, true, false);
            if (!signInResult.Succeeded)
                return BadRequest();
            return Ok(signInResult);
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Landing()
        {
            var user = await _userManager.GetUserAsync(User);
            MemberViewModel vm = new MemberViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Major = user.Major,
                CurrentBook = user.CurrentBook
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupViewModel vm)
        {
            if (await _userManager.FindByEmailAsync(vm.Email) == null)
            {
                Member member = new Member()
                {
                    Email = vm.Email,
                    UserName = vm.Email,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Major = vm.Major,

                };

                var result = await _userManager.CreateAsync(member, vm.Password);
                var signInResult = await _signInManager.PasswordSignInAsync(
                vm.Email, vm.Password, true, false);
                return RedirectToAction("Index", "Home");
            }
            TempData["ExistingAccount"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAccount(Major major)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Major = major;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Landing");
        }
    }
}
