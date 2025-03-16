using OnlineAppointment.DataAccess.Abstract;
using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User Add(User user)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return user;
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
               var deleted=GetById(id);
                dbContext.Users.Remove(deleted);
                dbContext.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
               return dbContext.Users.ToList();
            }
        }

        public User GetById(int id)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return dbContext.Users.Find(id);
            }
        }

        public User Update(User user)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return user;
            }
        }
    }
}
