using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergsCars.Data;
using FribergsCars.Data.Models;
using FribergsCars.Data.Interfaces;

namespace FribergsCars.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly IUser userRep;
        private readonly ICar carRep;

        [BindProperty]
        public OrderCreateVM Model { get; set; }
  

        public CreateModel(IOrder orderRep, IUser userRep, ICar carRep)
        {
            this.orderRep = orderRep;
            this.userRep = userRep;
            this.carRep = carRep;
        }

        public IActionResult OnGet()
        {
            var currentUserId = HttpContext.Session.GetString("Email");
            if (currentUserId != null)
            {
                Model = new OrderCreateVM();
                if (int.TryParse(Request.Query["id"], out int id))
                {
                    Model.CarId = id;
                }
                else
                {
                    return RedirectToPage("/Error");
                }

                return Page();
            }
            return RedirectToPage("/Users/Login");
        }

        public IActionResult OnPost()
        {
            int currentUserId = HttpContext.Session.GetInt32("UserId") ?? throw new Exception("User Id Null");

            if (currentUserId != 0)
            {
                try
                {
                    var car = carRep.GetById(Model.CarId);
                    var user = userRep.GetById(currentUserId);

                    if (car != null && user != null)
                    {
                        var order = new Order
                        {
                            Car = car,
                            User = user,
                            StartDate = Model.StartDate,
                            EndDate = Model.EndDate,
                            IsActive = true
                        };

                        orderRep.Add(order);

                        
                        car.Available = false;
                        carRep.Update(car);

                        TempData["SuccessMessage"] = "Order created successfully!";

                        return RedirectToPage("/Orders/Index");

                        
                    }
                    else
                    {
                       
                        return RedirectToPage("/Error");
                    }
                }
                catch (Exception ex)
                {
                    
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/Users/Login");
        }
    }

}
