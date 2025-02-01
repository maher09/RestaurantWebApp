using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModel;

namespace Restaurant.Areas.Admin.Controllrers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; } //--Register  Create Update 
        public SignInManager<IdentityUser> SignInManager { get; }//--Login Logout

        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }


        public IActionResult Login()
        {
            return View();
        }




        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel collection)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Fill Data");
                    return View();
                }
                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    //PasswordHash=collection.Password
                };
                var Resault = UserManager.CreateAsync(user, collection.Password).Result;

                if (Resault.Succeeded)
                {
                    SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", controllerName: "Home");
                }

                //Category.Add(collection);
                return RedirectToAction(nameof(Register));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please Fill Data");
                    return View();
                }
                var Resault = SignInManager.PasswordSignInAsync(collection.Email, collection.Password, collection.RememberMe, false).Result;
                if (Resault.Succeeded)
                {
                    return RedirectToAction("Index", controllerName: "Home");
                }
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

    }
}
