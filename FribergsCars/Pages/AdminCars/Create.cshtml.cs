using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepository;

        public CreateModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = new Car(); // Initialize the Car object

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRepository.Add(Car);

            return RedirectToPage("./Index");
        }
    }
}
