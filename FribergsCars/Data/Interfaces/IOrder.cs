using System.Collections.Generic;
using FribergsCars.Data.Models;
namespace FribergsCars.Data.Interfaces
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        
        
        
        public IEnumerable<Order> GetActiveOrders(string userEmail);
        public IEnumerable<Order> GetPastOrders(string userEmail);
        IEnumerable<Order> AdminGetActiveOrders();
        IEnumerable<Order> AdminGetInactiveOrders();

    }
}
