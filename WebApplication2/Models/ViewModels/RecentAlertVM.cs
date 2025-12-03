using System;

namespace WebApplication2.Models.ViewModels
{
    public class RecentAlertVM
    {
        // e.g. "2h ago", "Yesterday"
        public string WhenText { get; set; } = string.Empty;

        // e.g. "16-11-2025 20:04"
        public string TimestampText { get; set; } = string.Empty;

        // Badge text: "High", "Medium", etc.
        public string Severity { get; set; } = string.Empty;

        // Main alert text
        public string Message { get; set; } = string.Empty;
    }
}
