using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class DetailsModel : PageModel
    {
        private readonly ICar carRepository;

        public DetailsModel(ICar carRepository)
        {
            this.carRepository = carRepository;
        }

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
    }
}
