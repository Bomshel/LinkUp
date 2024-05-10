using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Discriminator { get; set; } 
    }
}