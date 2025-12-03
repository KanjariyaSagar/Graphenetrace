using System;

namespace WebApplication2.Models.ViewModels
{
    public class AlertItemVM
    {
        public DateTime When { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;
        public int Frames { get; set; }

        // e.g. "Info", "Warning", "Critical"
        public string Severity { get; set; } = "Info";

        // Bootstrap badge CSS: "bg-danger text-white", etc.
        public string SeverityCss { get; set; } = "bg-secondary text-white";
    }
}
