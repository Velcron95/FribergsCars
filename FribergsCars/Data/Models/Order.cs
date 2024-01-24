using FribergsCars.Data.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergsCars.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }

        public Order()
        {

        }
    }
}
