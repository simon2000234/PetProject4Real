using System.Collections.Generic;
using Core.DomainService;
using Core.Entities;

namespace Core.ApplicationService.Impl
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public User GetUser(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);

        }

        public User UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);

        }

        public User DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}