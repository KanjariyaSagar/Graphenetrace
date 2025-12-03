using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models.ViewModels;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ClinicianController : Controller
    {
        private readonly IPatientPdfService _pdfService;

        public ClinicianController(IPatientPdfService pdfService)
        {
            _pdfService = pdfService;
            
        }

        // --------------------------------------------------------------
        //  STATIC DUMMY DATA – NO DATABASE
        // --------------------------------------------------------------
        private static readonly List<PatientRowVM> SamplePatients = new()
        {
           new PatientRowVM
    {
        PatientId = 1,
        Id = 1,
        PatientName = "Rajesh Kumar",
        NHSNumber = "100 000 0001",
        Age = 69,
        Gender = "Male",
        Contact = "07111111111",
        Email = "rajesh.kumar@mail.com",
        Ward = "Pressure Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 25, 10, 11, 0),
        LastFrames = 42,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 1,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 15)
    },
    new PatientRowVM
    {
        PatientId = 2,
        Id = 2,
        PatientName = "Aman Gupta",
        NHSNumber = "100 000 0002",
        Age = 58,
        Gender = "Male",
        Contact = "07111111112",
        Email = "aman.gupta@mail.com",
        Ward = "Diabetic Foot Clinic",
        LastUploadAt = new DateTime(2025, 11, 25, 9, 58, 0),
        LastFrames = 38,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 0,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 15)
    },
    new PatientRowVM
    {
        PatientId = 3,
        Id = 3,
        PatientName = "Priya Sharma",
        NHSNumber = "100 000 0003",
        Age = 63,
        Gender = "Female",
        Contact = "07111111113",
        Email = "priya.sharma@mail.com",
        Ward = "Geriatric Ulcer Unit",
        LastUploadAt = new DateTime(2025, 11, 24, 18, 20, 0),
        LastFrames = 51,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 2,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 14)
    },
    new PatientRowVM
    {
        PatientId = 4,
        Id = 4,
        PatientName = "Neha Patel",
        NHSNumber = "100 000 0004",
        Age = 55,
        Gender = "Female",
        Contact = "07111111114",
        Email = "neha.patel@mail.com",
        Ward = "Surgical Wound Ward",
        LastUploadAt = new DateTime(2025, 11, 24, 17, 10, 0),
        LastFrames = 29,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 0,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 14)
    },
    new PatientRowVM
    {
        PatientId = 5,
        Id = 5,
        PatientName = "Rohan Nair",
        NHSNumber = "100 000 0005",
        Age = 61,
        Gender = "Male",
        Contact = "07111111115",
        Email = "rohan.nair@mail.com",
        Ward = "Vascular Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 24, 16, 6, 0),
        LastFrames = 67,
        LastStatus = "Critical",
        LastStatusCss = "badge-status-critical",
        AlertsLast7Days = 6,
        RiskTag = "High",
        RiskTagCss = "badge-risk-high",
        CreatedAt = new DateTime(2025, 11, 13)
    },
    new PatientRowVM
    {
        PatientId = 6,
        Id = 6,
        PatientName = "Simran Kaur",
        NHSNumber = "100 000 0006",
        Age = 72,
        Gender = "Female",
        Contact = "07111111116",
        Email = "simran.kaur@mail.com",
        Ward = "Community Ulcer Clinic",
        LastUploadAt = new DateTime(2025, 11, 23, 20, 41, 0),
        LastFrames = 33,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 2,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 13)
    },
    new PatientRowVM
    {
        PatientId = 7,
        Id = 7,
        PatientName = "Vikram Singh",
        NHSNumber = "100 000 0007",
        Age = 66,
        Gender = "Male",
        Contact = "07111111117",
        Email = "vikram.singh@mail.com",
        Ward = "High Dependency Ulcer Bay",
        LastUploadAt = new DateTime(2025, 11, 23, 18, 55, 0),
        LastFrames = 55,
        LastStatus = "Critical",
        LastStatusCss = "badge-status-critical",
        AlertsLast7Days = 7,
        RiskTag = "High",
        RiskTagCss = "badge-risk-high",
        CreatedAt = new DateTime(2025, 11, 12)
    },
    new PatientRowVM
    {
        PatientId = 8,
        Id = 8,
        PatientName = "Mukesh Yadav",
        NHSNumber = "100 000 0008",
        Age = 59,
        Gender = "Male",
        Contact = "07111111118",
        Email = "mukesh.yadav@mail.com",
        Ward = "Rehab & Mobility Ward",
        LastUploadAt = new DateTime(2025, 11, 23, 12, 22, 0),
        LastFrames = 48,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 1,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 12)
    },
    new PatientRowVM
    {
        PatientId = 9,
        Id = 9,
        PatientName = "Sneha Reddy",
        NHSNumber = "100 000 0009",
        Age = 64,
        Gender = "Female",
        Contact = "07111111119",
        Email = "sneha.reddy@mail.com",
        Ward = "Diabetic Foot Clinic",
        LastUploadAt = new DateTime(2025, 11, 22, 19, 18, 0),
        LastFrames = 77,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 3,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 11)
    },
    new PatientRowVM
    {
        PatientId = 10,
        Id = 10,
        PatientName = "Arjun Mehta",
        NHSNumber = "100 000 0010",
        Age = 57,
        Gender = "Male",
        Contact = "07111111120",
        Email = "arjun.mehta@mail.com",
        Ward = "Pressure Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 22, 18, 1, 0),
        LastFrames = 23,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 0,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 11)
    },
    new PatientRowVM
    {
        PatientId = 11,
        Id = 11,
        PatientName = "Sunil Verma",
        NHSNumber = "100 000 0011",
        Age = 70,
        Gender = "Male",
        Contact = "07111111121",
        Email = "sunil.verma@mail.com",
        Ward = "Geriatric Ulcer Unit",
        LastUploadAt = new DateTime(2025, 11, 21, 17, 10, 0),
        LastFrames = 31,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 1,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 10)
    },
    new PatientRowVM
    {
        PatientId = 12,
        Id = 12,
        PatientName = "Deepika Joshi",
        NHSNumber = "100 000 0012",
        Age = 62,
        Gender = "Female",
        Contact = "07111111122",
        Email = "deepika.joshi@mail.com",
        Ward = "Community Ulcer Clinic",
        LastUploadAt = new DateTime(2025, 11, 21, 14, 59, 0),
        LastFrames = 42,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 2,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 10)
    },
    new PatientRowVM
    {
        PatientId = 13,
        Id = 13,
        PatientName = "Anil Sharma",
        NHSNumber = "100 000 0013",
        Age = 67,
        Gender = "Male",
        Contact = "07111111123",
        Email = "anil.sharma@mail.com",
        Ward = "Vascular Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 21, 14, 3, 0),
        LastFrames = 69,
        LastStatus = "Critical",
        LastStatusCss = "badge-status-critical",
        AlertsLast7Days = 8,
        RiskTag = "High",
        RiskTagCss = "badge-risk-high",
        CreatedAt = new DateTime(2025, 11, 9)
    },
    new PatientRowVM
    {
        PatientId = 14,
        Id = 14,
        PatientName = "Karan Kapoor",
        NHSNumber = "100 000 0014",
        Age = 54,
        Gender = "Male",
        Contact = "07111111124",
        Email = "karan.kapoor@mail.com",
        Ward = "Rehab & Mobility Ward",
        LastUploadAt = new DateTime(2025, 11, 21, 12, 11, 0),
        LastFrames = 29,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 0,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 9)
    },
    new PatientRowVM
    {
        PatientId = 15,
        Id = 15,
        PatientName = "Meera Pillai",
        NHSNumber = "100 000 0015",
        Age = 71,
        Gender = "Female",
        Contact = "07111111125",
        Email = "meera.pillai@mail.com",
        Ward = "Geriatric Ulcer Unit",
        LastUploadAt = new DateTime(2025, 11, 20, 19, 44, 0),
        LastFrames = 44,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 2,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 8)
    },
    new PatientRowVM
    {
        PatientId = 16,
        Id = 16,
        PatientName = "Shivangi Rao",
        NHSNumber = "100 000 0016",
        Age = 60,
        Gender = "Female",
        Contact = "07111111126",
        Email = "shivangi.rao@mail.com",
        Ward = "Diabetic Foot Clinic",
        LastUploadAt = new DateTime(2025, 11, 20, 18, 22, 0),
        LastFrames = 51,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 3,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 8)
    },
    new PatientRowVM
    {
        PatientId = 17,
        Id = 17,
        PatientName = "Suresh Iyer",
        NHSNumber = "100 000 0017",
        Age = 68,
        Gender = "Male",
        Contact = "07111111127",
        Email = "suresh.iyer@mail.com",
        Ward = "Pressure Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 20, 17, 12, 0),
        LastFrames = 38,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 1,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 8)
    },
    new PatientRowVM
    {
        PatientId = 18,
        Id = 18,
        PatientName = "Pooja Sinha",
        NHSNumber = "100 000 0018",
        Age = 59,
        Gender = "Female",
        Contact = "07111111128",
        Email = "pooja.sinha@mail.com",
        Ward = "Community Ulcer Clinic",
        LastUploadAt = new DateTime(2025, 11, 20, 14, 40, 0),
        LastFrames = 21,
        LastStatus = "Stable",
        LastStatusCss = "badge-status-stable",
        AlertsLast7Days = 0,
        RiskTag = "Low",
        RiskTagCss = "badge-risk-low",
        CreatedAt = new DateTime(2025, 11, 7)
    },
    new PatientRowVM
    {
        PatientId = 19,
        Id = 19,
        PatientName = "Himanshu Dixit",
        NHSNumber = "100 000 0019",
        Age = 62,
        Gender = "Male",
        Contact = "07111111129",
        Email = "himanshu.dixit@mail.com",
        Ward = "Vascular Ulcer Ward",
        LastUploadAt = new DateTime(2025, 11, 20, 13, 30, 0),
        LastFrames = 48,
        LastStatus = "Critical",
        LastStatusCss = "badge-status-critical",
        AlertsLast7Days = 6,
        RiskTag = "High",
        RiskTagCss = "badge-risk-high",
        CreatedAt = new DateTime(2025, 11, 7)
    },
    new PatientRowVM
    {
        PatientId = 20,
        Id = 20,
        PatientName = "Reena Malhotra",
        NHSNumber = "100 000 0020",
        Age = 65,
        Gender = "Female",
        Contact = "07111111130",
        Email = "reena.malhotra@mail.com",
        Ward = "Rehab & Mobility Ward",
        LastUploadAt = new DateTime(2025, 11, 20, 11, 29, 0),
        LastFrames = 57,
        LastStatus = "Watch",
        LastStatusCss = "badge-status-watch",
        AlertsLast7Days = 3,
        RiskTag = "Medium",
        RiskTagCss = "badge-risk-medium",
        CreatedAt = new DateTime(2025, 11, 7)
    }
        };

        private static readonly List<AlertItemVM> SampleAlerts = new()
        {
            new AlertItemVM
            {
                When = DateTime.Now.AddMinutes(-30),
                Title = "High pressure detected",
                Detail = "Left heel pressure above threshold for 12 minutes.",
                PatientName = "John Doe",
                Frames = 120,
                Severity = "Critical",
                SeverityCss = "badge-alert-critical"
            },
            new AlertItemVM
            {
                When = DateTime.Now.AddHours(-2),
                Title = "Elevated contact area",
                Detail = "Contact area increased on right hip.",
                PatientName = "Jane Smith",
                Frames = 90,
                Severity = "Warning",
                SeverityCss = "badge-alert-warning"
            },
            new AlertItemVM
            {
                When = DateTime.Now.AddHours(-5),
                Title = "Upload completed",
                Detail = "New CSV upload processed successfully.",
                PatientName = "Alan Brown",
                Frames = 60,
                Severity = "Info",
                SeverityCss = "badge-alert-info"
            }
        };

        private static readonly List<CommentItemVM> SampleComments = new()
        {
            new CommentItemVM
            {
                When = DateTime.Now.AddHours(-1),
                PatientName = "John Doe",
                Author = "Dr. Graphene",
                Category = "Follow-up",
                CategoryCss = "badge-comment-followup",
                Text = "Review heel pressure map tomorrow and consider repositioning schedule."
            },
            new CommentItemVM
            {
                When = DateTime.Now.AddHours(-5),
                PatientName = "Jane Smith",
                Author = "Dr. Graphene",
                Category = "Action",
                CategoryCss = "badge-comment-action",
                Text = "Escalate to tissue viability nurse – sustained high pressure for 20+ minutes."
            },
            new CommentItemVM
            {
                When = DateTime.Now.AddDays(-2),
                PatientName = "Alan Brown",
                Author = "Dr. Graphene",
                Category = "General",
                CategoryCss = "badge-comment-general",
                Text = "Patient comfortable; continue current monitoring frequency."
            }
        };

        // --------------------------------------------------------------
        //  DASHBOARD
        // --------------------------------------------------------------
        public IActionResult Dashboard()
        {
            var dashboardModel = new ClinicianDashboardVM
            {
                ClinicianName = "Dr. Graphene",
                LastUpdatedText = DateTime.Now.ToString("dd MMM yyyy HH:mm"),

                TotalFrames = 230,
                TodayDateLabel = DateTime.Today.Day,
                TodaysUploads = 12,
                DistinctPatients = SamplePatients.Count,

                LastUploadTimeText = DateTime.Now.ToString("HH:mm"),
                LastUploadDateText = DateTime.Now.ToString("dd MMM yyyy"),

                FramesToday = 55,
                FramesTodayLabel = "Frames analysed in the last 24 hours",

                Alerts = SampleAlerts
                    .OrderByDescending(a => a.When)
                    .Take(3)
                    .ToList(),

                RecentUploads = SamplePatients
                    .OrderByDescending(p => p.LastUploadAt)
                    .Select(p => new RecentUploadVM
                    {
                        PatientName = p.PatientName ?? string.Empty,
                        UploadedAt = p.LastUploadAt,
                        Frames = p.LastFrames,
                        Status = p.LastStatus ?? "Analysed",
                        StatusCss = p.LastStatusCss ?? "badge-status-stable"
                    })
                    .ToList(),

                Notes = "Follow up on repeat alerts."
            };

            return View(dashboardModel);
        }

        // --------------------------------------------------------------
        //  METRICS
        // --------------------------------------------------------------
        [HttpGet]
        public IActionResult Metrics(DateTime? fromDate, DateTime? toDate, string? selectedMetric)
        {
            var from = fromDate ?? DateTime.Today.AddDays(-7);
            var to = toDate ?? DateTime.Today;
            var metricKey = string.IsNullOrWhiteSpace(selectedMetric) ? "ppi" : selectedMetric;

            var metricPoints = new List<MetricDataPoint>();
            var contactAreaPoints = new List<MetricDataPoint>();
            var uploadPoints = new List<MetricDataPoint>();

            int dayIndex = 0;
            for (var d = from; d <= to; d = d.AddDays(1), dayIndex++)
            {
                metricPoints.Add(new MetricDataPoint { Date = d, Value = 40 + dayIndex * 3 });
                contactAreaPoints.Add(new MetricDataPoint { Date = d, Value = 10 + dayIndex * 1.5 });
                uploadPoints.Add(new MetricDataPoint { Date = d, Value = 5 + dayIndex });
            }

            var model = new MetricsViewModel
            {
                FromDate = from,
                ToDate = to,
                SelectedMetric = metricKey,
                MetricPoints = metricPoints,
                ContactAreaPoints = contactAreaPoints,
                UploadCountPoints = uploadPoints,
                NoDataReason = metricPoints.Count == 0 ? "No metric data available for this period." : null
            };

            return View(model);
        }

        // --------------------------------------------------------------
        //  PATIENTS
        // --------------------------------------------------------------
        [HttpGet]
        public IActionResult Patients(string? search)
        {
            var allPatients = SamplePatients.ToList();

            if (!string.IsNullOrWhiteSpace(search))
            {
                allPatients = allPatients
                    .Where(p =>
                        (p.PatientName ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        (p.NHSNumber ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        (p.Ward ?? "").Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var model = new ClinicianPatientsVM
            {
                ClinicianName = "Dr. Graphene",
                TotalPatients = SamplePatients.Count,
                UnderActiveMonitoring = SamplePatients.Count,
                HighRiskCount = SamplePatients.Count(p => p.RiskTag == "High"),
                Patients = allPatients,
                SearchTerm = search
            };

            return View(model);
        }

        // --------------------------------------------------------------
        //  GENERATE PATIENT PDF
        // --------------------------------------------------------------
        public IActionResult GeneratePatientPdf(int id)
        {
            var patient = SamplePatients.FirstOrDefault(x => x.PatientId == id);
            if (patient == null)
                return NotFound();

            var rnd = new Random();
            patient.Email ??= (patient.PatientName ?? "patient").Replace(" ", "").ToLower() + "@mail.com";
            patient.Contact ??= "07" + rnd.Next(100000000, 999999999);
            patient.Gender ??= rnd.Next(0, 2) == 0 ? "Male" : "Female";
            patient.Ward ??= "Unknown";

            var pdfBytes = _pdfService.CreatePatientReport(patient);

            var safeName = string.IsNullOrWhiteSpace(patient.PatientName)
                ? "Patient"
                : patient.PatientName.Replace(" ", "_");

            return File(pdfBytes, "application/pdf", $"PatientReport_{safeName}.pdf");
        }

        // --------------------------------------------------------------
        //  ALERTS
        // --------------------------------------------------------------
        [HttpGet]
        public IActionResult Alerts(string? severity = "all")
        {
            var allAlerts = SampleAlerts;

            var filtered = allAlerts;
            if (!string.IsNullOrWhiteSpace(severity) && severity != "all")
            {
                filtered = allAlerts
                    .Where(a => a.Severity.Equals(severity, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var model = new ClinicianAlertsVM
            {
                ClinicianName = "Dr. Graphene",
                TotalAlerts = allAlerts.Count,
                CriticalAlerts = allAlerts.Count(a => a.Severity == "Critical"),
                Last24hAlerts = allAlerts.Count(a => a.When >= DateTime.Now.AddDays(-1)),
                SelectedSeverity = severity,
                Alerts = filtered
            };

            return View(model);
        }

        // --------------------------------------------------------------
        //  COMMENTS
        // --------------------------------------------------------------
        [HttpGet]
        public IActionResult Comments(string? category = "all")
        {
            var allComments = SampleComments;

            var filtered = allComments;
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                string norm = category.ToLowerInvariant();
                filtered = allComments
                    .Where(c =>
                        (norm == "general" && c.Category.Equals("General", StringComparison.OrdinalIgnoreCase)) ||
                        (norm == "followup" && c.Category.Equals("Follow-up", StringComparison.OrdinalIgnoreCase)) ||
                        (norm == "action" && c.Category.Equals("Action", StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            var model = new ClinicianCommentsVM
            {
                ClinicianName = "Dr. Graphene",
                TotalComments = allComments.Count,
                Last7DaysComments = allComments.Count(c => c.When >= DateTime.Now.AddDays(-7)),
                FollowUpCount = allComments.Count(c => c.Category == "Follow-up"),
                SelectedCategory = category,
                Comments = filtered.OrderByDescending(c => c.When).ToList()
            };

            return View(model);
        }
    }
}
