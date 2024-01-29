using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class EditModel : PageModel
    {
        private readonly ICar carRepository;

        public EditModel(ICar carRepository)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            Car currentCar = carRepository.GetById(Car.CarId);

            
            currentCar.Brand = Car.Brand;
            currentCar.Model = Car.Model;
            currentCar.Description = Car.Description;
            currentCar.Available = Car.Available;

            
            currentCar.ImagePath = Car.ImagePath ?? currentCar.ImagePath;

            
            carRepository.Update(currentCar);

            return RedirectToPage("./Index");
        }
    }
}
