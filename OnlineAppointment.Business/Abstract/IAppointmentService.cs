using OnlineAppointment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAppointment.Business.Abstract
{
    public interface IAppointmentService
    {
        public Appointment Create(Appointment appointment); //Yeni randevu oluştur.
        public Appointment Update(Appointment appointment);
        public void Delete(int id);
        public List<Appointment> GetAll();
        public Appointment GetById(int id);
    }
}
