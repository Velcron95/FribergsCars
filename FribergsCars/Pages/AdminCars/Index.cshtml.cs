using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergsCars.Data;
using FribergsCars.Data.Models;

namespace FribergsCars.Pages.AdminCars
{
    public class IndexModel : PageModel
    {
        private readonly FribergsCars.Data.ApplicationDbContext _context;

        public IndexModel(FribergsCars.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
