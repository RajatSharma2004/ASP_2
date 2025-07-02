namespace HealthcareAppointmentSystem.Models
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Patient or Doctor
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AppointmentDto
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}