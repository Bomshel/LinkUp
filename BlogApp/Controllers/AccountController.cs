using BlogApp.Models;
using BlogApp.Models.DBContext;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;
using BlogApp.Helpers;
using System.Net.Mail;

namespace BlogApp.Controllers
{
    public class AccountController : Controller
    {
        // AccountController constructor with dependency injection
        // Initializes the _userManager, _signInManager, _context, and _mailService fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IMailService _mailService;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IMailService mailService)
        {
            _userManager = userManager; // Initializes the UserManager<ApplicationUser> field
            _signInManager = signInManager; // Initializes the SignInManager<ApplicationUser> field
            _context = context; // Initializes the ApplicationDbContext field
            _mailService = mailService; // Initializes the IMailService field
        }

        #region Register 
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Renders the Register view
        }


        // Handles the registration post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Checks if the model state is valid
            {
                // Creates a new ApplicationUser with provided username and email
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password); // Attempts to create the user

                if (result.Succeeded) // If user creation is successful
                {
                    await _userManager.AddToRoleAsync(user, model.Role); // Adds user to the specified role

                    await _signInManager.SignInAsync(user, isPersistent: false); // Signs in the user
                    return RedirectToAction("Index", "Home"); // Redirects to the home page
                }

                foreach (var error in result.Errors) // If user creation fails, add errors to ModelState
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model); // If model state is not valid, return the registration view with errors
        }


        // GET: /Account/RegisterUser Register admin user separately from dashboard
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View(); // Renders the RegisterUser view
        }

        // POST: /Account/RegisterUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model)
        {
            if (ModelState.IsValid) // Checks if the model state is valid
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email }; // Creates a new ApplicationUser with provided username and email

                var result = await _userManager.CreateAsync(user, model.Password); // Attempts to create the user

                if (result.Succeeded) // If user creation is successful
                {
                    await _userManager.AddToRoleAsync(user, model.Role); // Adds user to the specified role
                    ViewBag.Message = "User Created Successfully."; // Sets success message to be displayed on the view
                }

                foreach (var error in result.Errors) // If user creation fails, add errors to ModelState
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model); // If model state is not valid, return the registration view with errors
        }

        #endregion


        #region Login & Logout
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl }); // Renders the Login view with optional return URL
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // Checks if the model state is valid
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false); // Attempts to sign in the user

                if (result.Succeeded) // If sign-in is successful
                {
                    var user = await _userManager.FindByNameAsync(model.Username); // Retrieves the user
                    if (user != null) // If user is found
                    {
                        var roles = await _userManager.GetRolesAsync(user); // Retrieves user roles

                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role)); // Adds user roles to claims
                        }

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // Creates identity
                        var principal = new ClaimsPrincipal(identity); // Creates principal

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); // Signs in user

                        // Redirects based on user role
                        if (model.Role == "Admin" || model.Role == "Blogger")
                        {
                            return RedirectToAction("Dashboard", "Home");
                        }
                        else if (model.Role == "Surfer")
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt."); // Adds error if login fails
            }
            return View(model); // Returns the login view with model if ModelState is not valid
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Signs out the user
            return RedirectToAction("Index", "Home"); // Redirects to the home page
        }


        #endregion

        #region User Profile/deletion and List

        // GET: /Account/Users
        [HttpGet]
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Message = TempData["Message"];
            return View(users); // Renders the UserList view with a list of users
        }

        // Displays the user profile
        [AllowAnonymous]
        public async Task<IActionResult> UserProfile()
        {
            var model = new UserViewModel();
            var id = User.Identity.Name;
            model.ApplicationUser = await _userManager.FindByNameAsync(id); // Retrieves the user by username
            if (model.ApplicationUser == null)
                return NotFound();
            model.BlogPost = _context.BlogPosts.Where(x => x.AuthorId == model.ApplicationUser.Id).ToList(); // Retrieves blog posts by the user
            return View(model); // Renders the UserProfile view with the user's profile information
        }

        // Updates user profile
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string userName, string email)
        {
            var user = await _userManager.GetUserAsync(User); // Retrieves the current user
            if (user == null)
            {
                return NotFound();
            }

            // Update user properties
            user.UserName = userName;
            user.Email = email;

            // Update user in database
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok("Profile updated successfully."); // Returns success message if profile updated successfully
            }
            else
            {
                return BadRequest(result.Errors); // Returns error message if update fails
            }
        }

        // Deletes the current user's profile
        [HttpPost]
        public async Task<IActionResult> DeleteProfile()
        {
            var user = await _userManager.GetUserAsync(User); // Retrieves the current user
            if (user == null)
            {
                return NotFound("Unable to load user.");
            }

            var result = await _userManager.DeleteAsync(user); // Deletes the user from the database

            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync(); // Signs out the user
                return Ok("Profile deleted successfully."); // Returns success message if profile deleted successfully
            }
            else
            {
                return BadRequest(result.Errors); // Returns error message if deletion fails
            }
        }

        // Deletes a user by ID (only accessible by administrators)
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id); // Retrieves the user by ID

            if (user == null)
            {
                return NotFound();
            }

            // Check if the logged-in user is the user being deleted
            if (user.Id == User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            {
                return View("AccessDenied"); // Renders the AccessDenied view if the user attempts to delete themselves
            }

            return View("RemoveUser", user); // Renders the RemoveUser view with the user being deleted
        }

        // Deletes a user by ID (only accessible by administrators)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id); // Retrieves the user by ID
            if (user is null) return NotFound();
            try
            {
                var result = await _userManager.DeleteAsync(user); // Deletes the user from the database
                if (result.Succeeded)
                    return RedirectToAction("UserList"); // Redirects to the UserList action
            }
            catch (Exception ex)
            {

            }
            return View("ContentUsed"); // Renders the ContentUsed view
        }

        #endregion

        #region Change and Reset Password

        // GET: /Account/ChangePassword
        public IActionResult ChangePassword()
        {
            return View(); // Renders the ChangePassword view
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns bad request if model state is not valid
            }

            var user = await _userManager.GetUserAsync(User); // Retrieves the current user
            if (user == null)
            {
                return NotFound("Unable to load user.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword); // Changes the user's password

            if (result.Succeeded)
            {
                ViewBag.Message = "Password Changed Successfully. Logout and re-login"; // Sets success message
                return View("ChangePassword"); // Renders the ChangePassword view with success message
            }
            else
            {
                return BadRequest(result.Errors); // Returns error message if password change fails
            }
        }

        // Generates a random password
        private string GenerateRandomPassword(int length = 12)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";
            var random = new Random();
            var password = new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        // GET: /Account/ResetPassword
        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id); // Retrieves the user by ID
            if (user == null)
            {
                return NotFound("Unable to load user.");
            }
            var model = new ResetPasswordViewModel();
            model.Email = user.Email;
            return View(model); // Renders the ResetPassword view with the reset password form
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Returns the ResetPassword view with model if model state is not valid
            }

            var user = await _userManager.FindByEmailAsync(model.Email); // Retrieves the user by email
            if (user == null)
            {
                // Don't reveal that the user does not exist or is not confirmed
                return RedirectToAction("ResetPasswordConfirmation", "Account"); // Redirects to ResetPasswordConfirmation action
            }

            var newPassword = GenerateRandomPassword(); // Generates new password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword); // Resets user's password

            if (result.Succeeded)
            {
                var mailRequest = new MailMessage
                {
                    Subject = "New Password",
                    Body = $"Your new password is: {newPassword}"
                };
                await _mailService.SendEmailAsync(mailRequest, model.Email); // Sends email with new password
                TempData["Message"] = "Password Reset SuccessFully"; // Sets success message
                return RedirectToAction("UserList", "Account"); // Redirects to UserList action
            }

            // If resetting password failed, show error message
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model); // Returns the ResetPassword view with errors
        }

        #endregion


    }
}
