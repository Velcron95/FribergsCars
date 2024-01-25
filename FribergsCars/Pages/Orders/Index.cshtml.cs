// IndexModel.cshtml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCars.Data;
using FribergsCars.Data.Models;
using FribergsCars.Data.Interfaces;

namespace FribergsCars.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly IUser userRep;
        private readonly ICar carRep;

        public IndexModel(IOrder orderRep, IUser userRep, ICar carRep)
        {
            this.orderRep = orderRep;
            this.userRep = userRep;
            this.carRep = carRep;
        }

        public IEnumerable<Order> ActiveOrders { get; private set; }
        public IEnumerable<Order> PastOrders { get; private set; }

        public void OnGet()
        {
            string user = HttpContext.Session.GetString("Email");
            if (ModelState.IsValid)
            {
                ActiveOrders = orderRep.GetActiveOrders(user);
                PastOrders = orderRep.GetPastOrders(user);
            }
            else
            {
                RedirectToPage("/Index");
            }
        }


    }
}
