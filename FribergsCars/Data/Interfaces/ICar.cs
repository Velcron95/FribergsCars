using System.Collections.Generic;
using FribergsCars.Data.Models;
namespace FribergsCars.Data.Interfaces
{
    public interface ICar
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
