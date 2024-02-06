using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergsCars.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;

        public DeleteModel(IOrder orderRep, ICar carRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = orderRep.GetById(id.Value);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                
                Order = orderRep.GetById(Order.OrderId);

                if (Order != null)
                {
                    
                    Order.IsActive = false;
                    
                    orderRep.Update(Order);
                    Order.Car.Available = true;
                    carRep.Update(Order.Car);
                }

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                
                return RedirectToPage("/Error");
            }
        }
    }
}
