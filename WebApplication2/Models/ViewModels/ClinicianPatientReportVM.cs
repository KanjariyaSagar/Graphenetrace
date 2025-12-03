using System;
using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    /// <summary>
    /// Detailed report view for a single patient.
    /// </summary>
    public class ClinicianPatientReportVM
    {
        public int PatientId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;
        public DateTime AssignedAt { get; set; }

        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        public string RiskLabel { get; set; } = string.Empty;
        public string RiskCss { get; set; } = string.Empty;
        public string RiskScore { get; set; } = string.Empty;

        public int TotalUploads { get; set; }
        public DateTime? LastUploadAt { get; set; }
        public string LastCheckText { get; set; } = string.Empty;

        public int LatestPeakPressureIndex { get; set; }
        public int LatestContactAreaPct { get; set; }

        public List<RecentAlertVM> RecentAlerts { get; set; } = new();
        public List<UploadHistoryItemVM> UploadHistory { get; set; } = new();
    }
}
