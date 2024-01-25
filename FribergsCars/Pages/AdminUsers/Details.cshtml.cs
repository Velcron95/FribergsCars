using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminUsers
{
    public class DetailsModel : PageModel
    {
        private readonly IUser userRepository;

        public DetailsModel(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public User User { get; set; } = new User(); // Initialize the User object

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
    }
}
