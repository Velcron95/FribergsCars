using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class CreateModel : PageModel
    {
        private readonly ICar carRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CreateModel(ICar carRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.carRepository = carRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Car Car { get; set; } = new Car();

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

            Car.ImagePath = GetImagePathForBrand(Car.Brand);

            carRepository.Add(Car);

            return RedirectToPage("./Index");
        }

        private string GetImagePathForBrand(string brand)
        {
            string brandFolder = brand.ToLower();
            string imageFileName = $"{brandFolder}.png";

           
            string webRootPath = webHostEnvironment.WebRootPath;

            
            string imagePath = Path.Combine(webRootPath, "Images", imageFileName);

            
            if (System.IO.File.Exists(imagePath))
            {
                
                return Path.Combine("/Images", imageFileName);
            }
            else
            {
                
                return "/Images/default.png";
            }
        }



    }
}
