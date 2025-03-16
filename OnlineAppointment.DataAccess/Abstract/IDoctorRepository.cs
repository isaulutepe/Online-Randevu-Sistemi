using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.DataAccess.Abstract
{
    public interface IDoctorRepository
    {
        Doctor Add(Doctor doctor);
        List<Doctor> GetAll();
        Doctor GetById(int id);
        List<Doctor> GetBySpecialization(string specialization); //Alnına göre doktorları getiri.
        Doctor Update(Doctor doctor);
        void Delete(int id);
    }
}
