using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareAppointmentSystem.Models; // For DTOs and Appointment
using HealthcareAppointmentSystem.Data; // For ApplicationDbContext

namespace HealthcareAppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId,
                AppointmentDateTime = appointmentDto.AppointmentDateTime
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAppointments(string userId)
        {
            var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == userId || a.DoctorId == userId)
                .ToListAsync();

            return Ok(appointments);
        }
    }
}