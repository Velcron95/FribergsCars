using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminUsers
{
    public class EditModel : PageModel
    {
        private readonly IUser userRepository;

        public EditModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        [BindProperty]
        public User User { get; set; } = new User(); 

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = userRepository.GetById(id.Value);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userRepository.Update(User);

            return RedirectToPage("./Index");
        }
    }
}
