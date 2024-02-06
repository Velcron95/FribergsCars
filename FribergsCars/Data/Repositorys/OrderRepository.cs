using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCars.Data.Repositorys
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Order> GetAll()
        {
            return applicationDbContext.Order.Include(x => x.User).Include(s => s.Car).ToList();
        }

        public Order GetById(int id)
        {
            return applicationDbContext.Order
                .Include(o => o.User)
                .Include(o => o.Car)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public void Add(Order order)
        {
            applicationDbContext.Order.Add(order);
            applicationDbContext.SaveChanges();
        }

        public void Update(Order order)
        {
            applicationDbContext.Update(order);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            applicationDbContext.Remove(order);
            applicationDbContext.SaveChanges();
        }



      
       
       
        public IEnumerable<Order> GetActiveOrders(string userEmail)
        {
            return applicationDbContext.Order
            .Include(o => o.Car)
            .Include(c => c.User)
            .Where(o => o.User.Email == userEmail && o.IsActive)
            .ToList();
        }
        public IEnumerable<Order> GetPastOrders(string userEmail)
        {
            return applicationDbContext.Order
                .Include(o => o.Car)
                .Where(o => o.User.Email == userEmail && !o.IsActive)
                .ToList();
        }

        public IEnumerable<Order> AdminGetActiveOrders()
        {
            return applicationDbContext.Order
            .Include(o => o.Car)
            .Include(c => c.User)
            .Where(o => o.IsActive)
            .ToList();
        }

        public IEnumerable<Order> AdminGetInactiveOrders()
        {
            return applicationDbContext.Order
            .Include(o => o.Car)
            .Include(c => c.User)
            .Where(o => !o.IsActive)
            .ToList();
        }
    }
}
