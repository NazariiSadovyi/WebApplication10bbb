using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication10bbb.Pages
{
    public class LoginPageModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSignIn()
        {
            List<Claim> claims = new List<Claim>
              {
                 new Claim(ClaimTypes.Name, Request.Form["UserName"])

             };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in  
            await HttpContext.SignInAsync(principal);

            return Redirect("/Index");
        }

        public async Task<IActionResult> OnPostSignUp()
        {           
           return Redirect("/RegisterPage");
        }
    }
}