using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace WebApplication10bbb.Pages
{
    public class RegisterPageModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Поле Ім'я користувача обов'язкове.")]
        [StringLength(20, MinimumLength = 5,ErrorMessage = "Поле Ім'я користувача має бути з мінімальною довжиною 5 і максимальною довжиною 20.")]
        public string UserName { get; set; }

        [BindProperty(Name = "Password")]
        [Required(ErrorMessage = "Поле Пароль обов'язкове.")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Паролі повинні містити принаймні 8 символів і містити в 3 з 4 наступних: верхній регістр (AZ), нижній регістр (az), число (0 -9) та спеціальний символ (наприклад !@#$%^&*)")]
        public string Password { get; set; }



        //[BindProperty(Name = "Password2"), Required(ErrorMessage = "Поле Повторіть пароль обов'язкове.")]        
        //public string Password2 { get; set; }

        public string Result = null;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
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

                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44379/api/Users");

                //request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Headers.Add("UserName", user);
                request.Headers.Add("UserPassword", password);

                var response = await client.SendAsync(request);


                //var friends = JsonConvert.DeserializeObject<List<FriendModel>>(json);
                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/LoginPage/" + UserName);
                }
                else
                {                    
                    Result = "Користувач з таким іменем вже зареєстрований";
                     
                    return Page();
                }
                
            }          
        }
    }
}