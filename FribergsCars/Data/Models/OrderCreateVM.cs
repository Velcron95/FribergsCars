using Microsoft.AspNetCore.Mvc.Rendering;

namespace FribergsCars.Data.Models
{
    public class OrderCreateVM
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<SelectListItem> CarOptions { get; set; }

        public OrderCreateVM(int carId)
        {
            CarId = carId;
        }
        public OrderCreateVM()
        {

        }
    }
}
