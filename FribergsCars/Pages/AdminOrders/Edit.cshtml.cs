using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergsCars.Data;
using FribergsCars.Data.Models;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Repositorys;

namespace FribergsCars.Pages.AdminOrders
{
    public class EditModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly IUser userRep;

        [BindProperty]
        public Order Order { get; set; }

        public EditModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.userRep = userRep;
        }

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

        public IActionResult OnPost()
        {


            
            Order.Car = carRep.GetById(Order.CarId);
            Order.User = userRep.GetById(Order.UserId);

            orderRep.Update(Order);

            return RedirectToPage("/AdminOrders/Index");
        }
    }
}
