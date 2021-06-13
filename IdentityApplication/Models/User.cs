using Microsoft.AspNetCore.Identity;
using System;

namespace IdentityApplication.Models
{
    public sealed  class User : IdentityUser
    {  
        public string FullName { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime DateLastLogin { get; set; }

        public bool Status { get; set; }
   
    }
}
