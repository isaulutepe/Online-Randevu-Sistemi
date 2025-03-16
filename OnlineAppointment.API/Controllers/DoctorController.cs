using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Business.Abstract;
using OnlineAppointment.Entity;

namespace OnlineAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private IDoctorService _service;
        public DoctorController(IDoctorService doctorService)
        {
            _service = doctorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var doctors = _service.GetAll();
            return Ok(doctors);
        }
        [HttpGet("by-id/{id}")] //Parametre alan birden fazla Get methodu oldugundan çakışma durumunun önüne geçebilmek için url eklemesi yaptık.
        public IActionResult GetById(int id)
        {
            var doctor = _service.GetById(id);
            if (doctor == null)
            {
                return NotFound("Girilen ID'ye sahip doktor bulunamadı.");
            }
            return Ok(doctor);
        }

        [HttpGet("by-specialization/{specialization}")]
        public IActionResult GetBySpecialization(string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                return BadRequest("Uzmanlık alanı belirtilmelidir.");
            }

            var doctors = _service.GetBySpecialization(specialization);

            if (doctors == null || !doctors.Any()) // Eğer liste boşsa
            {
                return NotFound("Bu uzmanlık alanında doktor bulunamadı.");
            }

            return Ok(doctors);
        }


        [HttpPost]
        public IActionResult Add([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Eksik veri girildi.");
            }
            var added = _service.Add(doctor);
            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, added); // 201 Created
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null || doctor.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri."); // 400 Bad Request
            }
            var updated = _service.GetById(id);
            if (updated == null)
            {
                return NotFound($"ID {id} numaralı doktor bulunamadı."); // 404 Not Found
            }

            var updatedDoctor = _service.Update(doctor);
            return Ok(updatedDoctor); // 200 OK
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _service.GetById(id);
            if (doctor == null)
            {
                return NotFound($"ID {id} numaralı doktor bulunamadı."); // 404 Not Found
            }

            _service.Delete(id);
            return NoContent(); // 204 No Content
        }
    }
}
