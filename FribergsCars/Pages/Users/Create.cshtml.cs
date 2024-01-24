using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergsCars.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUser userRep;

        public CreateModel(IUser userRep)
        {
            this.userRep = userRep;
        }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    userRep.Add(user);
                    return RedirectToPage("/Users/Login");
                }

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }
                }


                return Page();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");
                return Page();
            }
        }
    }
    }

