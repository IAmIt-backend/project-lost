using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lost.Models;
using Lost.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AspNet.Identity.MongoDB;
using DB.Models;


namespace Lost.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private BusinessLogic.Interfaces.IUserLogic _userlogic = new BusinessLogic.Implementation.UserLogic();

        public AccountController()
        {

        }

        public AccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Email);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
            {
                var userIdentity = await user.GenerateUserIdentityAsync(UserManager);
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, userIdentity);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
               // var userId = user.Id;
                if (result.Succeeded)
                {
                    var myUser = new IdentityUser2();
                    myUser.Email = model.Email;
                    myUser.UserName = model.UserName;
                    myUser.LastName = model.LastName;
                    myUser.Phone = model.Phone;
                    myUser.Id = user.Id;
                    _userlogic.AddUser(myUser);
                    return View("RegisterSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }

            return View(model);
        }

        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
            base.Dispose(disposing);
        }
       

        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}