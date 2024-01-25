namespace FribergsCars.Data.Models
{
    public class AdminOrdersViewModel
    {
        public IEnumerable<Order> AdminActiveOrders { get; set; }
        public IEnumerable<Order> AdminPastOrders { get; set; }
    }
}
