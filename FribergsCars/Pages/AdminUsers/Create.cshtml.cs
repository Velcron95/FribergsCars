using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminUsers
{
    public class CreateModel : PageModel
    {
        private readonly IUser userRepository;

        [BindProperty]
        public User User { get; set; } = new User(); 

        public CreateModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userRepository.Add(User);

            return RedirectToPage("./Index");
        }
    }
}
