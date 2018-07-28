﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10bbb.Pages
{
    public class RegisterModel
    {
        [BindProperty]
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [BindProperty(Name = "Password")]
        [Required()]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter student name.")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }


        [BindProperty(Name = "Password2"), Required]
        [Compare(nameof(Password))]
        public string Password2 { get; set; }
    }
}