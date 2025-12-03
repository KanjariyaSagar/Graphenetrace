using System;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianDashboardUploadVM
    {
        public string PatientName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public int Frames { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        // Used if you want a formatted string
        public string TimestampText => UploadedAt.ToString("dd-MM-yyyy HH:mm");
    }
}
