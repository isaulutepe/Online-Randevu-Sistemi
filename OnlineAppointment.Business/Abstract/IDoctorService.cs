using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.Business.Abstract
{
    public interface IDoctorService
    {
        public Doctor Add(Doctor doctor);
        public List<Doctor> GetAll();
        public Doctor GetById(int id);
        public List<Doctor> GetBySpecialization(string specialization); 
        public Doctor Update(Doctor doctor);
        public void Delete(int id);
    }
}
