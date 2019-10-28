using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Right.Repository
{
    public class UserRepository: IUserRepository
    {
        private PetAppContext _context;

        public UserRepository(PetAppContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            _context.Attach(user).State = EntityState.Added;
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Attach(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Remove(new User { Id = id }).Entity;
            _context.SaveChanges();
            return user;
        }
    }
}