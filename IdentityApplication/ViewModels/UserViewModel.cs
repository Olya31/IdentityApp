using System;

namespace IdentityApplication.ViewModels
{
    public sealed class UserViewModel
    {      
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateLastLogin { get; set; }

        public bool Status { get; set; }     
    }
}
