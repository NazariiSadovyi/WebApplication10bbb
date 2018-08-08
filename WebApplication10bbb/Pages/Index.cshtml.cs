using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication10bbb.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
      

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {            
            // sign-in  
            await HttpContext.SignOutAsync();

            return Redirect("/LoginPage/a");
        }
    }
}
