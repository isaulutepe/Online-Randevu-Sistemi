using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.Business.Abstract
{
    public interface IUserService
    {
        public User Add(User user);
        public List<User> GetAll();
        public User GetById(int id);
        public User Update(User user);
        public void Delete(int id);
    }
}
