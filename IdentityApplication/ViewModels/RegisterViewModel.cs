using IdentityApplication.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityApplication.ViewModels
{
    public sealed class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]

        public string PasswordConfirm { get; set; }

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime DateLastLogin { get; set; } = DateTime.Now;

        public bool IsLock { get; set; } = false;

        public User ToUser()
        {
            return new User
            {
                Email = this.Email,
                UserName = this.Email,
                DateCreate = this.DateCreate,
                DateLastLogin = this.DateLastLogin,
                FullName = this.FullName,
            };
        }
    }
}
