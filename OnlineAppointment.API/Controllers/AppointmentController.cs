using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Business.Abstract;
using OnlineAppointment.Entity;

namespace OnlineAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var appointments = _appointmentService.GetAll();
            return Ok(appointments);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var appointment = _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound($"ID {id} numaralı randevu bulunamadı.");

            }
            return Ok(appointment);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Eksik veri girildi.");
            }

            try
            {
                var added = _appointmentService.Create(appointment);
                return CreatedAtAction(nameof(Get), new { id = added.Id }, added);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // İş kurallarından gelen hata mesajı
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Appointment appointment)
        {
            if (appointment == null || appointment.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri.");
            }

            try
            {
                var updatedAppointment = _appointmentService.Update(appointment);
                return Ok(updatedAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _appointmentService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
