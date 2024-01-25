using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FribergsCars.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public string? ImagePath { get; set; }


        public Car()
        {

        }
    }
}
