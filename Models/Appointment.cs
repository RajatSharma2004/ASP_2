namespace HealthcareAppointmentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public ApplicationUser Patient { get; set; }
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}