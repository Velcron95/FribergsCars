﻿using FribergsCars.Data.Interfaces;
using FribergsCars.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCars.Data.Repositorys
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return applicationDbContext.User.OrderBy(x => x.Email);
        }

        public User GetById(int id)
        {
            return applicationDbContext.User.FirstOrDefault(c => c.UserId == id);
        }

        public void Add(User user)
        {
            applicationDbContext.User.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            applicationDbContext.Remove(user);
            applicationDbContext.SaveChanges();
        }


    }
}
