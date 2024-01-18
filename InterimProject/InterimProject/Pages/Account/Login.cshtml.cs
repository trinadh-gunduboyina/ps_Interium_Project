using InterimProject.Models;
using InterimProject.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace InterimProject.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUserAuthenticationService _userAuthenticationService;
        [BindProperty]
        public SiteAdmin SiteAdmin { get; set; }
        public LoginModel(IUserAuthenticationService authenticationService)
        {
            this._userAuthenticationService = authenticationService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var isValidUser = _userAuthenticationService.ValidateUser(SiteAdmin.UserName, SiteAdmin.Password);
            if (!isValidUser)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, SiteAdmin.UserName)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
            return RedirectToPage("/Admin/Index");
        }
    }
}
