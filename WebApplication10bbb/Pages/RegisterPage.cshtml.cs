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
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [BindProperty(Name = "Password")]
        // [Required()]
        // [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter student name.")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }


        [NotMapped]
        [BindProperty(Name = "Password2"), Required]
        [Compare(nameof(Password))] 
        public string Password2 { get; set; }


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

                string user = Request.Form["UserName"];
                string password = Request.Form["Password"];

                var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44379/api/Users");

                //request.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Headers.Add("UserName", user);
                request.Headers.Add("UserPassword", password);

                var response = await client.SendAsync(request);


                //var friends = JsonConvert.DeserializeObject<List<FriendModel>>(json);
                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/LoginPage");
                }
                else
                {
                    return Page();
                }
            }          
        }
    }
}