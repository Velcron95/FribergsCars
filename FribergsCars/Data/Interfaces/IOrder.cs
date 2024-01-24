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
        IEnumerable<OrderViewModel> DisplayOrders(string user);
    }
}
