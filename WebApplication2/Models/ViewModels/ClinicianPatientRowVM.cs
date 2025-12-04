using System;

namespace WebApplication2.Models.ViewModels
{
    /// <summary>
    /// One row in the Clinician → Patients table.
    /// </summary>
    public class ClinicianPatientRowVM
    {
        // Patient identity
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Patient details
        public int Age { get; set; }             //  temporarily set Age = 0 in controller
        public string Gender { get; set; } = ""; // temporarily empty

        // Medical condition
        public string Condition { get; set; } = string.Empty;

        // Last check info (“5 minutes ago”, “12-10-2025 14:20”)
        public string LastCheckHuman { get; set; } = string.Empty;

        // Status badge (Stable / Monitor / Alert)
        public string Status { get; set; } = "Stable";
        public string StatusCss { get; set; } = "badge bg-success";

        // Upload count
        public int Uploads { get; set; }

        // Assigned date for the clinician → patient link
        public DateTime AssignedAt { get; set; }

        // Risk badge (Low / Medium / High)
        public string RiskLabel { get; set; } = "Low";
        public string RiskCss { get; set; } = "badge bg-success";

        // Latest metrics
        public int LatestPpi { get; set; }
        public double LatestCa { get; set; }
    }
}
