using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminOrders
{
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRep;

        public IndexModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        public IEnumerable<Order> ActiveOrders { get; set; } = default!;
        public IEnumerable<Order> InactiveOrders { get; set; } = default!;

        public void OnGet()
        {
            if (orderRep != null)
            {
                ActiveOrders = orderRep.AdminGetActiveOrders();
                InactiveOrders = orderRep.AdminGetInactiveOrders();
            }
        }
    }
}
