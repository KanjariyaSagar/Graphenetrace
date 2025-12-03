namespace WebApplication2.Models
{
    public class ClinicianPatient
    {
        public int ClinicianID { get; set; }
        public int PatientID { get; set; }

        // NEW: short description of why the patient is under this clinician
        public string? Condition { get; set; } = string.Empty;

        public DateTime AssignedAt { get; set; }

        public User Clinician { get; set; } = default!;
        public User Patient { get; set; } = default!;
    }
}
