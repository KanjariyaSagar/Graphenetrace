using System;

namespace WebApplication2.Models.ViewModels
{
    /// <summary>
    /// Lightweight patient row used for small lists (NOT full reports).
    /// </summary>
    public class ClinicianPatientItemVM
    {
        public int PatientId { get; set; }

        // Basic identifying fields
        public string PatientName { get; set; } = string.Empty;

        // Status shown as a badge (Stable / Monitor / Attention)
        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        // Last upload time for quick lists
        public DateTime? LastUploadAt { get; set; }
    }
}
