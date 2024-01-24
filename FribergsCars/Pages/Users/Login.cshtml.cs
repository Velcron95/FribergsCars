using FribergsCars.Data;
using FribergsCars.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace FribergsCars.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public LoginModel(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (IsValidUser(Email, Password, out var user))
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    HttpContext.Session.SetString("Email", Email);
                    HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());

                    if (user.IsAdmin)
                    {
                        return RedirectToPage("/Index");
                    }

                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return RedirectToPage("/Index");
        }

        private bool IsValidUser(string username, string password, out User user)
        {
            user = applicationDbContext.User.FirstOrDefault(u => u.Email == username && u.Password == password);

            return user != null;
        }
    }
}
