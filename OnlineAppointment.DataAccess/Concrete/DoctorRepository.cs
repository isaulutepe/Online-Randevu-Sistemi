using Microsoft.EntityFrameworkCore;
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
    public class DoctorRepository : IDoctorRepository
    {
        public Doctor Add(Doctor doctor)
        {
           using(var dbContext= new OnlineAppointmentDbContext())
            {
                dbContext.Doctors.Add(doctor);
                dbContext.SaveChanges();
                return doctor;
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                var deleted= GetById(id);
                dbContext.Doctors.Remove(deleted);
                dbContext.SaveChanges();
            }
        }

        public List<Doctor> GetAll()
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
              return dbContext.Doctors.ToList();
            }
        }

        public Doctor GetById(int id)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return dbContext.Doctors.Find(id);
            }
        }

        public List<Doctor> GetBySpecialization(string specialization)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
               return dbContext.Doctors.Where(d => d.Specialization == specialization).ToList();
            }
        }

        public Doctor Update(Doctor doctor)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                dbContext.Doctors.Update(doctor);
                dbContext.SaveChanges();
                return doctor;
            }
        }
    }
}
