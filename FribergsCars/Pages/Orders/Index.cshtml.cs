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
        public List<Order> Orders { get; set; }

        public IActionResult OnPost(int carId)
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");



            if (currentUserId != null)
            {

                var car = carRep.GetById(carId);
                var orderCreateVM = new OrderCreateVM(carId);
                return Page();
                
            }

            return RedirectToPage("/Users/Login");
        }

        public IActionResult OnGet(OrderCreateVM orderCreateVM)
        {
            int currentUserId = HttpContext.Session.GetInt32("UserId") ?? throw new Exception("User Id Null");
            if (currentUserId != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var car = carRep.GetById(orderCreateVM.CarId);
                        var user = userRep.GetById(currentUserId);
                        var order = new Order
                        {
                            Car = car,
                            User = user,
                            StartDate = orderCreateVM.StartDate,
                            EndDate = orderCreateVM.EndDate
                        };

                        orderRep.Add(order);

                        return RedirectToPage("/Index");
                    }
                    catch (Exception ex)
                    {

                        return RedirectToAction("Error");
                    }
                }






                return RedirectToAction("Login", "User");
            }


            return RedirectToAction("Login", "User");
        }

    }
}

