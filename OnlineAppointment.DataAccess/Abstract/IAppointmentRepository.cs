using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.DataAccess.Abstract
{
    public interface IAppointmentRepository
    {
        Appointment Add(Appointment appointment);
        List<Appointment> GetAll();
        Appointment GetById(int id);
        Appointment Update(Appointment appointment);
        void Delete(int id);
        Boolean IsDoctorAvailable(int doctorId, DateTime appointmentDate);
        Boolean HasPatientAlreadyBooked(int patientId, DateTime appointmentDate);
    }
}
