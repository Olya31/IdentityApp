using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityApplication.ViewModels
{
    public sealed class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public DateTime DateLastLogin { get; set; } = DateTime.Now;
    }
}
