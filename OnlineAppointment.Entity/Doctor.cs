﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineAppointment.Entity
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Otomatik artan olacak.
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")] //E mail doğrulaması için.
        public string Email { get; set; }
        [StringLength(50)]
        public string Specialization { get; set; }  // Uzmanlık Alanı (Dahiliye, Kardiyoloji vs.)
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
