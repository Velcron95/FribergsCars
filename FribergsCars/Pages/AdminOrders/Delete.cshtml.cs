using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergsCars.Pages.AdminOrders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrder orderRep;

        public DeleteModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
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
                }

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Handle the exception, log, or display an error message
                return RedirectToPage("/Error");
            }
        }
    }
}
