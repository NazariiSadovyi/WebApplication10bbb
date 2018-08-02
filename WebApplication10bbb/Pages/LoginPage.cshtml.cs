using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication10bbb.DB;

namespace WebApplication10bbb.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Поле 'Ім'я користувача' незаповнене")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Поле 'Ім'я користувача' має бути з мінімальною довжиною 5 і максимальною довжиною 20.")]
        public string UserName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Поле 'Пароль' незаповнене")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Пароль повиннен містити принаймні 8 символів і обовя'зково містити 3 з 4 наступних: верхній регістр (AZ), нижній регістр (az), число (0 -9) та спеціальний символ (наприклад !@#$%^&*)")]
        public string Password { get; set; }

       
        public string Result = null;

        private readonly PacmanDBContext _context;

        public LoginPageModel(PacmanDBContext pacmanDBContext)
        {
            _context = pacmanDBContext;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostSignIn()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Result = null;

                var users = await _context.Users.FindAsync(UserName);

                if (users == null)
                {
                    Result = "Користувача з таким логіном не знайдено";
                    return Page();
                }
                else
                {
                    int l = users.UserPassword.Length;
                    string temp = "";
                    int i = 0;
                    bool a = false;
                    while (a == false)
                    {                        
                        if (users.UserPassword[i] != ' ')
                        {
                            temp = temp + users.UserPassword[i];
                            i++;
                        }
                        else
                        {
                            a = true;
                        }
                    }

                    if (temp == Password)
                    {

                        List<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, UserName)
                        };

                        ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        // sign-in  
                        await HttpContext.SignInAsync(principal);


                        return Redirect("/Index");
                    }
                    else
                    {
                        Result = "Невірний пароль";
                        return Page();
                    }
                }
                                
                  
            }
        }

        public async Task<IActionResult> OnPostSignUp()
        {           
           return Redirect("/RegisterPage");
        }
    }
}