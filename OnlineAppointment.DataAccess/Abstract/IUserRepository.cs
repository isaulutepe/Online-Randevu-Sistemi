using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.DataAccess.Abstract
{
    public interface IUserRepository
    {
        User Add(User user);
        List<User> GetAll();
        User GetById(int id);
        User Update(User user);
        void Delete(int id);
    }
}
