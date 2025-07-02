using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAppointmentSystem.Models; // For DTOs and ApplicationUser
using HealthcareAppointmentSystem.Data; // For ApplicationDbContext

namespace HealthcareAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                Password = registerDto.Password, // Plain text for simplicity
                Role = registerDto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { user.Id, user.Email, user.Role });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
                return BadRequest("Invalid credentials");

            return Ok(new { user.Id, user.Email, user.Role });
        }
    }
}