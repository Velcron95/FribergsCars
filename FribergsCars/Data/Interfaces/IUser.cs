using FribergsCars.Data.Models;
using System.Collections.Generic;
namespace FribergsCars.Data.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);

    }
}
