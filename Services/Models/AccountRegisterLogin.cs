using Services.Tests.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class AccountRegisterLogin 
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       /* public bool IsValid { get; private set; }

        public AccountRegisterLogin(string email, string password)
        {
            this.Email = email;
            this.Password = password;
            base.validateModel();
        }*/
    }

}
