using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class DeleteModel : PageModel
    {
        private readonly ICar carRepository;

        public DeleteModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

        [BindProperty]
        public Car Car { get; set; } = new Car(); 

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = carRepository.GetById(id.Value);

            if (Car == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = carRepository.GetById(id.Value);

            if (Car != null)
            {
                carRepository.Delete(Car);
            }

            return RedirectToPage("./Index");
        }
    }
}
