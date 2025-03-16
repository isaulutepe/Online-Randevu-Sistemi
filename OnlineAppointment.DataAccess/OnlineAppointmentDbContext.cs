using Microsoft.EntityFrameworkCore;
using OnlineAppointment.Entity;


namespace OnlineAppointment.DataAccess
{
    public class OnlineAppointmentDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; DataBase=AppointmentSystemDb; uid=jesus1; pwd=30032001; TrustServerCertificate=True"); //Veritaban ehlenece
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
