using Microsoft.EntityFrameworkCore;
using OnlineAppointment.DataAccess.Abstract;
using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineAppointment.DataAccess.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {

        //Hasta ve doktorun durumlarını kontrol etme işlemi 
        //Doktor randevu alabilir mi.
        public bool IsDoctorAvailable(int doctorId, DateTime appointmentDate)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return !dbContext.Appointments.Any(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate);
            }
        }

        //Hastanın rezervasyonu var mı?
        public bool HasPatientAlreadyBooked(int patientId, DateTime appointmentDate)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return dbContext.Appointments.Any(a => a.PatientId == patientId && a.AppointmentDate == appointmentDate);
            }
        }
        public Appointment Add(Appointment appointment)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
                return appointment;
            }
        }

        public void Delete(int id)
        {

            using (var dbContext = new OnlineAppointmentDbContext())
            {
                var deleted = dbContext.Appointments.Find(id);
                if (deleted != null)
                {
                    dbContext.Appointments.Remove(deleted);
                    dbContext.SaveChanges();
                }
            }
        }

        public List<Appointment> GetAll()
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return dbContext.Appointments.ToList();
            }
        }

        public Appointment GetById(int id)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                return dbContext.Appointments.Find(id);
            }
        }

        public Appointment Update(Appointment appointment)
        {
            using (var dbContext = new OnlineAppointmentDbContext())
            {
                var existingAppointment = dbContext.Appointments.Find(appointment.Id);
                if (existingAppointment == null)
                {
                    return null; // Güncellenecek randevu bulunamadı.
                }

                dbContext.Entry(existingAppointment).CurrentValues.SetValues(appointment);
                dbContext.SaveChanges();
                return existingAppointment;
            }
        }
    }
}
