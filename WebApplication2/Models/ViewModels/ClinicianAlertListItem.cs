using System;

namespace WebApplication2.Models.ViewModels
{
    /// <summary>
    /// Row used on the Alerts list page.
    /// </summary>
    public class ClinicianAlertListItemVM
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public string WhenText { get; set; } = string.Empty;
        public string Severity { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
