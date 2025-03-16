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
    public class AppointmentManager : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;
        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment Create(Appointment appointment)
        {
            //  Doktorun uygun olup olmadığı kontrol ediliyor
            if (!_appointmentRepository.IsDoctorAvailable(appointment.DoctorId, appointment.AppointmentDate))
            {
                throw new BusinessException("Bu doktor belirtilen tarihte zaten bir randevuya sahip!");
            }

            // 2Hastanın aynı gün içinde başka bir randevusu olup olmadığı kontrol ediliyor
            if (_appointmentRepository.HasPatientAlreadyBooked(appointment.PatientId, appointment.AppointmentDate))
            {
                throw new BusinessException("Bu hasta aynı gün içinde başka bir randevuya sahip!");
            }

            // ✅ Randevu oluşturuluyor
             return _appointmentRepository.Add(appointment);
        }

        public void Delete(int id)
        {
          _appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Update(Appointment appointment)
        {
            var existingAppointment = _appointmentRepository.GetById(appointment.Id);
            if (existingAppointment == null)
            {
                throw new BusinessException("Güncellenecek randevu bulunamadı!");
            }

            // Eğer sadece status değişiyorsa doktorun uygunluğu kontrol edilmez
            if (existingAppointment.AppointmentDate != appointment.AppointmentDate)
            {
                // Doktorun uygun olup olmadığı kontrol ediliyor
                if (!_appointmentRepository.IsDoctorAvailable(appointment.DoctorId, appointment.AppointmentDate))
                {
                    throw new BusinessException("Bu doktor belirtilen tarihte zaten bir randevuya sahip!");
                }

                // Hastanın aynı gün içinde başka bir randevusu olup olmadığı kontrol ediliyor
                if (_appointmentRepository.HasPatientAlreadyBooked(appointment.PatientId, appointment.AppointmentDate))
                {
                    throw new BusinessException("Bu hasta aynı gün içinde başka bir randevuya sahip!");
                }
            }

            // ✅ Güncellenmiş randevuyu kaydet
            return _appointmentRepository.Update(appointment);
        }
        public class BusinessException : Exception //Hataları iletmek için oluşturdum.
        {
            public BusinessException(string message) : base(message) { }
        }
    }
}
