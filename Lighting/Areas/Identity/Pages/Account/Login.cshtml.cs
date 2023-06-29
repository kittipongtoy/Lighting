using Lighting.Areas.Identity.Data;
using Lighting.Core.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Lighting.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<LightingUser> _userManager;
        private readonly SignInManager<LightingUser> _signInManager;
        private readonly ILoggerHelperRepository _logger;

        public LoginModel(SignInManager<LightingUser> signInManager, UserManager<LightingUser> userManager, ILoggerHelperRepository logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Corporate_Governance/Corporate_governance_index");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(Input.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, Input.Password, false);
                if (result.Succeeded)
                {
                    var claims = new List<Claim>
                    {
                       new Claim("amr","pwd"),
                    };

                    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                    if (roles.Any())
                    {
                        var roleClaim = string.Join(",", roles);
                        claims.Add(new Claim("Roles", roleClaim));
                    }

                    await _signInManager.SignInWithClaimsAsync(user, Input.RememberMe, claims);

                    _logger.LogMessage("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.Succeeded)
                {
                    _logger.LogMessage("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogMessage("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
