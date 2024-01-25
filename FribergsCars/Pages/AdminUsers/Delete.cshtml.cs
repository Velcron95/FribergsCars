using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminUsers
{
    public class DeleteModel : PageModel
    {
        private readonly IUser userRepository;

        [BindProperty]
        public User User { get; set; } = new User(); 

        public DeleteModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = userRepository.GetById(id.Value);

            if (User != null)
            {
                userRepository.Delete(User);
            }

            return RedirectToPage("./Index");
        }
    }
}
