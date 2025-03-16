
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineAppointment.Entity
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Otomatik artan olacak.
        public int Id { get; set; }
        public int PatientId { get; set; }  // Hasta (User)
        public int DoctorId { get; set; }  // Doktor
        public DateTime AppointmentDate { get; set; }  // Randevu Tarihi  
        public string Status { get; set; } // "Pending", "Approved", "Canceled"
        public string Notes { get; set; } // Hastanın şikayeti veya doktorun yorumu  
    }
}
