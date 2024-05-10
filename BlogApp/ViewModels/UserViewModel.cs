using BlogApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogApp.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            ApplicationUser = new ApplicationUser();
            BlogPost = new List<BlogPost>();  
        }
        public ApplicationUser ApplicationUser { get; set; }

        public List<BlogPost> BlogPost { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ResetPasswordViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
    }
    public class EmailSettings
    {
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool AuthRequired { get; set; }
        public bool UseSsl { get; set; }
    }

}
