using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianPatientsVM
    {
        public string ClinicianName { get; set; } = string.Empty;

        public int TotalPatients { get; set; }
        public int UnderActiveMonitoring { get; set; }
        public int HighRiskCount { get; set; }

        public List<PatientRowVM> Patients { get; set; } = new();
        public string? SearchTerm { get; set; }
    }
}
