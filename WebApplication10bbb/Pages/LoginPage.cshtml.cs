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
                var client = new HttpClient();

                string user = UserName;
                string password = Password;

                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44379/api/Users");

                //request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Headers.Add("UserName", user);
                request.Headers.Add("UserPassword", password);

                var response = await client.SendAsync(request);


                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Index");                   
                }
                else
                {
                    return Page();
                }

                  
            }
        }

        public async Task<IActionResult> OnPostSignUp()
        {           
           return Redirect("/RegisterPage");
        }
    }
}