using EmployeeManangement.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace EmployeeManangement.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse",controller:"Account")]
        [ValidEmailDomain(allowedDomain:"sinan.com",
            ErrorMessage ="Email domain must be sinan.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
