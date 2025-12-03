using System;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianDashboardAlertVM
    {
        public string Title { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public DateTime When { get; set; }
        public string Severity { get; set; } = "High";

        public string WhenText => When.ToString("dd-MM-yyyy HH:mm");
    }
}
