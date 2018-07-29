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
        public char[,] CoinMap = {
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'k', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'k', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w' ,'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'c', 'c', 'c', 'c', 'c', 'w', 'c', 'c', 'c', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'c', 'c', 'c', 'w', 'c', 'c', 'c', 'c', 'c'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ',    ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', ' ', ' ', ' ', ' ', ' '},
            {'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'c', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'k', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'k', 'w'},
            {'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w'},
            {'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'c', 'w', 'w', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'w',    'w', 'c', 'c', 'c', 'c', 'w', 'w', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w',    'w', 'c', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'c', 'w'},
            {'w', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c',    'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'c', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w',    'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w', 'w'},

        };

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
