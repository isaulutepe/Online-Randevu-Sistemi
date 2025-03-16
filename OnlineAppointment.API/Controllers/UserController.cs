using Microsoft.AspNetCore.Mvc;
using OnlineAppointment.Business.Abstract;
using OnlineAppointment.Entity;

namespace OnlineAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users); // 200 OK
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound($"ID {id} numaralı kullanıcı bulunamadı."); // 404 Not Found
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Geçersiz kullanıcı verisi."); // 400 Bad Request
            }
            var addUser = _userService.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, addUser); // 201 Created
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest("ID uyuşmazlığı veya geçersiz veri."); // 400 Bad Request
            }
            var existingUser = _userService.GetById(id);
            if (existingUser == null)
            {
                return NotFound($"ID {id} numaralı kullanıcı bulunamadı."); // 404 Not Found
            }

            var updatedUser = _userService.Update(user);
            return Ok(updatedUser); // 200 OK
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound($"ID {id} numaralı kullanıcı bulunamadı."); // 404 Not Found
            }
            _userService.Delete(id);
            return Ok();
        }
    }
}
