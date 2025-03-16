using OnlineAppointment.Business.Abstract;
using OnlineAppointment.DataAccess.Abstract;
using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Add(User user)
        {
           return _userRepository.Add(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
