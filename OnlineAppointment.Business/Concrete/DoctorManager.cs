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
    public class DoctorManager : IDoctorService
    {
        private IDoctorRepository _doctorRepository;
        public DoctorManager(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public Doctor Add(Doctor doctor)
        {
            return _doctorRepository.Add(doctor);
        }

        public void Delete(int id)
        {
            _doctorRepository.Delete(id);
        }

        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
           return _doctorRepository.GetById(id);
        }

        public List<Doctor> GetBySpecialization(string specialization)
        {
            return _doctorRepository.GetBySpecialization(specialization);
        }

        public Doctor Update(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }
    }
}
