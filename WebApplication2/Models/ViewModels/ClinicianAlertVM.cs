using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    public class ClinicianAlertsVM
    {
        public string ClinicianName { get; set; } = string.Empty;

        public int TotalAlerts { get; set; }
        public int CriticalAlerts { get; set; }
        public int Last24hAlerts { get; set; }

        public string? SelectedSeverity { get; set; } // "all", "info", "warning", "critical"
        public List<AlertItemVM> Alerts { get; set; } = new();
    }
}
