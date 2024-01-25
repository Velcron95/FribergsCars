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
using FribergsCars.Data.Repositorys;

namespace FribergsCars.Pages.AdminOrders
{
    public class DetailsModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly IUser userRep;

        public DetailsModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.userRep = userRep;
        }

        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            Order = orderRep.GetById(id);

            if (Order == null)
            {
                return NotFound();
            }

            
            Order.Car = carRep.GetById(Order.CarId);
            Order.User = userRep.GetById(Order.UserId);

            return Page();
        }

    }
}
