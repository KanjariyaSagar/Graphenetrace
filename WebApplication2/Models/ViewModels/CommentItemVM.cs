using System;

namespace WebApplication2.Models.ViewModels
{
    public class CommentItemVM
    {
        public DateTime When { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;     // usually the clinician
        public string Category { get; set; } = "General";      // e.g. “General”, “Follow-up”, “Action”
        public string CategoryCss { get; set; } = "bg-secondary text-white";

        public string Text { get; set; } = string.Empty;
    }
}
