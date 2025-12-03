using System;

namespace WebApplication2.Models.ViewModels
{
    public class PatientRowVM
    {
        public int PatientId { get; set; }

        // BACKWARD COMPATIBILITY (Old code may use these)
        public int? Id { get; set; }
        public string? NHSNumber { get; set; }

        public string? PatientName { get; set; }
        public int Age { get; set; }

        public string? Gender { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }

        public string? Ward { get; set; }

        public DateTime LastUploadAt { get; set; }
        public int LastFrames { get; set; }

        public string? LastStatus { get; set; }
        public string? LastStatusCss { get; set; }

        public int AlertsLast7Days { get; set; }

        public string? RiskTag { get; set; }
        public string? RiskTagCss { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}