namespace HealthcareAppointmentSystem.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}