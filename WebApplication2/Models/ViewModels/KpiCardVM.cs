using System;

namespace WebApplication2.Models.ViewModels
{
    public class KpiCardVM
    {
        public string Title { get; set; } = string.Empty;        // e.g. "TOTAL FRAMES ANALYSED"
        public string Value { get; set; } = string.Empty;        // e.g. "4,260"
        public string BadgeText { get; set; } = string.Empty;    // e.g. "+420 today"
        public string BadgeCss { get; set; } = string.Empty;     // e.g. "badge-soft-light"
        public string Description { get; set; } = string.Empty;  // optional extra text / tooltip
    }
}
