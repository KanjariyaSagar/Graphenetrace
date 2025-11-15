using System;
using System.Collections.Generic;

namespace WebApplication2.Models.ViewModels
{
    // ===================== DASHBOARD =====================
    public class ClinicianDashboardVM
    {
        public string ClinicianName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        // Old-style scalar KPIs (views still use these)
        public int TotalFrames { get; set; }
        public int TodaysUploads { get; set; }
        public int DistinctPatients { get; set; }
        public DateTime? LastUploadAt { get; set; }

        // Card-based UI
        public List<KpiCardVM> KpiCards { get; set; } = new();

        public List<RecentUploadVM> RecentUploads { get; set; } = new();

        // Some views use Alerts, some RecentAlerts – keep both
        public List<AlertVM> RecentAlerts { get; set; } = new();
        public List<AlertVM> Alerts
        {
            get => RecentAlerts;
            set => RecentAlerts = value ?? new List<AlertVM>();
        }
    }

    public class KpiCardVM
    {
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string BadgeText { get; set; } = string.Empty;
        public string BadgeCss { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Your .cshtml is using card.Hint → add it here
        public string Hint { get; set; } = string.Empty;
    }

    public class RecentUploadVM
    {
        public long Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public int Frames { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        // Older view uses .Patient instead of .PatientName
        public string Patient => PatientName;
    }

    public class AlertVM
    {
        
        
            public string Title { get; set; } = string.Empty;
            public string Detail { get; set; } = string.Empty;

            public DateTime When { get; set; }   // FIXED
        }

    

    // ===================== METRICS =====================
    public class ClinicianMetricsVM
    {
        public string SelectedMetric { get; set; } = "PPI";
        public string QuickRange { get; set; } = "Today";

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public List<string> TimeLabels { get; set; } = new();
        public List<decimal> Values { get; set; } = new();
        public List<decimal> SecondaryValues { get; set; } = new();
        public List<int> UploadCounts { get; set; } = new();

        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal AvgValue { get; set; }
    }

    // ===================== PATIENT LIST =====================
    public class ClinicianPatientsVM
    {
        public string Search { get; set; } = string.Empty;
        public string Sort { get; set; } = "newest";
        public string StatusFilter { get; set; } = "all";

        public List<ClinicianPatientRowVM> Patients { get; set; } = new();
    }

    public class ClinicianPatientRowVM
    {
        public int PatientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;

        public string LastCheckText { get; set; } = string.Empty;
        public int SortKeyHoursAgo { get; set; }

        public string Status { get; set; } = string.Empty;
        public string StatusCss { get; set; } = string.Empty;

        public int TotalUploads { get; set; }

        public int LatestPeakPressureIndex { get; set; }
        public decimal LatestContactAreaPct { get; set; }

        // Some views use LatestPpi instead of LatestPeakPressureIndex
        public int LatestPpi
        {
            get => LatestPeakPressureIndex;
            set => LatestPeakPressureIndex = value;
        }

        public string RiskScore { get; set; } = string.Empty;
        public string RiskCss { get; set; } = string.Empty;

        public DateTime AssignedAt { get; set; }
    }

    // ===================== PATIENT REPORT =====================
    public class ClinicianPatientReportVM
    {
        public int PatientId { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Condition { get; set; } = string.Empty;

        public DateTime AssignedAt { get; set; }
        public string LastCheckText { get; set; } = string.Empty;

        public int LatestPeakPressureIndex { get; set; }
        public decimal LatestContactAreaPct { get; set; }

        // Extra fields your views are using
        public string Status { get; set; } = string.Empty;
        public int TotalUploads { get; set; }

        public int LatestPpi
        {
            get => LatestPeakPressureIndex;
            set => LatestPeakPressureIndex = value;
        }

        public string RiskScore { get; set; } = string.Empty;
        public string RiskCss { get; set; } = string.Empty;

        public List<ClinicianPatientAlertRowVM> RecentAlerts { get; set; } = new();
        public List<ClinicianPatientUploadRowVM> UploadHistory { get; set; } = new();
    }

    public class ClinicianPatientAlertRowVM
    {
        public long AlertId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public DateTime When { get; set; }
        public string WhenText =>
            When.ToLocalTime().ToString("dd MMM yyyy HH:mm");

        public string Severity { get; set; } = string.Empty;
        public string SeverityCss { get; set; } = string.Empty;

        // Your view uses .Message
        public string Message { get; set; } = string.Empty;
    }

    public class ClinicianPatientUploadRowVM
    {
        public long DataId { get; set; }

        public DateTime Timestamp { get; set; }
        public string TimestampText =>
            Timestamp.ToLocalTime().ToString("dd MMM yyyy HH:mm");

        public int PeakPressureIndex { get; set; }
        public decimal ContactAreaPct { get; set; }

        // View uses .Ppi – alias for PeakPressureIndex
        public int Ppi
        {
            get => PeakPressureIndex;
            set => PeakPressureIndex = value;
        }

        public string Severity { get; set; } = string.Empty;
        public string SeverityCss { get; set; } = string.Empty;

        public string SourceFile { get; set; } = string.Empty;
    }
}
