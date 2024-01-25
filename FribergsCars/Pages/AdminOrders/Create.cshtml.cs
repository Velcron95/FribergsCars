using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminOrders
{
    public class CreateModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly IUser userRep;

        [BindProperty]
        public Order Order { get; set; }

        public SelectList CarList { get; set; }
        public SelectList UserList { get; set; }

        public CreateModel(IOrder orderRep, ICar carRep, IUser userRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.userRep = userRep;
        }

        public IActionResult OnGet()
        {
            
            Order = new Order();

            
            var cars = carRep.GetAll();
            var users = userRep.GetAll();
            CarList = new SelectList(cars, "CarId", "Brand");
            UserList = new SelectList(users, "UserId", "Email");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                return Page();
            }

            
            Order.Car = carRep.GetById(Order.CarId);
            Order.User = userRep.GetById(Order.UserId);

            
            orderRep.Add(Order);

            return RedirectToPage("/AdminOrders/Index");
        }
    }
}
