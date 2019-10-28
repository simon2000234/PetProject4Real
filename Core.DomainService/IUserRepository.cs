using System.Collections.Generic;
using Core.Entities;

namespace Core.DomainService
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);

    }
}