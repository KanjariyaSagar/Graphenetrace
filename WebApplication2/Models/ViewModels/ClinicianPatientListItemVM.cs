using System;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianPatientListItemVM
    {
        public int PatientId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        // Shown in the "Last check" column
        public string LastCheckText { get; set; } = string.Empty;

        // Uploads / assignment info
        public int TotalUploads { get; set; }
        public DateTime AssignedAt { get; set; }

        // Risk label + CSS
        public string RiskCss { get; set; } = string.Empty;
        public string RiskLabel { get; set; } = string.Empty;

        // Latest metrics (used with ToString("0.0"))
        public double LatestPeakPressureIndex { get; set; }
        public double LatestContactAreaPct { get; set; }
    }
}
